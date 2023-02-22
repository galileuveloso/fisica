import { Component, OnInit } from '@angular/core';
import { Instituicao } from '../../shared/models/instituicao.model';
import { InstituicaoService } from '../../shared/services/instituicao.service';

@Component({
  selector: 'app-listar-instituicoes',
  templateUrl: './listar-instituicoes.component.html',
  styleUrls: ['./listar-instituicoes.component.css']
})
export class ListarInstituicoesComponent implements OnInit {

  instituicoes: Instituicao[];

  constructor(
    private service: InstituicaoService,
  )
  {
    this.instituicoes = [];
  }

  async ngOnInit() {
    await this.buscarInstituicoes();
  }

  private async buscarInstituicoes() {
    this.instituicoes = (await this.service.getInstituicoes().toPromise())!;
  }

  public async excluir(id?: number) {
    await this.service.excluir(id!).toPromise();
    await this.buscarInstituicoes();
  }
}
