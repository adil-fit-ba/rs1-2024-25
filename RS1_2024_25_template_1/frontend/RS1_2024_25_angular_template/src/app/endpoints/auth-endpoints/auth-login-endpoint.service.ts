import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {tap} from 'rxjs/operators';
import {MyConfig} from '../../my-config';
import {MyAuthService} from '../../services/auth-services/my-auth.service';
import {LoginTokenDto} from '../../services/auth-services/dto/login-token-dto';

export interface LoginRequest {
  username: string;
  password: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthLoginEndpointService {
  private apiUrl = `${MyConfig.api_address}/api/AuthLoginEndpoint`;

  constructor(private httpClient: HttpClient, private myAuthService: MyAuthService) {
  }

  login(request: LoginRequest): Observable<LoginTokenDto> {
    return this.httpClient.post<LoginTokenDto>(`${this.apiUrl}`, request).pipe(
      tap((response) => {
        // Use MyAuthService to store login token and auth info
        this.myAuthService.setLoggedInUser({
          token: response.token,
          myAuthInfo: response.myAuthInfo
        });
      })
    );
  }
}
