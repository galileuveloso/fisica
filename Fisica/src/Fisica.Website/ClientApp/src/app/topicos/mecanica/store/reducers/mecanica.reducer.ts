import { Action, createReducer, on } from '@ngrx/store';
import * as actions from '../actions/mecanica.action';

export const mecanicaFeatureKey = 'manipularConta';

export interface MecanicaState {
  aulas: any;
  isSuccess: boolean;
  isLoading: boolean;
  isFailure: boolean;
}

export const mecanicaInitialState: MecanicaState = {
  aulas: [],
  isSuccess: false,
  isLoading: false,
  isFailure: false,
};

export const mecanicaReducer = createReducer(
  mecanicaInitialState,

  on(actions.carregarAulas, state => {
    return { ...state, isLoading: true, isSuccess: false, isFailure: false, error: "" };
  }),
  on(actions.carregarAulasSuccess, (state, action) => {
    return { ...state, aulas: action.response, isLoading: false, isSuccess: true, isFailure: false };
  }),
  on(actions.carregarAulasFailure, (state, action) => {
    return { ...state, isLoading: false, isSuccess: false, isFailure: true, mensagem: "Falha em buscar as aulas" };
  }),
);
