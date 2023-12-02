import { Component, OnInit } from '@angular/core';
import { PlansService } from 'src/app/services/plans.service';
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
    this.service.getAll()
      .subscribe((result: Plan[]) => {
        this.plans = result
      });
  }

}
