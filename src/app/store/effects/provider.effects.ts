import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store, select } from "@ngrx/store";
import { IAppState } from "../states/app.state";
import { catchError, map, of, switchMap, withLatestFrom } from "rxjs";
import { AddProviderToBuildingObject, AddProviderToBuildingObjectSuccess, CreateProvider, CreateProviderSuccess, DeleteProvider, DeleteProviderSuccess, EProviderActions, GetProvider, GetProviderSuccess, GetProviders, GetProvidersByBuildingObject, GetProvidersByBuildingObjectSuccess, GetProvidersSuccess, UpdateProvider, UpdateProviderSuccess } from "../actions/provider.actions";
import { ProvidersService } from "src/app/services/providers.service";
import { Provider } from "src/app/types/providers";
import { selectProviderList } from "../selectors/provider.selector";
import { NotifierService } from "angular-notifier";

@Injectable()
export class ProviderEffects {
    createProvider$ = createEffect(() => this.actions$.pipe(
        ofType<CreateProvider>(EProviderActions.CreateProvider),
        switchMap((createModel) => this.service.create(createModel.payload)),
        switchMap((created: Provider) => of(new CreateProviderSuccess(created))),
        catchError((err, caught$) => {
            this.notificationService.notify("error", err['message']);
            
            return caught$;
        })
    ));

    addProviderToBuildingObject$ = createEffect(() => this.actions$.pipe(
        ofType<AddProviderToBuildingObject>(EProviderActions.AddProviderToBuildingObject),
        map(action => action.payload),
        withLatestFrom(this.store.pipe(select(selectProviderList))),
        switchMap(([buildingObjectProvider, providers]) => {
            this.service.addProviderToBuildingObject(buildingObjectProvider);
            this.notificationService.notify("success", "Provider was successfully added to building object");

            return of(providers);
        }),
        switchMap(() => of(new AddProviderToBuildingObjectSuccess())),
        catchError((err, caught$) => {
            this.notificationService.notify("error", err['message']);
            
            return caught$;
        })
    ));

    getProvidersByBuildingObject$ = createEffect(() => this.actions$.pipe(
        ofType<GetProvidersByBuildingObject>(EProviderActions.GetProvidersByBuildingObject),
        map(action => action.payload),
        switchMap((id) => this.service.getProvidersByBuildingObject(id)),
        switchMap((providers: Provider[]) => of(new GetProvidersByBuildingObjectSuccess(providers)))
    ));

    deleteProvider$ = createEffect(() => this.actions$.pipe(
        ofType<DeleteProvider>(EProviderActions.DeleteProvider),
        map(action => action.payload),
        withLatestFrom(this.store.pipe(select(selectProviderList))),
        switchMap(([id, buildingObjects]) => {
            this.service.delete(id);
            this.notificationService.notify("success", "Provider was successfully deleted");

            return of(buildingObjects);
        }),
        switchMap(() => of(new DeleteProviderSuccess())),
        catchError((err, caught$) => {
            this.notificationService.notify("error", err['message']);
            
            return caught$;
        })
    ));

    getProviders$ = createEffect(() => this.actions$.pipe(
        ofType<GetProviders>(EProviderActions.GetProviders),
        switchMap(() => this.service.getAll()),
        switchMap((plans: Provider[]) => of(new GetProvidersSuccess(plans))),
        catchError((err, caught$) => {
            this.notificationService.notify("error", err['message']);
            
            return caught$;
        })
    ));

    getProvider$ = createEffect(() => this.actions$.pipe(
        ofType<GetProvider>(EProviderActions.GetProvider),
        map(action => action.payload),
        switchMap((id) => this.service.getById(id)),
        switchMap((plan: Provider) => of(new GetProviderSuccess(plan)))
    ));

    updateProvider$ = createEffect(() => this.actions$.pipe(
        ofType<UpdateProvider>(EProviderActions.UpdateProvider),
        switchMap((updateModel) => {
            this.notificationService.notify("success", "Provider was successfully updated");
            var updated = this.service.update(updateModel.payload);

            return updated;
        }),
        switchMap((updated: Provider) => of(new UpdateProviderSuccess(updated))),
        catchError((err, caught$) => {
            this.notificationService.notify("error", err['message']);
            
            return caught$;
        })
    ));

    constructor(
        private notificationService: NotifierService,
        private service: ProvidersService,
        private actions$: Actions,
        private store: Store<IAppState>
    ) {}
}