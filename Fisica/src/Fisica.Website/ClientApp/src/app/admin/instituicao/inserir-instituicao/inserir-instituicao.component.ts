import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Cidade } from '../../../shared/models/cidade.model';
import { Endereco } from '../../../shared/models/endereco.model';
import { Instituicao } from '../../../shared/models/instituicao.model';
import { CidadeService } from '../../../shared/services/cidade.service';
import { InstituicaoService } from '../../../shared/services/instituicao.service';
import { NotificacoesService } from '../../../shared/services/notificacoes.service';

@Component({
  selector: 'app-inserir-instituicao',
  templateUrl: './inserir-instituicao.component.html',
  styleUrls: ['./inserir-instituicao.component.css']
})
export class InserirInstituicaoComponent implements OnInit {

  @Input()
  cidades: Cidade[];

  instituicao!: Instituicao;
  cidade: Cidade;

  constructor(
    private service: InstituicaoService,
    private cidadeService: CidadeService,
    private notificacoesService: NotificacoesService,
    private router: Router
  ) {
    this.cidade = new Cidade();
    this.instituicao = new Instituicao();
    this.instituicao.endereco = new Endereco();
    this.cidades = [];
  }

  async ngOnInit() {
    await this.buscarCidades();
  }

  private async buscarCidades(): Promise<void> {
    this.cidades = (await this.cidadeService.BuscarCidades().toPromise())!;
  }

  public async inserir(): Promise<void> {
    if (this.camposValidos()) {
      this.instituicao.endereco!.cidadeId = this.cidade.id;
      this.instituicao.endereco!.cidade = this.cidade;
      await this.service.inserir(this.instituicao).toPromise();
      this.router.navigate(["/instituicoes"]);
    }
  }

  private camposValidos(): boolean {
    let valido = true;

    if (!this.instituicao.nome) {
      this.notificacoesService.mostrarAviso("Preencha o campo 'Nome' para continuar.");
      valido = false;
    }


    if (!this.instituicao.email) {
      this.notificacoesService.mostrarAviso("Preencha o campo 'Email' para continuar.");
      valido = false;
    }

    if (!this.instituicao.site) {
      this.notificacoesService.mostrarAviso("Preencha o campo 'Site' para continuar.");
      valido = false;
    }

    if (!this.instituicao.endereco!.logradouro) {
      this.notificacoesService.mostrarAviso("Preencha o campo 'Logradouro' para continuar.");
      valido = false;
    }

    if (!this.instituicao.endereco!.numero) {
      this.notificacoesService.mostrarAviso("Preencha o campo 'Número' para continuar.");
      valido = false;
    }

    if (!this.cidade.id) {
      this.notificacoesService.mostrarAviso("Preencha o campo 'Cidade' para continuar.");
      valido = false;
    }

    if (!this.instituicao.endereco!.bairro) {
      this.notificacoesService.mostrarAviso("Preencha o campo 'Bairro' para continuar.");
      valido = false;
    }

    return valido;
  }
}
