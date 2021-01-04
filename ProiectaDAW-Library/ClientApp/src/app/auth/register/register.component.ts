import {Component, OnInit} from '@angular/core';
import {FormBuilder, Validators} from '@angular/forms';
import {AuthService} from '../../core/services/auth/auth.service';
import {ActivatedRoute, Router} from '@angular/router';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  public hide = true;

  user = {
    username: '',
    password: '',
    firstName: '',
    lastName: ''
  };

  constructor(private fb: FormBuilder,
              private authenticationService: AuthService,
              private router: Router,
              private toastService: ToastrService,
              private route: ActivatedRoute) {
  }

  ngOnInit() {
  }

  register() {
    const data = {
      username: this.user.username,
      password: this.user.password,
      firstName: this.user.firstName,
      lastName: this.user.lastName
    };
    this.authenticationService.register(data)
      .subscribe(data => {
          console.log('Successfully registered', data);
          this.router.navigateByUrl('home');
        }
      );
  }
}
