import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { Store, select } from '@ngrx/store';
import { Observable, map } from 'rxjs';
import { CreateOrder, GetOrders } from 'src/app/store/actions/order.actions';
import { IAppState } from 'src/app/store/states/app.state';
import { Order } from 'src/app/types/order';
import { OrderCardComponent } from './order-card/order-card.component';
import { selectBuildingObjectOrderList } from 'src/app/store/selectors/order.selector';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent {
  displayedColumns: string[] = ['orderId', 'deliveredAt', 'startDeliverAt', 'providerName', 'selectMaterials'];
  id: string | null;
  orders$ : Observable<MatTableDataSource<Order>> = this.store.pipe(select(selectBuildingObjectOrderList), map(orders => {
    const dataSource = this.dataSource;
    dataSource.data = orders;

    return dataSource;
  }));
   
  private dataSource = new MatTableDataSource<Order>();

  constructor(private activatedRoute: ActivatedRoute, private dialog: MatDialog, private store: Store<IAppState>, private route: Router) {
    this.id = this.activatedRoute.snapshot.paramMap.get("id");
  }

  ngOnInit(): void {
    this.store.dispatch(new GetOrders(this.id!));
  }

  navigateToCreateWindow() : void {
    this.dialog.open(OrderCardComponent, {
      width: '500px',
      height: '500px',
      data: {
        buildingObjectId: this.id
      }
    })
  }
}
