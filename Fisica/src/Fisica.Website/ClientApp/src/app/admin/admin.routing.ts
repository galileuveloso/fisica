import { Routes } from "@angular/router";
import { EditarInstituicaoComponent } from "./editar-instituicao/editar-instituicao.component";
import { InserirInstituicaoComponent } from "./inserir-instituicao/inserir-instituicao.component";
import { ListarInstituicoesComponent } from "./listar-instituicoes/listar-instituicoes.component";

export const AdminRoutes: Routes = [
  { path: 'instituicoes', component: ListarInstituicoesComponent },
  { path: 'inserir-instituicao', component: InserirInstituicaoComponent },
  { path: 'editar-instituicao', component: EditarInstituicaoComponent }
];
