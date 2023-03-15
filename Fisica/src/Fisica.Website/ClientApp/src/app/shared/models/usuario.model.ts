import { Instituicao } from "./instituicao.model";
import { Perfil } from "./perfil.model";

export class Usuario {
  constructor(
    public id?: number,
    public nome?: string,
    public email?: string,
    public cpf?: string,
    public login?: string,
    public senha?: string,
    public tipoUsuario?: number,
    public perfil?: Perfil,
    public instituicao?: Instituicao
  ) { }
}
