import { Usuario } from "./usuario.model";

export class Noticia {
  constructor(
    public id?: number,
    public autor?: Usuario,
    public conteudo?: string,
    public dataCadastro?: Date,
    public autorId?: number,
    public autorNome?: string
  ) { }
}
