import { Component, OnInit } from '@angular/core';
import { Instituicao } from '../../../shared/models/instituicao.model';
import { Usuario } from '../../../shared/models/usuario.model';
import { InstituicaoService } from '../../../shared/services/instituicao.service';
import { UsuarioService } from '../../../shared/services/usuario.service';

@Component({
  selector: 'app-dashboard-admin',
  templateUrl: './dashboard-admin.component.html',
  styleUrls: ['./dashboard-admin.component.css']
})
export class DashboardAdminComponent implements OnInit {

  /**
   *	Deve carregar informações gerais sobre o sistema.
   *  Deve carregar uma lista de professores cadastrados.       -> selecionarProfessores();
   *  Deve carregar as instituições cadastradas.                -> selecionarInstituicoes();
   *  Deve carregar uma lista de usuários comuns cadastrados.   -> selecionarUsuariosComuns();
   *  Deve ser possível excluir professor.      //pela dash? pensei que poderia listar apenas e redirecionar pra tela de edição
   *  Deve ser possível atualizar professor.
   *  Deve ser possível excluir instituição.
   *  Deve ser possível alterar instituição.
   *  Deve ser possível excluir usuário comum.
   *  Deve ser possível atualizar usuário comum.
   *  Deve ser possível filtrar usuário professor.
   *  Deve ser possível filtrar usuário comum.
   *  Deve ser possível filtrar instituição.
   *  Deve ser possível cadastrar um usuário.
   *  Deve ser possível cadastrar uma instituição.
   *  
   * */

  professores: Usuario[];
  comuns: Usuario[];
  instituicoes: Instituicao[];

  constructor(
    private usuarioService: UsuarioService,
    private instituicaoService: InstituicaoService
  ) {
    this.professores = [];
    this.comuns = [];
    this.instituicoes = [];
  }

  public async ngOnInit(): Promise<void> {
    await this.selecionarProfessores();
    await this.selecionarUsuariosComuns();
    await this.selecionarInstituicoes();
  }

  private async selecionarProfessores(): Promise<void> {
    this.professores = (await this.usuarioService.selecionarProfessores().toPromise())!;
  }

  private async selecionarUsuariosComuns(): Promise<void> {
    this.comuns = (await this.usuarioService.selecionarUsuariosComuns().toPromise())!;
  }

  private async selecionarInstituicoes(): Promise<void> {
    this.instituicoes = (await this.instituicaoService.getInstituicoes().toPromise())!;
  }
}
