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
import { VisualizarAulaComponent } from './aula/visualizar-aula/visualizar-aula.component';

import { AreasFisicaComponent } from './inicio/areas-fisica/areas-fisica.component';
import { ForumInicialComponent } from './forum/forum-inicial/forum-inicial.component';
import { TemaForumComponent } from './forum/tema-forum/tema-forum.component';
import { TopicoForumComponent } from './forum/topico-forum/topico-forum.component';
import { TelaInicialComponent } from './inicio/tela-inicial/tela-inicial.component';

@NgModule({
  declarations: [
    LoginComponent,
    AutocadastroComponent,
    DashboardUsuarioComponent,
    VisualizarAulaComponent,
    TelaInicialComponent,
    AreasFisicaComponent,
    ForumInicialComponent,
    TemaForumComponent,
    TopicoForumComponent
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
