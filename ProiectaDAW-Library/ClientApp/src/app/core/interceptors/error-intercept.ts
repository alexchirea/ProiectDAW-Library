import {Injectable} from '@angular/core';
import {HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse} from '@angular/common/http';
import {Observable} from 'rxjs';
import {tap} from 'rxjs/operators';
import {AuthService} from '../services/auth/auth.service';
import {ToastrService} from 'ngx-toastr';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private authenticationService: AuthService, private toastService: ToastrService) {
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(tap(() => {
      },
      (errorObject: any) => {
        if (errorObject instanceof HttpErrorResponse) {
          if (errorObject.status === 401) {
            this.authenticationService.onLogoutSuccess();
          } else if (errorObject instanceof HttpErrorResponse && errorObject.status === 400) {
            const errorMessage = typeof errorObject.error === 'string' ? errorObject.error : 'Something went wrong...';
            this.toastService.error(errorMessage);
          } else {
            this.toastService.error('Something went wrong...');
          }
        }
      }));
  }

}
