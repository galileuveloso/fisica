import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TopicoForum } from '../../../shared/models/topico-forum.model';
import { TopicoForumService } from '../../../shared/services/topico-forum.service';

@Component({
  selector: 'app-tema-forum',
  templateUrl: './tema-forum.component.html',
  styleUrls: ['./tema-forum.component.css']
})
export class TemaForumComponent implements OnInit {

  /**
   *	Deve carregar os tópicos criados nesse tema de fórum.         -> buscarTopicosForum();
   *  Deve ser possível acessar um tópico.                          -> acessarTopico();
   *  Deve ser possível criar um tópico.                            -> inserirTopico();
   *  Não deve cadastrar tópico com dados inconsistentes.     
   *  Deve ser possível excluir um tópico cadastrado pelo usuário.  -> excluirTipico();
   *  Deve ser possível acessar o menu.
   *  Deve ser possível filtrar a lista por palavras.//fazer o filtro pelo proprio angular       
   * */

  forumId: number;
  topicos: TopicoForum[];
  novoTopico: TopicoForum;

  constructor(
    private route: ActivatedRoute,
    private topicoForumService: TopicoForumService,
    private router: Router
  ) {
    this.forumId = 0;
    this.topicos = [];
    this.novoTopico = new TopicoForum();
  }

  async ngOnInit(): Promise<void> {
    if (!this.route.snapshot.paramMap.get('forumId')) {
      //redirecionar pois nao veio forum
    }
    this.forumId = parseInt(this.route.snapshot.paramMap.get('forumId')!);

    await this.buscarTopicosForum();
  }

  private async buscarTopicosForum(): Promise<void> {
    this.topicos = (await this.topicoForumService.buscarTopicosForum(this.forumId).toPromise())!
  }

  public acessarTopico(topicoForumId: number) {
    this.router.navigate(['/forum/topico', topicoForumId]);
  }

  private async inserirTopico() {
    await this.topicoForumService.inserirTopico(this.novoTopico).toPromise();
  }

  public async excluirTipico(topifoForumId: number) {
    await this.topicoForumService.excluirTopico(topifoForumId).toPromise();
  }
}
