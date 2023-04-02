import { createAction, props } from '@ngrx/store';

export const carregarAulas = createAction(
  '[CriarConta] CriarConta',
  props<{ aula: any }>()
);

export const carregarAulasSuccess = createAction(
    '[CriarConta] CriarConta Success',
    props<{ aula: any[], response: any[] }>()
);

export const carregarAulasFailure = createAction(
    '[CriarConta] CriarConta Failure',
    props<{ error: any }>()
);
