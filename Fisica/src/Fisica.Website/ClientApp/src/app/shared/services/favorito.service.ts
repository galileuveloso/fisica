import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AbstractHttpService } from './abstract-http.service';

@Injectable({
  providedIn: 'root'
})
export class FavoritoService extends AbstractHttpService {

  constructor(@Inject('BASE_URL') baseUrl: string, httpClient: HttpClient) {
    super(baseUrl, httpClient, 'api/favorito');
  }

  public adicionarFavorito(aulaId?: number, sessaoAulaId?: number): Observable<void> {
    return this.post('inserir', { AulaId: aulaId, SessaoAulaId: sessaoAulaId });
  }

  public removerFavorito(favoritoId: number): Observable<void> {
    return this.delete(`excluir/${favoritoId}`);
  }
}
