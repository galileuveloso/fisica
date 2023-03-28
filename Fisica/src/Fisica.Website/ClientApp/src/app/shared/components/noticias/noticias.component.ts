import { Component, OnInit } from '@angular/core';
import { Noticia } from '../../models/noticia.model';
import { NoticiaService } from '../../services/noticia.service';


@Component({
  selector: 'app-noticias',
  templateUrl: './noticias.component.html',
  styleUrls: ['./noticias.component.css']
})
export class NoticiasComponent implements OnInit {

  noticias: Noticia[];
  noticia: string;

  constructor(
    private noticiaService: NoticiaService
  ) {
    this.noticias = []
    this.noticia = "";
  }

  public async ngOnInit(): Promise<void> {
    await this.buscarNoticias();
  }

  public async buscarNoticias(): Promise<void> {
    this.noticias = (await this.noticiaService.getNoticias().toPromise())!;
  }

  public async publicarNoticia(): Promise<void> {
    if (this.noticia != "") {
      await this.noticiaService.inserir(this.noticia).toPromise();
    }
  }
}
