import { Routes } from "@angular/router";
import { AutocadastroComponent } from "./usuario/autocadastro/autocadastro.component";
import { LoginComponent } from "./usuario/login/login.component";

export const UsuarioComumRoutes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'autocadastro', component: AutocadastroComponent }
];
