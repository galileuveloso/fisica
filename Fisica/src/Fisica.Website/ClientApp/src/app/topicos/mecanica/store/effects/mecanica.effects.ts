import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, map, concatMap } from 'rxjs/operators';
import { of } from 'rxjs';

import * as actions from '../actions';

@Injectable()
export class MecanicaEffects {

  constructor(
    private actions$: Actions,
    //Buscar as aulas de mecanica na service
    //private mecanicaService: any
    ) {}

//   carregarAulas$ = createEffect(() => {
//     return this.actions$.pipe( 
//       ofType(actions.carregarAulas),
//       concatMap((action) =>
//         this.mecanicaService.carregarAulas(action.aula).pipe(
//           map(response => actions.carregarAulasSuccess({ aula: response })),
//           catchError(error => of(actions.carregarAulasFailure({ error }))))
//       )
//     );
//   });

}
