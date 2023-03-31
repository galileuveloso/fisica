import { Component, OnInit } from '@angular/core';
import { Favorito } from '../../../shared/models/favorito.model';
import { Noticia } from '../../../shared/models/noticia.model';
import { WidgetAula } from '../../../shared/models/widget.model';
import { FavoritoService } from '../../../shared/services/favorito.service';
import { NoticiaService } from '../../../shared/services/noticia.service';
import { WidgetService } from '../../../shared/services/widget.service';

@Component({
  selector: 'app-dashboard-usuario',
  templateUrl: './dashboard-usuario.component.html',
  styleUrls: ['./dashboard-usuario.component.css']
})
export class DashboardUsuarioComponent implements OnInit {

  /**
   * 	Deve carregar as Aulas marcadas como ‘favorita’.                                        -> selecionarFavoritos();
   *	Deve carregar as Aulas adicionadas a ‘Concluída’, ‘Cursando’ e ‘Para Cursar’ (Widget).  -> selecionarWidgetsAulas();
   *	Deve carregar as notícias do feed.                                                      -> selecionarNoticias();
   *	Acessar aulas do Widget.
   *	Acessar aulas favoritadas.
   *	Deve carregar as notícias.    //duplicado
   *	Deve ser possível filtrar as notícias por ‘Apenas professores Seguidos’.//adaptar pois o metodo so traz de quem é seguido
   *	Deve filtrar as notícias pelo professor informado. //fazer pela tela isso
   *	Deve ser possível limpar os filtros de pesquisa.
   * */

  favoritos: Favorito[];
  widgets: WidgetAula[];
  noticias: Noticia[];

  constructor(
    private favoritoService: FavoritoService,
    private widgetService: WidgetService,
    private noticiaService: NoticiaService
  ) {
    this.favoritos = [];
    this.widgets = [];
    this.noticias = [];
  }

  public async ngOnInit(): Promise<void> {
    await this.selecionarFavoritos();
    await this.selecionarWidgetsAulas();
    await this.selecionarNoticias();
  }

  private async selecionarFavoritos(): Promise<void> {
    this.favoritos = (await this.favoritoService.selecionarFavoritos().toPromise())!;
  }

  private async selecionarWidgetsAulas(): Promise<void> {
    this.widgets = (await this.widgetService.selecionarWigetsAulas().toPromise())!;
  }

  private async selecionarNoticias(): Promise<void> {
    this.noticias = (await this.noticiaService.getNoticias().toPromise())!;
  }
}
