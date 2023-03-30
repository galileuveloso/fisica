import { SessaoAula } from "./sessao-aula.model";

export class Aula {
  constructor(
    public id?: number,
    public titulo?: string,
    public descricao?: string,
    public areaFisica?: string,
    public professorNome?: string,
    public professorId?: number,
    public sessoes?: SessaoAula[]
  ) { }
}
