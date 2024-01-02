import { Component, OnInit } from '@angular/core';
import { DefaultItemsPerPage } from 'src/app/constants';
import { WorkersSalariesService } from 'src/app/services/workers-salaries.service';
import { LoadResult } from 'src/app/types/loader';
import { WorkerSalary } from 'src/app/types/workers-salaries';

@Component({
  selector: 'app-workers-salaries',
  templateUrl: './workers-salaries.component.html',
  styleUrls: ['./workers-salaries.component.scss']
})
export class WorkersSalariesComponent implements OnInit {
  workersSalaries: WorkerSalary[] = [];

  constructor(private service: WorkersSalariesService) { }

  ngOnInit(): void {
    this.service.getAll({
      page: 1,
      pageSize: DefaultItemsPerPage,
      filter: null,
      sorter: null
    })
      .subscribe((result: LoadResult<WorkerSalary>) => {
        this.workersSalaries = result.data;
      });
  }
}
