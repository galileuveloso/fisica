import { Endereco } from "./endereco.model";

export class Instituicao {
  constructor(
    public id?: number,
    public nome?: string,
    public descricao?: string,
    public email?: string,
    public site?: string,
    public endereco?: Endereco
  ) { }
}
