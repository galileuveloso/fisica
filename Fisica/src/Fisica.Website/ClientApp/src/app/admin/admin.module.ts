import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AdminRoutes } from './admin.routing';
import { FormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';
import { ListarUsuariosComponent } from './usuario/listar-usuarios/listar-usuarios.component';
import { InserirUsuarioComponent } from './usuario/inserir-usuario/inserir-usuario.component';
import { ListarInstituicoesComponent } from './instituicao/listar-instituicoes/listar-instituicoes.component';
import { InserirInstituicaoComponent } from './instituicao/inserir-instituicao/inserir-instituicao.component';
import { EditarInstituicaoComponent } from './instituicao/editar-instituicao/editar-instituicao.component';

@NgModule({
  declarations: [
    ListarInstituicoesComponent,
    InserirInstituicaoComponent,
    EditarInstituicaoComponent,
    ListarUsuariosComponent,
    InserirUsuarioComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(AdminRoutes),
    NgSelectModule
  ]
})
export class AdminModule { }
