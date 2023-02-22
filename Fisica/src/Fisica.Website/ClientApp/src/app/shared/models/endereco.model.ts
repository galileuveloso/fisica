import { Cidade } from "./cidade.model";
import { Instituicao } from "./instituicao.model";

export class Endereco {
  constructor(
    public id?: number,
    public bairro?: string,
    public logradouro?: string,
    public numero?: number,
    public cidade?: Cidade,
    public cidadeId?: number,
    public institucao?: Instituicao
  ) { }
}
