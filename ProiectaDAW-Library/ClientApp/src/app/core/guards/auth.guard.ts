import {Injectable} from '@angular/core';
import {
  CanActivate,
  CanActivateChild,
  CanLoad,
  Route,
  UrlSegment,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  UrlTree,
  Router
} from '@angular/router';
import {Observable} from 'rxjs';
import {AuthService} from '../services/auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(
    private authenticationService: AuthService,
    private router: Router
  ) {
  }

  canActivate(): boolean {
    if (!this.authenticationService.isLoggedIn()) {
      this.router.navigate(['auth/login']);
      return false;
    }
    return true;
  }

}
