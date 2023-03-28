import { Routes } from "@angular/router";
import { DashboardComponent } from "../shared/components/dashboard/dashboard.component";
import { AutocadastroComponent } from "./usuario/autocadastro/autocadastro.component";
import { LoginComponent } from "./usuario/login/login.component";

export const UsuarioComumRoutes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'autocadastro', component: AutocadastroComponent },
  { path: 'usuario/dashboard', component: DashboardComponent }
];
