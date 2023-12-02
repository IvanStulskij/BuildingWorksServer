import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Store, select } from '@ngrx/store';
import { CreateMaterial, GetMaterial, UpdateMaterial } from 'src/app/store/actions/material.actions';
import { selectMaterial } from 'src/app/store/selectors/material.selector';
import { IAppState } from 'src/app/store/states/app.state';

@Component({
  selector: 'app-material-card',
  templateUrl: './material-card.component.html',
  styleUrls: ['./material-card.component.scss']
})
export class MaterialCardComponent {
  material$ = this.store.pipe(select(selectMaterial));
  materialForm!: FormGroup;
  submitButtonText!: string;

  constructor(
    private store: Store<IAppState>, 
    @Inject(MAT_DIALOG_DATA) private data: string,
    private matDialog: MatDialogRef<MaterialCardComponent>,
    private formBuilder: FormBuilder) {
  }

  ngOnInit(): void {
    if (this.data) {
      this.store.dispatch(new GetMaterial(this.data));
      this.submitButtonText = "Save";
    }
    else {
      this.submitButtonText = "Create";
      this.material$.pipe();
    }

    this.material$.subscribe(material => {
      this.materialForm = this.formBuilder.group({
        id: [material ? material.id : "00000000-0000-0000-0000-000000000000", [Validators.required]],
        name: [material ? material.name : null, [Validators.required]],
        pricePerOne: [material ? material.pricePerOne : null, [Validators.required]],
        measure: [material ? material.measure : null, [Validators.required]]
      });
    });
  }

  saveMaterial() : void {
    if (this.submitButtonText == "Save") {
      this.store.dispatch(new UpdateMaterial(this.materialForm.value));
    }
    else {
      this.store.dispatch(new CreateMaterial(this.materialForm.value));
    }

    this.closeWindow();
  }

  closeWindow() : void {
    this.matDialog.close();
  }
}
