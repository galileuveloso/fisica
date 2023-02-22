import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Cidade } from '../../shared/models/cidade.model';
import { Endereco } from '../../shared/models/endereco.model';
import { Instituicao } from '../../shared/models/instituicao.model';
import { CidadeService } from '../../shared/services/cidade.service';
import { InstituicaoService } from '../../shared/services/instituicao.service';

@Component({
  selector: 'app-inserir-instituicao',
  templateUrl: './inserir-instituicao.component.html',
  styleUrls: ['./inserir-instituicao.component.css']
})
export class InserirInstituicaoComponent implements OnInit {

  @ViewChild('formInstituicao') formInstituicao!: NgForm;

  @Input()
  cidades: Cidade[];

  instituicao!: Instituicao;
  cidade: Cidade;

  constructor(
    private service: InstituicaoService,
    private cidadeService: CidadeService,
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

  private async buscarCidades() {
    this.cidades = (await this.cidadeService.BuscarCidades().toPromise())!;
  }

  async inserir(): Promise<void> {
    if (this.formInstituicao.form.valid) {
      this.instituicao.endereco!.cidadeId = this.cidade.id;
      await this.service.inserir(this.instituicao).toPromise();
      this.router.navigate(["/instituicoes"]);
    }
  }
}
