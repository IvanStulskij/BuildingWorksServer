import { Injectable } from "@angular/core";
import { ofType, Actions, createEffect } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { catchError, map, switchMap } from 'rxjs/operators';
import { IAppState } from "../states/app.state";
import { of } from "rxjs";
import { EMaterialActions, GetMaterialsByOrder, GetMaterialsByOrderSuccess } from "../actions/material.actions";
import { MaterialsService } from "src/app/services/materials.service";
import { Material } from "src/app/types/material";

@Injectable()
export class OrderMaterialEffects {
    getOrderMaterials$ = createEffect(() => this.actions$.pipe(
        ofType<GetMaterialsByOrder>(EMaterialActions.GetMaterialsByOrder),
        switchMap((getInfo) => this.service.getByOrder(getInfo.payload)),
        switchMap((materials: Material[]) => of(new GetMaterialsByOrderSuccess(materials))),
        catchError((err, caught$) => {
            console.log(err['message']);
            
            return caught$;
        })
    ));

    constructor(
        private service: MaterialsService,
        private actions$: Actions
    ) {}
}