import { Aula } from "./aula.model";

export class WidgetAula {
  constructor(
    public id?: number,
    public descricao?: string,
    public usuarioId?: number,
    public aulas?: Aula[]
  ) { }
}
