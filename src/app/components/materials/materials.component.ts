import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Store, select } from '@ngrx/store';
import { AddMaterialToProvider, DeleteMaterial, GetMaterials, GetMaterialsByOrder, GetMaterialsByProvider } from 'src/app/store/actions/material.actions';
import { selectMaterialList } from 'src/app/store/selectors/material.selector';
import { IAppState } from 'src/app/store/states/app.state';
import { MaterialCardComponent } from './material-card/material-card.component';
import { MatTableDataSource } from '@angular/material/table';
import { Observable, map } from 'rxjs';
import { Material } from 'src/app/types/material';
import { ActivatedRoute, Router } from '@angular/router';
import { selectProviderMaterialList } from 'src/app/store/selectors/provider-material.selector';
import { selectOrderMaterialList } from 'src/app/store/selectors/order-material.selector';
import { DefaultItemsPerPage } from 'src/app/constants';

@Component({
  selector: 'app-materials',
  templateUrl: './materials.component.html',
  styleUrls: ['./materials.component.scss']
})
export class MaterialsComponent implements OnInit {
  displayedReferencedColumns: string[] = ['pricePerOne', 'quantity', 'totalPrice', 'addToCollection'];
  displayedColumns: string[] = ['name', 'pricePerOne', 'measure', 'quantity', 'totalPrice'];
  providerId: string | null;
  orderId: string | null;

  isAdd!: boolean;
  private dataSource = new MatTableDataSource<Material>();
  
  materials$: Observable<MatTableDataSource<Material>> = new Observable<MatTableDataSource<Material>>();
  
  constructor(private store: Store<IAppState>, private dialog: MatDialog, private activatedRoute: ActivatedRoute, private route: Router) {
    this.providerId = this.activatedRoute.snapshot.paramMap.get("providerId");
    this.orderId = this.activatedRoute.snapshot.paramMap.get("orderId");

    this.isAdd = this.route.url.includes("add");
    let selector = select(selectMaterialList);

    if (!this.isAdd) {
      if (this.route.url.includes("providers")) {
        selector = select(selectProviderMaterialList);
      }

      if (this.route.url.includes("orders")) {
        selector = select(selectOrderMaterialList);
      }
    }
    this.materials$ = this.store.pipe(selector, map(material => {
      const dataSource = this.dataSource;
      dataSource.data = material?.data!;
      return dataSource;
    }));

    if (!this.orderId) {
      this.displayedColumns = this.displayedColumns.filter(column => !this.displayedReferencedColumns.includes(column));
    }
  }

  ngOnInit(): void {
    if (this.isAdd) {
      this.store.dispatch(new GetMaterials({
        page: 1,
        pageSize: DefaultItemsPerPage,
        filter: null,
        sorter: null
      }));
    }
    else {
      if (this.providerId) {
        this.store.dispatch(new GetMaterialsByProvider(this.providerId));
      }
      else if (this.orderId) {
        this.store.dispatch(new GetMaterialsByOrder(this.orderId));
      }
    }
  }

  navigateToMaterial(id: string) : void {
    this.dialog.open(MaterialCardComponent, {
      width: '500px',
      height: '500px',
      data: id
    })
  }

  navigateToCreateWindow() : void {
    this.dialog.open(MaterialCardComponent, {
      width: '500px',
      height: '500px',
    })
  }

  addToCollection(materialId: string, providerId: string) : void {
    if (this.isAdd) {

    }
    else if (this.providerId) {
      this.store.dispatch(new AddMaterialToProvider({
        materialsId: materialId,
        providersId: providerId
      }));
    }
  }

  deleteMaterial(id: string) : void {
    if (this.providerId) {

    }
    else {
      this.store.dispatch(new DeleteMaterial(id));
    }
  }
}
