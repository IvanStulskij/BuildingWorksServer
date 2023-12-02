import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Store, select } from '@ngrx/store';
import { AddProviderToBuildingObject, CreateProvider, GetProvider, UpdateProvider } from 'src/app/store/actions/provider.actions';
import { selectProvider } from 'src/app/store/selectors/provider.selector';
import { IAppState } from 'src/app/store/states/app.state';
import { Provider } from 'src/app/types/providers';

@Component({
  selector: 'app-provider-card',
  templateUrl: './provider-card.component.html',
  styleUrls: ['./provider-card.component.scss']
})
export class ProviderCardComponent {
  provider$ = this.store.pipe(select(selectProvider));
  providerForm!: FormGroup;
  submitButtonText!: string;

  constructor(
    private store: Store<IAppState>, 
    @Inject(MAT_DIALOG_DATA) private data: { providerId: string, buildingObjectId: string },
    private matDialog: MatDialogRef<ProviderCardComponent>,
    private formBuilder: FormBuilder) {
  }

  ngOnInit(): void {
    if (this.data && this.data.providerId && !this.data.buildingObjectId) {
      this.store.dispatch(new GetProvider(this.data.providerId));
      this.submitButtonText = "Save";
    }
    else {
      this.submitButtonText = "Create";
    }

    this.provider$.subscribe(provider => {
      this.updateGrid(provider);
    });
  }

  saveProvider() : void {
    if (this.data) {
      this.store.dispatch(new UpdateProvider(this.providerForm.value));
    }
    else {
      this.store.dispatch(new CreateProvider(this.providerForm.value));
      this.updateGrid(this.providerForm.value);
    }

    this.closeWindow();
  }

  closeWindow() : void {
    this.matDialog.close();
  }

  updateGrid(provider: Provider | null) : void {
    this.providerForm = this.formBuilder.group({
      id: [provider ? provider.id : "00000000-0000-0000-0000-000000000000", [Validators.required]],
      name: [provider ? provider.name : null, [Validators.required]],
      country: [provider ? provider.country : null, [Validators.required]],
      signer: [provider ? provider.signer : null, [Validators.required]],
      additionalData: [provider ? provider.additionalData : null, [Validators.required]]
    });
  }
}