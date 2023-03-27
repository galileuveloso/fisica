import { Component, OnInit } from '@angular/core';
import { Usuario } from '../../../shared/models/usuario.model';
import { UsuarioService } from '../../../shared/services/usuario.service';

@Component({
  selector: 'app-listar-usuarios',
  templateUrl: './listar-usuarios.component.html',
  styleUrls: ['./listar-usuarios.component.css']
})
export class ListarUsuariosComponent implements OnInit {

  usuarios: Usuario[];

  constructor(
    private service: UsuarioService,
  ) {
    this.usuarios = [];
  }

  async ngOnInit() {
    await this.buscarUsuarios();
  }

  private async buscarUsuarios() {
    this.usuarios = (await this.service.getUsuarios().toPromise())!;
  }

  public async excluir(id?: number) {
    await this.service.excluir(id!).toPromise();
    await this.buscarUsuarios();
  }

  public getTipoUsuario(tipoUsuario?: number): string {
    switch (tipoUsuario) {
      case 1:
        return "Comum";
      case 2:
        return "Professor";
      case 3:
        return "Prof. Administrador";
      case 4:
        return "Administrador";
      default:
        return "";
    }
  }
}
