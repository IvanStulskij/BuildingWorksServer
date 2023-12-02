import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { Store, select } from '@ngrx/store';
import { Observable } from 'rxjs';
import { ProvidersService } from 'src/app/services/providers.service';
import { GetMaterialsByProvider } from 'src/app/store/actions/material.actions';
import { CreateOrder, GetOrder } from 'src/app/store/actions/order.actions';
import { selectBuildingObjectOrder } from 'src/app/store/selectors/order.selector';
import { IAppState } from 'src/app/store/states/app.state';
import { DictionaryItem } from 'src/app/types/common';
import { Material } from 'src/app/types/material';
import { OrderMaterialComponent } from '../order-material/order-material.component';

@Component({
  selector: 'app-order-card',
  templateUrl: './order-card.component.html',
  styleUrls: ['./order-card.component.scss']
})
export class OrderCardComponent implements OnInit {
  @ViewChild(MatTable) table!: MatTable<Material>;

  displayedMaterialColumns: string[] = ['name', 'measure', 'quantity', 'pricePerOne', 'totalPrice', ''];
  providersShortInfos$!: Observable<DictionaryItem[]>;
  selectedProvider!: DictionaryItem;
  order$ = this.store.pipe(select(selectBuildingObjectOrder));
  orderForm!: FormGroup;
  materials: Material[] | null = [];
  materialsTableDataSource: MatTableDataSource<Material> = new MatTableDataSource<Material>();

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private store: Store<IAppState>, 
    private matDialog: MatDialogRef<OrderCardComponent>,
    private dialog: MatDialog,
    private providersService: ProvidersService,
    private formBuilder: FormBuilder) {
      
  }

  ngOnInit(): void {
    if (this.data.id) {
      this.store.dispatch(new GetOrder(this.data.id));
    }

    this.providersShortInfos$ = this.providersService.getProvidersShortInfosByBuildingObject(this.data.buildingObjectId!);
    this.order$.subscribe(order => {
      this.orderForm = this.formBuilder.group({
        id: [order ? order.id : "00000000-0000-0000-0000-000000000000", [Validators.required]],
        orderId: [order ? order.orderId : null, [Validators.required]],
        providerId: [order ? order.orderId : null, [Validators.required]],
        buildingObjectId: [order ? order.buildingObjectId : null, [Validators.required]],
        plannedDeliveredAt: [order ? order.plannedDeliveredAt : null, [Validators.required]],
        factDeliveredAt: [order ? order.factDeliveredAt : null, [Validators.required]],
        startDeliverAt: [order ? order.startDeliverAt : null, [Validators.required]],
        providerName: [order ? order.providerName : null, [Validators.required]],
        materials: [order ? order.materials : null, [Validators.required]]
      });
    });
  }

  openOrderMaterialsComponent() : void {
    this.dialog.open(OrderMaterialComponent, {
      width: '500px',
      height: '500px',
      data: {
        providerId: this.selectedProvider.id
      }
    }).afterClosed().subscribe((result) => {
      this.materials?.push(result);
      this.materialsTableDataSource.data = this.materials!;
    });
  }
  
  saveOrder() : void {
      let created = this.orderForm.value;
      created.providerId = this.selectedProvider.id;
      created.materials = this.materials;
      created.buildingObjectId = this.data.buildingObjectId;
      this.store.dispatch(new CreateOrder(created));
      this.closeWindow();
  }

  closeWindow() : void {
    this.matDialog.close();
  }

  selectOrderMaterials() : void {
    this.store.dispatch(new GetMaterialsByProvider(this.selectedProvider.id));
  }
}
