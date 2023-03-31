import { RespostaTopico } from "./resposta-topico.model";

export class TopicoForum {
  constructor(
    public id?: number,
    public titulo?: string,
    public descricao?: string,
    public usuarioCadastro?: string,
    public dataCadastro?: Date,
    public respostas?: RespostaTopico[]
  ) { }
}
