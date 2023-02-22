import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InstituicaoService } from './services/instituicao.service';
import { CidadeService } from './services/cidade.service';

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    InstituicaoService,
    CidadeService
  ]
})
export class SharedModule { }
