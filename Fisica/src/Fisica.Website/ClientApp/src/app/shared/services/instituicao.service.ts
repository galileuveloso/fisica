import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Instituicao } from '../models/instituicao.model';
import { AbstractHttpService } from './abstract-http.service';

@Injectable({
  providedIn: 'root'
})
export class InstituicaoService extends AbstractHttpService {

  constructor(@Inject('BASE_URL') baseUrl: string, httpClient: HttpClient) {
    super(baseUrl, httpClient, 'api/instituicao');
  }

  public inserir(instituicao: Instituicao): Observable<Instituicao> {
    return this.post<Instituicao>('inserir', instituicao);
  }
}
