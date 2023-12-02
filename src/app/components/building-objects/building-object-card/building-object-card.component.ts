import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Store, select } from '@ngrx/store';
import { Observable } from 'rxjs';
import { DictionariesService } from 'src/app/services/dictionaries.service';
import { CreateBuildingObject, GetBuildingObject, UpdateBuildingObject } from 'src/app/store/actions/building-object.actions';
import { selectBuildingObject } from 'src/app/store/selectors/building-object.selector';
import { IAppState } from 'src/app/store/states/app.state';
import { DictionaryItem } from 'src/app/types/common';

@Component({
  selector: 'app-building-object-card',
  templateUrl: './building-object-card.component.html',
  styleUrls: ['./building-object-card.component.scss']
})

export class BuildingObjectCardComponent implements OnInit {
  buildingObjectTypes$!: Observable<DictionaryItem[]>;
  buildingObject$ = this.store.pipe(select(selectBuildingObject));
  buildingObjectForm!: FormGroup;
  submitButtonText!: string;
  selectedBuildingObjectType!: DictionaryItem;

  constructor(
    private store: Store<IAppState>, 
    @Inject(MAT_DIALOG_DATA) private data: string,
    private matDialog: MatDialogRef<BuildingObjectCardComponent>,
    private dictionariesService: DictionariesService,
    private formBuilder: FormBuilder) {
  }

  ngOnInit(): void {
    if (this.data) {
      this.store.dispatch(new GetBuildingObject(this.data));
      this.submitButtonText = "Save";
    }
    else {
      this.submitButtonText = "Create";
      this.buildingObject$.pipe();
    }
    this.buildingObjectTypes$ = this.dictionariesService.getBuildingObjectTypes();

    this.buildingObject$.subscribe(buildingObject => {
      this.buildingObjectForm = this.formBuilder.group({
        id: [buildingObject ? buildingObject.id : "00000000-0000-0000-0000-000000000000", [Validators.required]],
        objectName: [buildingObject ? buildingObject.objectName : null, [Validators.required]],
        buildingObjectType: [buildingObject ? buildingObject.buildingObjectType : null, [Validators.required]],
        buildingObjectTypeName: [buildingObject ? buildingObject.buildingObjectTypeName : null, [Validators.required]],
        objectCustomer: [buildingObject ? buildingObject.objectCustomer : null, [Validators.required]],
        executorCompany: [buildingObject ? buildingObject.executorCompany : null, [Validators.required]]
      });
    });
  }

  saveBuildingObject() : void {
    if (this.submitButtonText == "Save") {
      this.store.dispatch(new UpdateBuildingObject(this.buildingObjectForm.value));
    }
    else {
      let created = this.buildingObjectForm.value;
      created.buildingObjectType = this.selectedBuildingObjectType.id;
      created.buildingObjectTypeName = this.selectedBuildingObjectType.name;
      this.store.dispatch(new CreateBuildingObject(created));
    }

    this.closeWindow();
  }

  closeWindow() : void {
    this.matDialog.close();
  }
}