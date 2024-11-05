import {Component} from '@angular/core';
import {MyAuthService} from '../../../services/auth-services/my-auth.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-admin-layout',
  templateUrl: './admin-layout.component.html',
  styleUrl: './admin-layout.component.css'
})
export class AdminLayoutComponent {

  constructor(private authService: MyAuthService, private router: Router) {
  }

  logout() {
    this.authService.setLoggedInUser(null);
    this.router.navigate(['/public']);
  }
}
