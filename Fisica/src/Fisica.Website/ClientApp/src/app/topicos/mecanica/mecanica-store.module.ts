import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreModule } from '@ngrx/store';
import * as fromMecanicaStore from './store/reducers/mecanica.reducer';
import { EffectsModule } from '@ngrx/effects';
import { MecanicaEffects } from './store/effects/mecanica.effects';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    StoreModule.forFeature(fromMecanicaStore.mecanicaFeatureKey, fromMecanicaStore.mecanicaReducer),
    EffectsModule.forFeature([MecanicaEffects])
  ]
})
export class MecanicaStoreModule { }
