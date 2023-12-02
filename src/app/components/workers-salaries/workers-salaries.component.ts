import { Component, OnInit } from '@angular/core';
import { WorkersSalariesService } from 'src/app/services/workers-salaries.service';
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
    this.service.getAll()
      .subscribe((result: WorkerSalary[]) => {
        this.workersSalaries = result
      });
  }
}
