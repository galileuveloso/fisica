import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { ListarInstituicoesComponent } from './admin/listar-instituicoes/listar-instituicoes.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'instituicoes',
    pathMatch: 'full',
  }, {
    path: '',
    component: ListarInstituicoesComponent,
    children: [{
      path: '',
      loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule)
    }]
  }
];

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    RouterModule.forRoot(routes, {
      useHash: true
    })
  ],
  exports: [
  ],
})
export class AppRoutingModule { }
