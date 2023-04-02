import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FlexLayoutModule } from "@angular/flex-layout";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MAT_DATE_LOCALE } from "@angular/material/core";
import { MaterialModule } from "../angular-material-modules";
import { CriarContaComponent } from "./criar-conta";
import { EletromagnetismoComponent } from "./eletromagnetismo";
import { EspeciaisComponent } from "./especiais";
import { FisicaModernaComponent } from "./fisica-moderna";
import { ForumComponent } from "./forum";
import { MatematicaComponent } from "./matematica";
import { MecanicaComponent } from "./mecanica";
import { OndulatoriaComponent } from "./ondulatoria";
import { TermodinamicaComponent } from "./termodinamica";
import { VestibularComponent } from "./vestibular";


@NgModule({
  declarations: [
    CriarContaComponent,
    EletromagnetismoComponent,
    EspeciaisComponent,
    FisicaModernaComponent,
    ForumComponent,
    MatematicaComponent,
    MecanicaComponent,
    OndulatoriaComponent,
    TermodinamicaComponent,
    VestibularComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    FlexLayoutModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    CriarContaComponent,
    EletromagnetismoComponent,
    EspeciaisComponent,
    FisicaModernaComponent,
    ForumComponent,
    MatematicaComponent,
    MecanicaComponent,
    OndulatoriaComponent,
    TermodinamicaComponent,
    VestibularComponent
  ],
  providers: [{ provide: MAT_DATE_LOCALE, useValue: 'en-GB' }],
})
export class TopicosModule {}
