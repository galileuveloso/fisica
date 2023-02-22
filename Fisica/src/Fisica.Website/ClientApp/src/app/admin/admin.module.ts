import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AdminRoutes } from './admin.routing';
import { ListarInstituicoesComponent } from './listar-instituicoes/listar-instituicoes.component';
import { InserirInstituicaoComponent } from './inserir-instituicao/inserir-instituicao.component';
import { EditarInstituicaoComponent } from './editar-instituicao/editar-instituicao.component';
import { FormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';


@NgModule({
  declarations: [
    ListarInstituicoesComponent,
    InserirInstituicaoComponent,
    EditarInstituicaoComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(AdminRoutes),
    NgSelectModule
  ]
})
export class AdminModule { }
