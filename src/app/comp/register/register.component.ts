import { Component, OnInit } from '@angular/core';
import { Validators, FormControl, FormBuilder } from '@angular/forms';
import { DomSanitizer } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { Provincia } from 'src/app/interfaces/provincia.interface';
import { Register } from 'src/app/interfaces/register.interface';
import { ProvinciaService } from 'src/app/servicios/provincia.service';
import { RegisterService } from 'src/app/servicios/register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {

  provincia!: Provincia;
  provinciaArray : any[] = [];
  public previsualizacion: string = '';
  public archivos: any = [];
  myForm = this.formBuilder.group({
    foto_frontal: new FormControl('', [Validators.required]),
    dni_delante: new FormControl('', [Validators.required]),
    dni_detras: new FormControl('', [Validators.required]),
    mail: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required]),
    nombre: new FormControl('', [Validators.required]),
    apellido: new FormControl('', [Validators.required]),
    cuil_cuit: new FormControl('', [Validators.required]),
    domicilio: new FormControl('', [Validators.required]),
  });

  // emailPattern = '^[a-z0-9._%+-]+@[a-z0-9.-]+.[a-z]{2,4}$';
  // mail = new FormControl('', [
  //   Validators.required,
  //   Validators.pattern(this.emailPattern),
  // ]);

  // passwordPattern =
  //   '(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-zd$@$!%*?&].{8,15}';
  // password = new FormControl('', [
  //   Validators.required,
  //   Validators.pattern(this.passwordPattern),
  //   Validators.minLength(8),
  // ]);

  constructor(
    private registerService: RegisterService,
    private router: Router,
    private formBuilder: FormBuilder,
    private sanitizer: DomSanitizer,
    private provinciaService: ProvinciaService
  ) {}
  extraerBase64 = async ($event: any) =>
    new Promise((resolve, _reject) => {
      try {
        const unsafeImg = window.URL.createObjectURL($event);
        const image = this.sanitizer.bypassSecurityTrustUrl(unsafeImg);
        const reader = new FileReader();
        reader.readAsDataURL($event);
        reader.onload = () => {
          resolve({
            base: reader.result,
          });
        };
        reader.onerror = (error) => {
          resolve({
            base: null,
          });
        };
      } catch (e) {}
    });

  capturarFile(event: any): any {
    const archivoCapturado = event.target.files[0];
    this.extraerBase64(archivoCapturado).then((imagen: any) => {
      this.previsualizacion = imagen.base;
    });
    this.archivos.push(archivoCapturado);
  }

  clearImage(): any {
    this.previsualizacion = '';
    this.archivos = [];
  }

  ngOnInit(): void {}
  // get mailField() {
  //   return this.mail;
  // }

  // get passwordField() {
  //   return this.password;
  // }
  onEnviar(event: Register) {
    this.registerService.postRegister(event).subscribe((data) => {
      {
        this.router.navigate(['/Registro']);
        console.log(data);
      }
    });
  }
  obtenerProvincia(event: Provincia) {
    this.provinciaService.getProvincia().subscribe((data) => {
      {
        console.log(data);
        this.provinciaArray[this.provincia.iD_provincia]=data.iD_provincia;
        this.provincia.provincia=data.provincia;
      }
    });
  }
}
