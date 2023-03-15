import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Usuario } from '../models/usuario.model';
import { AbstractHttpService } from './abstract-http.service';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService extends AbstractHttpService {

  constructor(@Inject('BASE_URL') baseUrl: string, httpClient: HttpClient) {
    super(baseUrl, httpClient, 'api/usuario');
  }

  public inserir(usuario: Usuario): Observable<Usuario> {
    return this.post<Usuario>('inserir', usuario);
  }
}
