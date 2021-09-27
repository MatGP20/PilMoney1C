import { Component, OnInit } from '@angular/core';
import { Validators, FormControl, FormBuilder, FormGroup } from '@angular/forms';
import { DomSanitizer } from '@angular/platform-browser';
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
  [x: string]: any;
  
  public clientes: Cliente[] = [];
  registroCliente: Cliente = new Cliente();
  clienteDefault: Cliente = new Cliente();


  public provincias: Provincia[] = [];
  public localidades: Localidad[] = [];

  selectorProvselected : Provincia = {ID_Provincia: 0, Provincia1 :""}

  public previsualizacion: string = '';
  public archivos: any = [];
  FormRegister : FormGroup;
    

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
    private provinciaService: ProvinciaService,
    private localidadService: LocalidadService,
  ) {

    this.FormRegister = this.formBuilder.group({
      foto_frontal: new FormControl('', [Validators.required]),
      dni_delante: new FormControl('', [Validators.required]),
      dni_detras: new FormControl('', [Validators.required]),
      mail: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required]),
      provincia: new FormControl('', [Validators.required]),
      localidad: new FormControl('', [Validators.required]),
      nombre: new FormControl('', [Validators.required]),
      apellido: new FormControl('', [Validators.required]),
      cuil_cuit: new FormControl('', [Validators.required]),
      domicilio: new FormControl('', [Validators.required]),
  });
  }
  
  ngOnInit(): void {

    this.provinciaService.getProvincia().subscribe((res : Provincia[]) => {
        this.provincias = res;
        console.log(this.provincias);         
    });
   
  }

  ObtenerLocalidadPorPr(){   
    // console.log(event);
    this.localidadService.getLocalidadPorId(this.FormRegister.value.provincia).subscribe((res: Localidad[]) => {
      this.Localidades = res;
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
  onEnviar(event: Cliente) {
    // this.registroCliente=[
    //   {
        

    //     Cuit_Cuil : this.FormRegister.value.cuil_cuit,
    //     Nombre : this.FormRegister.value.nombre,
    //     Apellido : this.FormRegister.value.apellido,
    //     Password : this.FormRegister.value.cuil_cuit,
    //     Mail : this.FormRegister.value.cuil_cuit,
    //     ID_Localidad : this.FormRegister.value.cuil_cuit,
    //     Foto_Frontal : this.FormRegister.value.cuil_cuit,
    //     DNI_delante : this.FormRegister.value.cuil_cuit,
    //     DNI_detras : this.FormRegister.value.cuil_cuit,
    //     Domicilio : this.FormRegister.value.cuil_cuit,

    //     Cliente: this.Cuit_Cuil = this.registroCliente.Cuit_Cuil,
    //    }
    // ];


    this.registerService.postRegister(event).subscribe((data) => {
      {
        this.router.navigate(['/Registro']);
        console.log(data);
      }
    });
  }
  
}
