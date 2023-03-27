export class UsuarioLoginModel {
  constructor(
    public usuarioId: number,
    public nome: string,
    public tipoUsuario: number,
    public token: string
  ) { }
}
