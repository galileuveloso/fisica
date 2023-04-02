import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { ListarInstituicoesComponent } from './admin/instituicao/listar-instituicoes/listar-instituicoes.component';
import { HomeComponent } from './home';
import { EletromagnetismoComponent, EspeciaisComponent, FisicaModernaComponent, ForumComponent, 
  MatematicaComponent, MecanicaComponent, OndulatoriaComponent, TermodinamicaComponent, VestibularComponent 
} from './topicos';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'eletromagnetismo', component: EletromagnetismoComponent },
  { path: 'especiais', component: EspeciaisComponent },
  { path: 'fisicamoderna', component: FisicaModernaComponent },
  { path: 'forum', component: ForumComponent },
  { path: 'matematica', component: MatematicaComponent },
  { path: 'mecanica', component: MecanicaComponent },
  { path: 'ondulatoria', component: OndulatoriaComponent },
  { path: 'termodinamica', component: TermodinamicaComponent },
  { path: 'vestibular', component: VestibularComponent },
  // {
  //   path: '',
  //   redirectTo: 'instituicoes',
  //   pathMatch: 'full',
  // }, {
  //   path: '',
  //   component: ListarInstituicoesComponent,
  //   children: [{
  //     path: '',
  //     loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule)
  //   }]
  // }
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
