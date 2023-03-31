import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TopicoForum } from '../models/topico-forum.model';
import { AbstractHttpService } from './abstract-http.service';

@Injectable({
  providedIn: 'root'
})
export class TopicoForumService extends AbstractHttpService {

  constructor(@Inject('BASE_URL') baseUrl: string, httpClient: HttpClient) {
    super(baseUrl, httpClient, 'api/topicoforum');
  }

  public buscarTopicosForum(forumId: number): Observable<TopicoForum[]> {
    return this.get<TopicoForum[]>(`buscar-topicos/${forumId}`);
  }

  public inserirTopico(topicoForum: TopicoForum): Observable<TopicoForum> {
    return this.post<TopicoForum>('inserir', topicoForum);
  }

  public excluirTopico(topicoForumId: number): Observable<void> {
    return this.delete(`excluir/${topicoForumId}`);
  }

  public selecionarTopicoForum(topicoForumId: number): Observable<TopicoForum> {
    return this.get<TopicoForum>(`selecionar-topico-forum/${topicoForumId}`);
  }
}
