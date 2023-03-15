import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Instituicao } from '../../../shared/models/instituicao.model';
import { Usuario } from '../../../shared/models/usuario.model';
import { InstituicaoService } from '../../../shared/services/instituicao.service';
import { NotificacoesService } from '../../../shared/services/notificacoes.service';
import { UsuarioService } from '../../../shared/services/usuario.service';

@Component({
  selector: 'app-inserir-usuario',
  templateUrl: './inserir-usuario.component.html',
  styleUrls: ['./inserir-usuario.component.css']
})
export class InserirUsuarioComponent implements OnInit {

  usuario: Usuario;
  instituicao?: Instituicao;
  instituicoes: Instituicao[];

  constructor(
    private notificacoesService: NotificacoesService,
    private instituicaoService: InstituicaoService,
    private usuarioService: UsuarioService,
    private router: Router
  ) {
    this.usuario = new Usuario();
    this.instituicoes = [];
  }

  async ngOnInit(): Promise<void> {
    await this.buscarInstituicoes();
  }

  private async buscarInstituicoes(): Promise<void> {
    this.instituicoes = (await this.instituicaoService.getInstituicoes().toPromise())!;
  }

  public async inserir(): Promise<void> {
    if (this.camposValidos()) {
      if (this.instituicao)
        this.usuario.instituicao = this.instituicao;
      this.usuarioService.inserir(this.usuario).toPromise();
      //this.router.navigate(["/usuarios"]);
    }
  }

  private camposValidos(): boolean {
    let valido = true;

    if (!this.usuario.nome) {
      this.notificacoesService.mostrarAviso("Preencha o campo 'Nome' para continuar.");
      valido = false;
    }

    if (!this.usuario.email) {
      this.notificacoesService.mostrarAviso("Preencha o campo 'Email' para continuar.");
      valido = false;
    }

    if (!this.usuario.cpf) {
      this.notificacoesService.mostrarAviso("Preencha o campo 'Cpf' para continuar.");
      valido = false;
    }

    if (!this.usuario.login) {
      this.notificacoesService.mostrarAviso("Preencha o campo 'Login' para continuar.");
      valido = false;
    }

    if (!this.usuario.senha) {
      this.notificacoesService.mostrarAviso("Preencha o campo 'Senha' para continuar.");
      valido = false;
    }

    if (!this.usuario.tipoUsuario) {
      this.notificacoesService.mostrarAviso("Preencha o campo 'Tipo Usuário' para continuar.");
      valido = false;
    }

    return valido;
  }
}
