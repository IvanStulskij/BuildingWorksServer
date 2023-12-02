import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Store, select } from '@ngrx/store';
import { AddMaterialToContract, DeleteContractMaterial, DeleteMaterial, GetMaterials, GetMaterialsByContract, GetMaterialsByProvider } from 'src/app/store/actions/material.actions';
import { selectMaterialList } from 'src/app/store/selectors/material.selector';
import { IAppState } from 'src/app/store/states/app.state';
import { MaterialCardComponent } from './material-card/material-card.component';
import { MatTableDataSource } from '@angular/material/table';
import { Observable, map } from 'rxjs';
import { Material } from 'src/app/types/material';
import { ActivatedRoute, Router } from '@angular/router';
import { selectProviderMaterialList } from 'src/app/store/selectors/provider-material.selector';

@Component({
  selector: 'app-materials',
  templateUrl: './materials.component.html',
  styleUrls: ['./materials.component.scss']
})
export class MaterialsComponent implements OnInit {
  displayedReferencedColumns: string[] = ['pricePerOne', 'quantity', 'totalPrice'];
  displayedColumns: string[] = ['name', 'pricePerOne', 'measure', 'addToCollection', 'quantity', 'totalPrice'];
  id: string | null;
  providerId: string | null;

  isAdd!: boolean;
  private dataSource = new MatTableDataSource<Material>();
  
  materials$: Observable<MatTableDataSource<Material>> = new Observable<MatTableDataSource<Material>>();
  
  constructor(private store: Store<IAppState>, private dialog: MatDialog, private activatedRoute: ActivatedRoute, private route: Router) {
    this.id = this.activatedRoute.snapshot.paramMap.get("id");
    this.providerId = this.activatedRoute.snapshot.paramMap.get("providerId");

    this.isAdd = this.route.url.includes("add");
    let selector = select(selectMaterialList);

    if (!this.isAdd) {
      if (this.route.url.includes("providers")) {
        selector = select(selectProviderMaterialList);
      }
    }
    this.materials$ = this.store.pipe(selector, map(material => {
      const dataSource = this.dataSource;
      dataSource.data = material;
      return dataSource;
    }));

    if (!this.id) {
      this.displayedColumns = this.displayedColumns.filter(column => !this.displayedReferencedColumns.includes(column));
    }
  }

  ngOnInit(): void {
    if (this.id) {
      if (this.isAdd) {
        if (this.providerId) {
          this.store.dispatch(new GetMaterialsByProvider(this.providerId!));
        }
        else {
          this.store.dispatch(new GetMaterials());
        }
      }
      else {
        if (this.providerId) {
          this.store.dispatch(new GetMaterialsByContract(this.id, this.providerId!));
        }
      }
    }
    else if (!this.id && this.providerId) {
      if (this.isAdd) {
        this.store.dispatch(new GetMaterials());
      }
      else {
        this.store.dispatch(new GetMaterialsByProvider(this.providerId));
      }
    }
    else {
      this.store.dispatch(new GetMaterials());
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
      if (this.route.url.includes("contracts")) {
        this.store.dispatch(new AddMaterialToContract({
          materialsId: materialId,
          contractsId: this.id!,
          providerId: providerId
        }));
      }
      else if (!this.route.url.includes("contracts") && this.route.url.includes("providers")) {

      }
    }
    
  }

  deleteMaterial(id: string) : void {
    if (this.id) {
      this.store.dispatch(new DeleteContractMaterial({
        contractsId: this.id,
        materialsId: id,
        providerId: this.providerId!
      }));
    }
    else if (!this.id && this.providerId) {
      
    }
    else {
      this.store.dispatch(new DeleteMaterial(id));
    }
  }
}
