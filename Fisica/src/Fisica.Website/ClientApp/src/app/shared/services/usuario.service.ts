import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { AutocadastroModel } from '../models/autocadastro.model';
import { UsuarioLoginModel } from '../models/usuario-login.model';
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

  public getUsuarios(): Observable<Usuario[]> {
    return this.get<Usuario[]>('buscar-usuarios');
  }

  public excluir(id: number): Observable<any> {
    return this.delete<any>(`excluir/${id}`);
  }

  public autoCadastro(usuario: AutocadastroModel) {
    return this.post<Usuario>('autocadastro', usuario);
  }

  //Autenticacao
  TOKEN: string = 'TOKEN';

  public login(login: string, senha: string): Observable<UsuarioLoginModel> {
    return this.post<UsuarioLoginModel>('login', { Login: login, Senha: senha });
  }

  async autenticar(token: string): Promise<void> {
    this.limparDados();
    localStorage.setItem(this.TOKEN, token.replaceAll("\"", ""));
  }

  public logout(): Observable<any> | null {
    this.limparDados();
    return null;
  }

  public isAutenticado(): boolean {
    const token = localStorage.getItem(this.TOKEN);
    return (token != null && token != undefined && token != '');
  }

  public validarUsuario() {
    if (!this.isAutenticado())
      window.location.replace('http://localhost:49828/#/website/');
  }

  public limparDados() {
    localStorage.removeItem(this.TOKEN);
  }
}
