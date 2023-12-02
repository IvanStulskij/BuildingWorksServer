import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Store, select } from '@ngrx/store';
import { GetMaterial, GetMaterialsByProvider } from 'src/app/store/actions/material.actions';
import { selectProviderMaterial, selectProviderMaterialList } from 'src/app/store/selectors/provider-material.selector';
import { IAppState } from 'src/app/store/states/app.state';
import { Material } from 'src/app/types/material';

@Component({
  selector: 'app-order-material',
  templateUrl: './order-material.component.html',
  styleUrls: ['./order-material.component.scss']
})
export class OrderMaterialComponent implements OnInit {
  materials$ = this.store.pipe(select(selectProviderMaterialList));
  material$ = this.store.pipe(select(selectProviderMaterial));

  materials!: Material[];
  selectedMaterial!: Material | null;
  pricePerOne!: number;
  quantity!: number;

  constructor(
    private store: Store<IAppState>,
    private matDialog: MatDialogRef<OrderMaterialComponent>,
    @Inject(MAT_DIALOG_DATA) private data: any) {

  }

  ngOnInit(): void {
    this.getMaterialsList();
  }

  getMaterialsList() : void {
    this.store.dispatch(new GetMaterialsByProvider(this.data.providerId));

    this.materials$.subscribe(materials => {
      this.materials = materials;  
    });
  }

  changeSelectedMaterial(material: Material) : void {
    this.selectedMaterial = material;
  }

  getMaterialInfo(materialId: string) : void {
    this.store.dispatch(new GetMaterial(materialId));
    this.material$.subscribe(material => this.selectedMaterial = material);
  } 

  addMaterial() : void {
    this.selectedMaterial = {
      id: this.selectedMaterial?.id!,
      pricePerOne: this.pricePerOne!,
      quantity: this.quantity!,
      name: this.selectedMaterial?.name!,
      measure: this.selectedMaterial?.measure!,
    };

    this.matDialog.close(this.selectedMaterial);
  }
}
