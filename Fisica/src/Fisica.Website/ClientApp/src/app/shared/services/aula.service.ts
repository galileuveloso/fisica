import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Aula } from '../models/aula.model';
import { AbstractHttpService } from './abstract-http.service';

@Injectable({
  providedIn: 'root'
})
export class AulaService extends AbstractHttpService {

  constructor(@Inject('BASE_URL') baseUrl: string, httpClient: HttpClient) {
    super(baseUrl, httpClient, 'api/aula');
  }

  public buscarAula(id: number): Observable<Aula> {
    return this.get(`selecionar-aula/${id}`)
  }
}
