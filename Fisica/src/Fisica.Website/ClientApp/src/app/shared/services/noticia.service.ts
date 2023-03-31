import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Noticia } from '../models/noticia.model';
import { AbstractHttpService } from './abstract-http.service';

@Injectable({
  providedIn: 'root'
})
export class NoticiaService extends AbstractHttpService {

  constructor(@Inject('BASE_URL') baseUrl: string, httpClient: HttpClient) {
    super(baseUrl, httpClient, 'api/noticia');
  }

  public inserir(noticia: string): Observable<Noticia> {
    let obj = {
      Conteudo: noticia
    };
    return this.post<Noticia>('inserir', obj);
  }

  public getNoticias(): Observable<Noticia[]> {
    return this.get<Noticia[]>('buscar-noticias');
  }

  public getUltimasNoticias(): Observable<Noticia[]> {
    return this.get<Noticia[]>('ultimas-noticias');
  }

}
