import { Replica } from "./replica.model";

export class RespostaTopico {
  constructor(
    public id?: number,
    public topicoForumId?: number,
    public descricao?: string,
    public nomeUsuario?: string,
    public replicas?: Replica[]
  ) { }
}
