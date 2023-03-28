import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NgSelectModule } from '@ng-select/ng-select';
import { SharedModule } from '../shared/shared.module';
import { DashboardUsuarioComponent } from './dashboard/dashboard-usuario/dashboard-usuario.component';
import { UsuarioComumRoutes } from './usuario-comum.routing';
import { AutocadastroComponent } from './usuario/autocadastro/autocadastro.component';
import { LoginComponent } from './usuario/login/login.component';

@NgModule({
  declarations: [
    LoginComponent,
    AutocadastroComponent,
    DashboardUsuarioComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(UsuarioComumRoutes),
    NgSelectModule,
    SharedModule
  ]
})
export class UsuarioComumModule { }
