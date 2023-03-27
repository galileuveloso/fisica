import { Component, Input, OnInit } from '@angular/core';
import { UsuarioLoginModel } from '../../../shared/models/usuario-login.model';
import { Usuario } from '../../../shared/models/usuario.model';
import { UsuarioService } from '../../../shared/services/usuario.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  @Input() login: string;
  @Input() senha: string;

  constructor(
    private usuarioService: UsuarioService
  ) {
    this.login = "";
    this.senha = "";
  }

  public ngOnInit(): void {

  }

  public async entrar(): Promise<void> {
    let usuario: UsuarioLoginModel | undefined = await this.usuarioService.login(this.login, this.senha).toPromise();
    //404 -> usuario nao encontrado
    this.usuarioService.autenticar(usuario!.token);
  }
}
