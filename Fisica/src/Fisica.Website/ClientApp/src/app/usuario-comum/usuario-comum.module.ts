import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UsuarioComumRoutes } from './usuario-comum.routing';
import { NgSelectModule } from '@ng-select/ng-select';
import { RouterModule } from '@angular/router';
import { LoginComponent } from './usuario/login/login.component';
import { AutocadastroComponent } from './usuario/autocadastro/autocadastro.component';

@NgModule({
  declarations: [
    LoginComponent,
    AutocadastroComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(UsuarioComumRoutes),
    NgSelectModule
  ]
})
export class UsuarioComumModule { }
