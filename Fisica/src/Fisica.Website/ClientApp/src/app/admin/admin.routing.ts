import { Routes } from "@angular/router";
import { EditarInstituicaoComponent } from "./instituicao/editar-instituicao/editar-instituicao.component";
import { InserirInstituicaoComponent } from "./instituicao/inserir-instituicao/inserir-instituicao.component";
import { ListarInstituicoesComponent } from "./instituicao/listar-instituicoes/listar-instituicoes.component";
import { InserirUsuarioComponent } from "./usuario/inserir-usuario/inserir-usuario.component";
import { ListarUsuariosComponent } from "./usuario/listar-usuarios/listar-usuarios.component";

export const AdminRoutes: Routes = [
  { path: 'instituicoes', component: ListarInstituicoesComponent },
  { path: 'inserir-instituicao', component: InserirInstituicaoComponent },
  { path: 'editar-instituicao', component: EditarInstituicaoComponent },
  { path: 'usuarios', component: ListarUsuariosComponent },
  { path: 'inserir-usuario', component: InserirUsuarioComponent },
];
