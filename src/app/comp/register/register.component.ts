import { Component, OnInit } from '@angular/core';
import { Validators, FormControl, FormBuilder, FormGroup } from '@angular/forms';
// import { DomSanitizer } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { Provincia } from 'src/app/models/provincia.model';
// import { Provincia } from 'src/app/interfaces/provincia.interface';
// import { Register } from 'src/app/interfaces/register.interface';
import { ProvinciaService } from 'src/app/servicios/provincia.service';
import { RegisterService } from 'src/app/servicios/register.service';
import { Localidad } from 'src/app/models/localidades.model';
import { LocalidadService } from 'src/app/servicios/localidad.service';
import { Cliente } from 'src/app/models/register.model';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  // [x: string]: any;
  
  emailPattern = '^[a-z0-9._%+-]+@[a-z0-9.-]+.[a-z]{2,4}$';
  passwordPattern ='(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-zd$@$!%*?&].{8,15}';

  public clientes: Cliente[] = [];
  registroCliente: Cliente = new Cliente();
  clienteDefault: Cliente = new Cliente();


  public provincias: Provincia[] = [];
  public localidades: Localidad[] = [];

  selectorProvselected : Provincia = {ID_Provincia: 0, Provincia1 :""}

  public previsualizacion: string = '';
  public archivos: any = [];
  formRegister: FormGroup = this.formBuilder.group({
    foto_frontal: new FormControl('', [Validators.required]),
    dni_delante: new FormControl('', [Validators.required]),
    dni_detras: new FormControl('', [Validators.required]),
    emailRegistro: new FormControl('', [Validators.pattern(this.emailPattern),Validators.required]),
    passwordRegistro: new FormControl('', [Validators.pattern(this.passwordPattern),Validators.minLength(8),Validators.required]),
    provincia: new FormControl('', [Validators.required]),
    localidad: new FormControl('', [Validators.required]),
    nombre: new FormControl('', [Validators.required]),
    apellido: new FormControl('', [Validators.required]),
    cuil_cuit: new FormControl('', [Validators.required]),
    domicilio: new FormControl('', [Validators.required]),
});

    emailRegistro: any;
    passwordRegistro: any;

  
  // mailRegistro = new FormControl('', [
  //   Validators.required,
  //   Validators.pattern(this.emailPattern),
  // ]);

  
  // passwordRegistro = new FormControl('', [
  //   Validators.required,
  //   Validators.pattern(this.passwordPattern),
  //   Validators.minLength(8),
  // ]);

  constructor(
    private registerService: RegisterService,
    private router: Router,
    private formBuilder: FormBuilder,
    // private sanitizer: DomSanitizer,
    private provinciaService: ProvinciaService,
    private localidadService: LocalidadService,
    
  ) {
    
  
  }
  
  ngOnInit(): void {

    this.provinciaService.getProvincia().subscribe((res : Provincia[]) => {
        this.provincias = res;
        console.log(this.provincias);         
    });     
   
  }

  ObtenerLocalidadPorPr(){   
    console.log(this.formRegister.value.provincia);
    this.localidadService.getLocalidadPorId(this.formRegister.value.provincia).subscribe((res: Localidad[]) => {
      console.log(res); 
      this.localidades = res;
      console.log(this.localidades); 
             }); 
  }
  
  
  extraerBase64 = async ($event: any) =>
    new Promise((resolve, _reject) => {
      try {
        // const unsafeImg = window.URL.createObjectURL($event);
        // const image = this.sanitizer.bypassSecurityTrustUrl(unsafeImg);
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

  // get mailField() {
  //   return this.mail;
  // }

  // get passwordField() {
  //   return this.password;
  // }

  // Cuit_Cuil, Nombre, Apellido, Password, Mail, ID_Localidad, Foto_Frontal, DNI_delante, DNI_detras, Domicilio
  // Cliente:Cliente

  get emailRegistroValue() {
    return this.formRegister.get('email');
  }

  get passwordRegistroField() {
    return this.passwordRegistro;
  }

  onEnviar() {
    console.log(this.registroCliente);

                
    // this.registroCliente.Cuit_Cuil = this.formRegister.controls.cuil_cuit.value;
    // this.registroCliente.Nombre = this.formRegister.value.nombre;
    // this.registroCliente.Apellido = this.formRegister.value.apellido;
    this.registroCliente.Password = this.passwordRegistroField;
    this.registroCliente.Mail = this.emailRegistroValue?.value;
    // this.registroCliente.ID_Localidad = this.formRegister.value.localidad.ID_Localidad;
    this.registroCliente.Foto_Frontal = this.formRegister.value.foto_frontal;
    this.registroCliente.DNI_delante = this.formRegister.value.dni_delante;
    this.registroCliente.DNI_detras = this.formRegister.value.dni_detras;
    this.registroCliente.Domicilio = this.formRegister.value.domicilio;        
    
    console.log(this.registroCliente);
    

    

    // this.registerService.postRegister(this.registroCliente).subscribe(data => {
    //   {
    //     this.router.navigate(['/Registro']);
    //     console.log(data);
    //   }
    // });
  }

 
  
}
