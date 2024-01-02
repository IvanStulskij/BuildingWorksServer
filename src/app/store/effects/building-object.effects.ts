import { Injectable } from "@angular/core";
import { ofType, Actions, createEffect } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { BuildingObjectService } from "src/app/services/building-object.service";
import { DeleteBuildingObject, DeleteBuildingObjectSuccess, EBuildingObjectActions, GetBuildingObjectsSuccess, GetBuildingObjects, GetBuildingObject, GetBuildingObjectSuccess, CreateBuildingObject, CreateBuildingObjectSuccess, UpdateBuildingObject, UpdateBuildingObjectSuccess } from "../actions/building-object.actions";
import { catchError, map, switchMap, withLatestFrom } from 'rxjs/operators';
import { IAppState } from "../states/app.state";
import { select } from "@ngrx/store";
import { of } from "rxjs";
import { BuildingObject } from "src/app/types/building-objects";
import { selectBuildingObjectList } from "../selectors/building-object.selector";
import { LoadResult } from "src/app/types/loader";

@Injectable()
export class BuildingObjectEffects {
    createBuildingObject$ = createEffect(() => this.actions$.pipe(
        ofType<CreateBuildingObject>(EBuildingObjectActions.CreateBuildingObject),
        switchMap((buildingObject) => this.service.create(buildingObject.payload)),
        switchMap((created: BuildingObject) => of(new CreateBuildingObjectSuccess(created))),
        catchError((err, caught$) => {
            console.log(err['message']);
            
            return caught$;
        })
    ));

    deleteBuildingObject$ = createEffect(() => this.actions$.pipe(
        ofType<DeleteBuildingObject>(EBuildingObjectActions.DeleteBuildingObject),
        map(action => action.payload),
        withLatestFrom(this.store.pipe(select(selectBuildingObjectList))),
        switchMap(([id, buildingObjects]) => {
            this.service.delete(id);

            return of(buildingObjects);
        }),
        switchMap(() => of(new DeleteBuildingObjectSuccess())),
        catchError((err, caught$) => {
            console.log(err['message']);
            
            return caught$;
        })
    ));

    getBuildingObjects$ = createEffect(() => this.actions$.pipe(
        ofType<GetBuildingObjects>(EBuildingObjectActions.GetBuildingObjects),
        map(action => action.payload),
        switchMap((loadConditions) => this.service.getAll(loadConditions)),
        switchMap((loadResult: LoadResult<BuildingObject>) => of(new GetBuildingObjectsSuccess(loadResult))),
        catchError((err, caught$) => {
            console.log(err)
            console.log(err['message']);
            
            return caught$;
        })
    ));

    getBuildingObject$ = createEffect(() => this.actions$.pipe(
        ofType<GetBuildingObject>(EBuildingObjectActions.GetBuildingObject),
        map(action => action.payload),
        switchMap((id) => this.service.getById(id)),
        switchMap((buildingObject: BuildingObject) => of(new GetBuildingObjectSuccess(buildingObject)))
    ));

    updateBuildingObject$ = createEffect(() => this.actions$.pipe(
        ofType<UpdateBuildingObject>(EBuildingObjectActions.UpdateBuildingObject),
        switchMap((buildingObject) => this.service.update(buildingObject.payload)),
        switchMap((updated: BuildingObject) => of(new UpdateBuildingObjectSuccess(updated))),
        catchError((err, caught$) => {
            console.log(err['message']);
            
            return caught$;
        })
    ));

    constructor(
        private service: BuildingObjectService,
        private actions$: Actions,
        private store: Store<IAppState>
    ) {}
}