import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {AuthService} from '../../core/services/auth/auth.service';
import {ActivatedRoute, Router} from '@angular/router';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  public hide = true;

  user = {
    username: '',
    password: ''
  };

  constructor(private fb: FormBuilder,
              private authenticationService: AuthService,
              private router: Router,
              private toastService: ToastrService,
              private route: ActivatedRoute) {
  }

  login() {
    const data = {
      username: this.user.username,
      password: this.user.password
    };
    this.authenticationService.login(data)
      .subscribe(data => {
          console.log('Successfully logged in.', data);
          this.router.navigateByUrl('home');
        },
        () => {
          this.toastService.error('The data provided is not valid!');
        }
      );
  }

}
