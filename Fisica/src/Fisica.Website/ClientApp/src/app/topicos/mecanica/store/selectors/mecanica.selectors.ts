import { createFeatureSelector, createSelector } from '@ngrx/store';
import * as fromManipularConta from '../reducers/mecanica.reducer';

export const selectAulasMecanicaState = createFeatureSelector<fromManipularConta.ManipularContaState>(
  fromManipularConta.manipularContaFeatureKey
);

export const getManyAulasMecanicaConta = createSelector(selectAulasMecanicaState, (state) => {
  return state.aulas;
})