import {Injectable} from '@angular/core';
import {ApiService} from '../api/api.service';
import {Observable} from 'rxjs';
import {map} from 'rxjs/operators';
import {Router} from '@angular/router';
import {ToastrService} from 'ngx-toastr';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly endpoint = 'user';

  constructor(private apiService: ApiService,
              private router: Router,
              private toastService: ToastrService) {
  }

  login(userCredentials): Observable<any> {
    return this.apiService.post<any>(`${this.endpoint}/login`, userCredentials).pipe(
      map((response: any) => {
        if (response) {
          localStorage.setItem('userProfile', response);
          localStorage.setItem('username', response.firstName + " " + response.lastName);
          localStorage.setItem('isAdmin', response.isAdmin);
        }
      })
    );
  }

  isLoggedIn(): boolean {
    const userProfile = localStorage.getItem('userProfile');
    //console.log(userProfile);
    return !!userProfile;
  }

  getUsername(): string {
    const username = localStorage.getItem('username');
    return username;
  }

  isLoggedInAdmin(): boolean {
    const userProfile = localStorage.getItem('userProfile');
    const isAdmin = localStorage.getItem('isAdmin');
    return !!userProfile && isAdmin == 'true';
  }

  logout() {
    this.apiService.post<any>(`${this.endpoint}/logout`, null)
      .subscribe(response => {
        if (response.success) {
          this.onLogoutSuccess();
        }
      }, () => {
        this.toastService.error('Logout unsuccessful.');
      });
  }

  onLogoutSuccess(): void {
    localStorage.removeItem('userProfile');
    localStorage.removeItem('username');
    localStorage.removeItem('isAdmin');
    this.router.navigate(['auth/login']);
  }

  updatePassword(passwordInfo): Observable<any> {
    return this.apiService.put<any>(`${this.endpoint}/change-password`, passwordInfo);
  }

  forgotPassword(email): Observable<any> {
    return this.apiService.post<any>(`${this.endpoint}/forgot-password`, email);
  }

  resetPassword(newPasswordInfo): Observable<any> {
    return this.apiService.put(`${this.endpoint}/reset-password`, newPasswordInfo);
  }

  deleteAccount(): Observable<any> {
    return this.apiService.post(`${this.endpoint}/remove-account`);
  }

  register(userData): Observable<any> {
    return this.apiService.post<any>(`${this.endpoint}/register`, userData).pipe(
      map((response: any) => {
        if (response.success) {
          localStorage.setItem('userProfile', response.userProfile);
        }
      })
    );
  }
}
