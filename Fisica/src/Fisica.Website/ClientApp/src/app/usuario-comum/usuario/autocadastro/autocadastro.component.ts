import { Component, OnInit } from '@angular/core';
import { AutocadastroModel } from '../../../shared/models/autocadastro.model';
import { Perfil } from '../../../shared/models/perfil.model';
import { Usuario } from '../../../shared/models/usuario.model';
import { UsuarioService } from '../../../shared/services/usuario.service';

@Component({
  selector: 'app-autocadastro',
  templateUrl: './autocadastro.component.html',
  styleUrls: ['./autocadastro.component.css']
})
export class AutocadastroComponent implements OnInit {

  usuario: AutocadastroModel;

  constructor(
    private usuarioService: UsuarioService
  ) {
    this.usuario = new AutocadastroModel();
  }

  public ngOnInit(): void {

  }

  public async inserir(): Promise<void> {
    await this.usuarioService.autoCadastro(this.usuario).toPromise();
  }
}
