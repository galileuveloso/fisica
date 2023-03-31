import { Routes } from "@angular/router";
import { DashboardComponent } from "../shared/components/dashboard/dashboard.component";
import { VisualizarAulaComponent } from "./aula/visualizar-aula/visualizar-aula.component";
import { ForumInicialComponent } from "./forum/forum-inicial/forum-inicial.component";
import { TemaForumComponent } from "./forum/tema-forum/tema-forum.component";
import { TopicoForumComponent } from "./forum/topico-forum/topico-forum.component";
import { AreasFisicaComponent } from "./inicio/areas-fisica/areas-fisica.component";
import { TelaInicialComponent } from "./inicio/tela-inicial/tela-inicial.component";
import { AutocadastroComponent } from "./usuario/autocadastro/autocadastro.component";
import { LoginComponent } from "./usuario/login/login.component";

export const UsuarioComumRoutes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'autocadastro', component: AutocadastroComponent },
  { path: 'usuario/dashboard', component: DashboardComponent },
  { path: 'aula/visualizar-aula/:id', component: VisualizarAulaComponent },
  { path: 'inicio', component: TelaInicialComponent },
  { path: 'inicio/areas-fisica', component: AreasFisicaComponent },
  { path: 'forum/forum-inicial', component: ForumInicialComponent },
  { path: 'forum/tema-forum/:forumId', component: TemaForumComponent },
  { path: 'forum/topico/:topicoForumId', component: TopicoForumComponent }
];
