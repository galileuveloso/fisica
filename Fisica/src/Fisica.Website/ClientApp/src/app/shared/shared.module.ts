import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InstituicaoService } from './services/instituicao.service';
import { CidadeService } from './services/cidade.service';
import { NotificacoesService } from './services/notificacoes.service';
import { NoticiasComponent } from './components/noticias/noticias.component';
import { NoticiaService } from './services/noticia.service';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { FormsModule } from '@angular/forms';
import { AulaService } from './services/aula.service';
import { SegueService } from './services/segue.service';
import { FavoritoService } from './services/favorito.service';
import { ComentarioAulaService } from './services/comentario-aula.service';
import { WidgetService } from './services/widget.service';

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
    NoticiaService,
    AulaService,
    SegueService,
    FavoritoService,
    ComentarioAulaService,
    WidgetService
  ]
})
export class SharedModule { }
