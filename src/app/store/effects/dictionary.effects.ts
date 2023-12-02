import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { switchMap, of, catchError } from "rxjs";
import { EDictionaryActions, GetBuildingObjectTypes, GetBuildingObjectTypesSuccess } from "../actions/dictionaries.actions";
import { DictionaryItem } from "src/app/types/common";
import { DictionariesService as DictionaryService } from "src/app/services/dictionaries.service";

@Injectable()
export class DictionaryEffects {
    getBuildingObjects$ = createEffect(() => this.actions$.pipe(
        ofType<GetBuildingObjectTypes>(EDictionaryActions.GetBuildingObjectTypes),
        switchMap(() => this.service.getBuildingObjectTypes()),
        switchMap((types: DictionaryItem[]) => of(new GetBuildingObjectTypesSuccess(types))),
        catchError((err, caught$) => {
            console.log(err['message']);
            
            return caught$;
        })
    ));

    constructor(
        private service: DictionaryService,
        private actions$: Actions,
    ) {}
}