import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InstituicaoService } from './services/instituicao.service';
import { CidadeService } from './services/cidade.service';
import { NotificacoesService } from './services/notificacoes.service';
import { NoticiasComponent } from './components/noticias/noticias.component';
import { NoticiaService } from './services/noticia.service';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    NoticiasComponent,
    DashboardComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [
    DashboardComponent
  ],
  providers: [
    InstituicaoService,
    CidadeService,
    NotificacoesService,
    NoticiaService
  ]
})
export class SharedModule { }
