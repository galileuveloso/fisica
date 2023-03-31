import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RespostaTopico } from '../models/resposta-topico.model';
import { AbstractHttpService } from './abstract-http.service';

@Injectable({
  providedIn: 'root'
})
export class RespostaTopicoService extends AbstractHttpService {

  constructor(@Inject('BASE_URL') baseUrl: string, httpClient: HttpClient) {
    super(baseUrl, httpClient, 'api/respostatopico');
  }

  public inserirResposta(respostaTopico: RespostaTopico): Observable<void> {
    return this.post('inserir', respostaTopico);
  }

  public excluirResposta(respostaTopicoId: number): Observable<void> {
    return this.delete(`excluir/${respostaTopicoId}`);
  }

}
