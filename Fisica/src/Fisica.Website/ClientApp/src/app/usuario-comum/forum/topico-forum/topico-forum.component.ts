import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RespostaTopico } from '../../../shared/models/resposta-topico.model';
import { TopicoForum } from '../../../shared/models/topico-forum.model';
import { RespostaTopicoService } from '../../../shared/services/resposta-topico.service';
import { TopicoForumService } from '../../../shared/services/topico-forum.service';

@Component({
  selector: 'app-topico-forum',
  templateUrl: './topico-forum.component.html',
  styleUrls: ['./topico-forum.component.css']
})
export class TopicoForumComponent implements OnInit {

  /**
   *	Deve carregar os comentários do tópico.                                     -> buscarTopicoForum();
   *  Deve ser possível alterar o comentário.
   *  Não deve ser possível alterar o comentário com informações inconsistentes.
   *  Deve ser possível responder comentários do tópico.                          -> inserirResposta();
   *  Não deve ser possível responder comentário com informações inconsistentes.
   *  Deve ser possível excluir um comentário.                                    -> excluirResposta();
   *  Deve ser possível clicar no perfil do usuário.
   *  Deve ser possível acessar o menu.
   *  Deve ser possível voltar para a tela anterior.
   *
   * */

  topicoForum: TopicoForum;
  topicoForumId: number;

  constructor(
    private topicoForumService: TopicoForumService,
    private route: ActivatedRoute,
    private respostaTopicoService: RespostaTopicoService
  ) {
    this.topicoForum = new TopicoForum();
    this.topicoForumId = 0;
  }

  public async ngOnInit(): Promise<void> {
    if (!this.route.snapshot.paramMap.get('topicoForumId')) {
      //redirecionar pois nao veio topico
    }
    this.topicoForumId = parseInt(this.route.snapshot.paramMap.get('topicoForumId')!);
    await this.buscarTopicoForum();
  }

  private async buscarTopicoForum(): Promise<void> {
    this.topicoForum = (await this.topicoForumService.selecionarTopicoForum(this.topicoForumId).toPromise())!
  }

  private async inserirResposta(): Promise<void> {
    let resposta = new RespostaTopico();//popular a resposta
    await this.respostaTopicoService.inserirResposta(resposta).toPromise();
  }

  public async excluirResposta(respostaTopicoId: number): Promise<void> {
    await this.respostaTopicoService.excluirResposta(respostaTopicoId).toPromise();
  }
}
