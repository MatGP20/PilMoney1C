import { Component, OnInit } from '@angular/core';
import { Validators, FormControl } from '@angular/forms';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  emailPattern = '^[a-z0-9._%+-]+@[a-z0-9.-]+.[a-z]{2,4}$';
  mail = new FormControl('', [
    Validators.required,
    Validators.pattern(this.emailPattern),
  ]);

  passwordPattern =
    '/^(?=.*[a-z])(?=.*[A-Z])(?=.*d)(?=.*[$@$!%*?&])[A-Za-zd$@$!%*?&]{8,15}/';
  password = new FormControl('', [
    Validators.required,
    Validators.pattern(this.passwordPattern),
    Validators.minLength(8),
  ]);

  constructor() {}

  ngOnInit(): void {}
  get mailField() {
    return this.mail;
  }

  get passwordField() {
    return this.password;
  }
}
