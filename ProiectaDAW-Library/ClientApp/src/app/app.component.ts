import { Component } from '@angular/core';
import { AuthService } from './core/services/auth/auth.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';

  constructor(private authService: AuthService) {}

  logout(): void {
    this.authService.onLogoutSuccess();
  }

  isLoggedIn(): boolean {
    return this.authService.isLoggedIn();
  }

  isAdmin(): boolean {
    return this.authService.isLoggedInAdmin();
  }

}
