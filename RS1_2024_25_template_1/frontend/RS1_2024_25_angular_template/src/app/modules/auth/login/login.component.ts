import {Component} from '@angular/core';
import {Router} from '@angular/router';
import {AuthLoginEndpointService, LoginRequest} from '../../../endpoints/auth-endpoints/auth-login-endpoint.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginRequest: LoginRequest = {username: 'admin1', password: 'admin123'};
  errorMessage: string | null = null;

  constructor(private authLoginService: AuthLoginEndpointService, private router: Router) {
  }

  onLogin(): void {
    this.authLoginService.handleAsync(this.loginRequest).subscribe({
      next: () => {
        console.log('Login successful');
        this.router.navigate(['/admin']); // Redirect to
      },
      error: (error: any) => {
        this.errorMessage = 'Incorrect username or password';
        console.error('Login error:', error);
      }
    });
  }
}
