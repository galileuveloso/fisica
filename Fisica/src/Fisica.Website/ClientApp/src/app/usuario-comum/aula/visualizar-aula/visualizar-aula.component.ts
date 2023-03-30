import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Aula } from '../../../shared/models/aula.model';
import { AulaService } from '../../../shared/services/aula.service';
import { ComentarioAulaService } from '../../../shared/services/comentario-aula.service';
import { FavoritoService } from '../../../shared/services/favorito.service';
import { SegueService } from '../../../shared/services/segue.service';
import { WidgetService } from '../../../shared/services/widget.service';

@Component({
  selector: 'app-visualizar-aula',
  templateUrl: './visualizar-aula.component.html',
  styleUrls: ['./visualizar-aula.component.css']
})
export class VisualizarAulaComponent implements OnInit {

  /**
   *  HU – Acessar aula postada
   * 
   *  Deve carregar a aula.                                           -> buscarAula();
   *  Deve ser possível seguir o professor que publicou a aula.       -> seguirProfessor(); -> deixarDeSeguirProfessor();
   *  Deve ser possível clicar em “adicionar aulas em favoritos”.     -> adicionarFavorito();
   *  Deve ser possível clicar em “retirar aula favoritada”.          -> removerFavorito();
   *  Deve carregar comentários da aula.                              -> Já vem no buscarAula.
   *  Deve ser possível cadastrar um comentário aula.                 -> inserirComentario(); -> removerComentario();
   *  Deve ser possível adicionar a aula em sua dashboard de estudos. -> adicionarWidget();
   *  Deve ser possível acessar o menu.
   *  Deve ser possível voltar para a tela anterior.
   *
   * */

  professorId: number;
  aulaId: number;
  aula: Aula;

  constructor(
    private route: ActivatedRoute,
    private aulaService: AulaService,
    private segueService: SegueService,
    private favoritoService: FavoritoService,
    private comentarioService: ComentarioAulaService,
    private widgetService: WidgetService
  ) {
    this.aulaId = 0;
    this.professorId = 0;
    this.aula = new Aula();
  }

  public async ngOnInit(): Promise<void> {
    if (!this.route.snapshot.paramMap.get('id')) {
      //redirecionar pois nao veio aula
    }
    this.aulaId = parseInt(this.route.snapshot.paramMap.get('id')!);
    await this.buscarAula();
    this.professorId = this.aula.professorId!;
  }

  private async buscarAula(): Promise<void> {
    this.aula = (await this.aulaService.buscarAula(this.aulaId).toPromise())!;
    console.log(this.aula);
  }

  private async seguirProfessor(): Promise<void> {
    await this.segueService.seguirProfessor(this.professorId).toPromise();
  }

  private async deixarDeSeguirProfessor(): Promise<void> {
    await this.segueService.deixarDeSeguirProfessor(this.professorId).toPromise();
  }

  private async adicionarFavorito(aulaId?: number, sessaoAulaId?: number) {
    await this.favoritoService.adicionarFavorito(aulaId, sessaoAulaId).toPromise();
  }

  private async removerFavorito(favoritoId: number): Promise<void> {
    await this.favoritoService.removerFavorito(favoritoId);
  }

  private async inserirComentario(): Promise<void> {
    await this.comentarioService.adicionarComentario(this.aulaId, "").toPromise(); //TO-DO: Colocar a descricao do campo.
  }

  private async removerComentario(comentarioId: number): Promise<void> {
    await this.comentarioService.excluirComentario(comentarioId).toPromise();
  }

  private async adicionarWidget(widgetId: number): Promise<void> {
    await this.widgetService.inserirAula(this.aulaId, widgetId).toPromise();
  }
}
