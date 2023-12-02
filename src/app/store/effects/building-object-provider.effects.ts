import { Injectable } from "@angular/core";
import { ofType, Actions, createEffect } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { catchError, map, switchMap } from 'rxjs/operators';
import { IAppState } from "../states/app.state";
import { of } from "rxjs";
import { AddProviderToBuildingObject, AddProviderToBuildingObjectSuccess, EProviderActions, GetProvidersByBuildingObject, GetProvidersByBuildingObjectSuccess } from "../actions/provider.actions";
import { ProvidersService } from "src/app/services/providers.service";
import { Provider } from "src/app/types/providers";

@Injectable()
export class BuildingObjectProviderEffects {
    getBuildingObjectProviders$ = createEffect(() => this.actions$.pipe(
        ofType<GetProvidersByBuildingObject>(EProviderActions.GetProvidersByBuildingObject),
        switchMap((getInfo) => this.service.getProvidersByBuildingObject(getInfo.payload)),
        switchMap((providers: Provider[]) => of(new GetProvidersByBuildingObjectSuccess(providers))),
        catchError((err, caught$) => {
            console.log(err['message']);
            
            return caught$;
        })
    ));

    addProviderToBuildingObject$ = createEffect(() => this.actions$.pipe(
        ofType<AddProviderToBuildingObject>(EProviderActions.AddProviderToBuildingObject),
        map(action => action.payload),
        switchMap((buildingObjectProvider) => {
            this.service.addProviderToBuildingObject(buildingObjectProvider);

            return of();
        }),
        switchMap(() => of(new AddProviderToBuildingObjectSuccess())),
        catchError((err, caught$) => {
            console.log(err['message']);
            
            return caught$;
        })
    ));

    constructor(
        private service: ProvidersService,
        private actions$: Actions,
        private store: Store<IAppState>
    ) {}
}