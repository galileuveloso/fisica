export class SessaoAula {
  constructor(
    public id?: number,
    public aulaId?: number,
    public conteudo?: string,
    public ordem?: number,
    public tipoSessao?: number
  ) { }
}
