import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store, select } from "@ngrx/store";
import { IAppState } from "../states/app.state";
import { catchError, map, of, switchMap, withLatestFrom } from "rxjs";
import { CreateMaterial, CreateMaterialSuccess, DeleteMaterial, DeleteMaterialSuccess, EMaterialActions, GetMaterial, GetMaterialSuccess, GetMaterials, GetMaterialsSuccess, UpdateMaterial, UpdateMaterialSuccess } from "../actions/material.actions";
import { Material } from "src/app/types/material";
import { MaterialsService } from "src/app/services/materials.service";
import { selectMaterialList } from "../selectors/material.selector";
import { LoadResult } from "src/app/types/loader";

@Injectable()
export class MaterialEffects {
    createMaterial$ = createEffect(() => this.actions$.pipe(
        ofType<CreateMaterial>(EMaterialActions.CreateMaterial),
        switchMap((createModel) => this.service.create(createModel.payload)),
        switchMap((created: Material) => of(new CreateMaterialSuccess(created))),
        catchError((err, caught$) => {
            console.log(err['message']);
            
            return caught$;
        })
    ));

    deleteMaterial$ = createEffect(() => this.actions$.pipe(
        ofType<DeleteMaterial>(EMaterialActions.DeleteMaterial),
        map(action => action.payload),
        withLatestFrom(this.store.pipe(select(selectMaterialList))),
        switchMap(([id, buildingObjects]) => {
            this.service.delete(id);

            return of(buildingObjects);
        }),
        switchMap(() => of(new DeleteMaterialSuccess())),
        catchError((err, caught$) => {
            console.log(err['message']);
            
            return caught$;
        })
    ));

    getMaterials$ = createEffect(() => this.actions$.pipe(
        ofType<GetMaterials>(EMaterialActions.GetMaterials),
        map(action => action.payload),
        switchMap((loadConditions) => this.service.getAll(loadConditions)),
        switchMap((materials: LoadResult<Material>) => of(new GetMaterialsSuccess(materials))),
        catchError((err, caught$) => {
            console.log(err['message']);
            
            return caught$;
        })
    ));

    getMaterial$ = createEffect(() => this.actions$.pipe(
        ofType<GetMaterial>(EMaterialActions.GetMaterial),
        map(action => action.payload),
        switchMap((id) => this.service.getById(id)),
        switchMap((material: Material) => of(new GetMaterialSuccess(material)))
    ));

    updateMaterial$ = createEffect(() => this.actions$.pipe(
        ofType<UpdateMaterial>(EMaterialActions.UpdateMaterial),
        switchMap((updateModel) => this.service.update(updateModel.payload)),
        switchMap((updated: Material) => of(new UpdateMaterialSuccess(updated))),
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