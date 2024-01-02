import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Store, select } from '@ngrx/store';
import { selectWorkerList } from 'src/app/store/selectors/worker.selector';
import { IAppState } from 'src/app/store/states/app.state';
import { WorkerCardComponent } from './worker-card/worker-card.component';
import { DeleteWorker, GetWorkers } from 'src/app/store/actions/worker.actions';
import { DefaultItemsPerPage } from 'src/app/constants';
import { LoadResult } from 'src/app/types/loader';
import { Worker } from 'src/app/types/workers';

@Component({
  selector: 'app-workers',
  templateUrl: './workers.component.html',
  styleUrls: ['./workers.component.scss']
})
export class WorkersComponent implements OnInit {
  
  displayedColumns: string[] = ['name', 'startWorkDate', 'post'];
  workers!: LoadResult<Worker> | null;
  //workers$ = this.store.pipe(select(selectWorkerList));

  constructor(
    private store: Store<IAppState>,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.store.dispatch(new GetWorkers({
      page: 1,
      pageSize: DefaultItemsPerPage,
      filter: null,
      sorter: null
    }));

    this.store.pipe(select(selectWorkerList)).subscribe(workers => {
      this.workers = workers;
    });
  }

  navigateToWorker(id: string) : void {
    this.dialog.open(WorkerCardComponent, {
      width: '500px',
      height: '500px',
      data: id
    })
  }

  navigateToCreateWindow() : void {
    this.dialog.open(WorkerCardComponent, {
      width: '500px',
      height: '500px',
    })
  }

  deleteWorker(id: string) : void {
    this.store.dispatch(new DeleteWorker(id));
  }
}
