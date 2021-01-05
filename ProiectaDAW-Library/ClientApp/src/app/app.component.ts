import { Component } from '@angular/core';
import { AuthService } from './core/services/auth/auth.service';
import { Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  username = 'aa';

  constructor(private authService: AuthService,
              private toastr: ToastrService) {}

  ngOnInit() {
    this.username = this.authService.getUsername();
  }

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
