import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { IAppState } from "../states/app.state";
import { catchError, of, switchMap } from "rxjs";
import { CreateOrder, CreateOrderSuccess, EOrderActions, GetOrders, GetOrdersSuccess } from "../actions/order.actions";
import { OrdersService } from "src/app/services/order.service";
import { Order } from "src/app/types/order";

@Injectable()
export class OrderEffects {

    createOrder$ = createEffect(() => this.actions$.pipe(
        ofType<CreateOrder>(EOrderActions.CreateOrder),
        switchMap((createModel) => this.service.createOrder(createModel.payload)),
        switchMap((created: Order) => of(new CreateOrderSuccess(created))),
        catchError((err, caught$) => {
            console.log(err['message']);
            
            return caught$;
        })
    ));

    getOrders$ = createEffect(() => this.actions$.pipe(
        ofType<GetOrders>(EOrderActions.GetOrders),
        switchMap((getInfo) => this.service.getOrders(getInfo.payload)),
        switchMap((orders: Order[]) => of(new GetOrdersSuccess(orders))),
        catchError((err, caught$) => {
            console.log(err['message']);
            
            return caught$;
        })
    ));

    constructor(
        private service: OrdersService,
        private actions$: Actions,
        private store: Store<IAppState>
    ) {}
}