import { Injectable } from "@angular/core";
import { ofType, Actions, createEffect } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { catchError, map, switchMap } from 'rxjs/operators';
import { IAppState } from "../states/app.state";
import { of } from "rxjs";
import { AddMaterialToProvider, AddMaterialToProviderSuccess, EMaterialActions, GetMaterialsByProvider, GetMaterialsByProviderSuccess } from "../actions/material.actions";
import { Material } from "src/app/types/material";
import { MaterialsService } from "src/app/services/materials.service";
import { LoadResult } from "src/app/types/loader";

@Injectable()
export class ProviderMaterialEffects {
    getProviderMaterials$ = createEffect(() => this.actions$.pipe(
        ofType<GetMaterialsByProvider>(EMaterialActions.GetMaterialsByProvider),
        switchMap((getInfo) => this.service.getByProvider(getInfo.payload)),
        switchMap((materials: LoadResult<Material>) => of(new GetMaterialsByProviderSuccess(materials))),
        catchError((err, caught$) => {
            console.log(err['message']);
            
            return caught$;
        })
    ));

    addMaterialToProvider$ = createEffect(() => this.actions$.pipe(
        ofType<AddMaterialToProvider>(EMaterialActions.AddMaterialToProvider),
        map(action => action.payload),
        switchMap((providerMaterial) => {
            this.service.addToProvider(providerMaterial);

            return of();
        }),
        switchMap(() => of(new AddMaterialToProviderSuccess())),
        catchError((err, caught$) => {
            console.log(err['message']);
            
            return caught$;
        })
    ));

    constructor(
        private service: MaterialsService,
        private actions$: Actions,
        private store: Store<IAppState>
    ) {}
}