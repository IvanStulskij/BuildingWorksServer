import { Component, OnInit } from '@angular/core';
import { PlansService } from 'src/app/services/plans.service';
import { LoadResult } from 'src/app/types/loader';
import { Plan } from 'src/app/types/plans';

@Component({
  selector: 'app-plans',
  templateUrl: './plans.component.html',
  styleUrls: ['./plans.component.scss']
})
export class PlansComponent implements OnInit {
  plans: Plan[] = [];

  constructor(private service: PlansService) { }

  ngOnInit(): void {
    this.service.getAll({
      page: 1,
      pageSize: 1,
      filter: null,
      sorter: null
    })
      .subscribe((result: LoadResult<Plan>) => {
        this.plans = result.data;
      });
  }

}
