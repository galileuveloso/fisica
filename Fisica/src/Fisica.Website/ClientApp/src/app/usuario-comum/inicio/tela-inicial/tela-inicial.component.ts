import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Noticia } from '../../../shared/models/noticia.model';
import { NoticiaService } from '../../../shared/services/noticia.service';
import { UsuarioService } from '../../../shared/services/usuario.service';

@Component({
  selector: 'app-tela-inicial',
  templateUrl: './tela-inicial.component.html',
  styleUrls: ['./tela-inicial.component.css']
})
export class TelaInicialComponent implements OnInit {

  /**
   *  HU – Acessar tela inicial
   * 
   *  Deve carregar as últimas notícias/aulas postadas no site.   -> buscarUltimasNoticias();
   *  Deve ser possível acessar as aulas.
   *  Deve ser possível acessar o fórum.
   *  Deve ser possível criar conta.
   *  Deve ser possível conhecer a equipe do sistema.
   *  Deve ser possível deslogar no sistema                       -> deslogarUsuario();
   *
   * */

  noticias: Noticia[];

  constructor(
    private noticiaService: NoticiaService,
    private usuarioService: UsuarioService,
    private router: Router
  ) {
    this.noticias = [];
  }

  public async ngOnInit(): Promise<void> {

  }

  private async buscarUltimasNoticias(): Promise<void> { // Buscas as 10 últimas notícias postadas
    this.noticias = (await this.noticiaService.getUltimasNoticias().toPromise())!;
  }

  private async deslogarUsuario(): Promise<void> {
    this.usuarioService.limparDados();
    this.router.navigate(['/login']);
  }
}
