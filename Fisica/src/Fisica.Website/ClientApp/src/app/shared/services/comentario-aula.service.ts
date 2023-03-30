import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AbstractHttpService } from './abstract-http.service';

@Injectable({
  providedIn: 'root'
})
export class ComentarioAulaService extends AbstractHttpService {

  constructor(@Inject('BASE_URL') baseUrl: string, httpClient: HttpClient) {
    super(baseUrl, httpClient, 'api/comentarioaula');//TO-DO: Validar se esta rota está correta.
  }

  public adicionarComentario(aulaId: number, descricao: string): Observable<void> {
    return this.post('inserir', { AulaId: aulaId, Descricao: descricao });
  }

  public excluirComentario(comentarioAulaId: number): Observable<void> {
    return this.delete(`excluir/${comentarioAulaId}`);
  }
}
