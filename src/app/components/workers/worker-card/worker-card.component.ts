import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Store, select } from '@ngrx/store';
import { CreateWorker, GetWorker, UpdateWorker } from 'src/app/store/actions/worker.actions';
import { selectWorker } from 'src/app/store/selectors/worker.selector';
import { IAppState } from 'src/app/store/states/app.state';
import { Worker } from 'src/app/types/workers';

@Component({
  selector: 'app-worker-card',
  templateUrl: './worker-card.component.html',
  styleUrls: ['./worker-card.component.scss']
})
export class WorkerCardComponent {
  savedWorker!: Worker;
  worker$ = this.store.pipe(select(selectWorker));
  workerForm!: FormGroup;
  submitButtonText!: string;

  constructor(
    private store: Store<IAppState>, 
    @Inject(MAT_DIALOG_DATA) private data: string,
    private matDialog: MatDialogRef<WorkerCardComponent>,
    private formBuilder: FormBuilder) {
  }

  ngOnInit(): void {
    if (this.data) {
      this.store.dispatch(new GetWorker(this.data));
      this.submitButtonText = "Save";
    }
    else {
      this.submitButtonText = "Create";
    }

    this.worker$.subscribe(worker => {
      this.workerForm = this.formBuilder.group({
        id: [worker ? worker.id : "00000000-0000-0000-0000-000000000000", [Validators.required]],
        firstName: [worker ? worker.firstName : null, [Validators.required]],
        lastName: [worker ? worker.lastName : null, [Validators.required]],
        middleName: [worker ? worker.middleName : null, [Validators.required]],
        startWorkDate: [worker ? worker.startWorkDate : null, [Validators.required]],
        brigadier: [worker ? (worker.brigadierBrigadeId ? true : false ) : null, [Validators.required]],
        brigadeId: [worker ? worker.brigadeId : null, [Validators.required]]
      });
    });
  }

  saveWorker() : void {
    this.savedWorker = this.workerForm.value;

    if (this.workerForm.get("brigadier")?.value) {
      this.savedWorker.brigadierBrigadeId = this.savedWorker.id;
    }

    if (this.submitButtonText == "Save") {
      
      this.store.dispatch(new UpdateWorker(this.savedWorker));
    }
    else {
      this.store.dispatch(new CreateWorker(this.savedWorker));
    }

    this.closeWindow();
  }

  closeWindow() : void {
    this.matDialog.close();
  }
}
