import { Component, OnInit } from '@angular/core';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  form: FormGroup;

  constructor(private formBuilder: FormBuilder) {
    this.form = this.formBuilder.group({
      password: ['', [Validators.required, Validators.minLength(8)]],
      mail: ['', [Validators.required, Validators.email]],
    });
  }

  ngOnInit(): void {}

  get mailField() {
    return this.form.get('mail');
  }

  get passField() {
    return this.form.get('password');
  }

  get passInvalid() {
    return this.passField.touched && !this.passField.valid;
  }

  get mailInvalid() {
    return this.mailField.touched && !this.mailField.valid;
  }

  onEnviar(event: Event) {
    event.preventDefault(); //Cancela la funcionalidad por default.
    if (this.form.valid) {
      console.log(this.form.value); //se puede enviar al servidor...
    } else {
      this.form.markAllAsTouched(); //Activa todas las validaciones
    }
  }
}
