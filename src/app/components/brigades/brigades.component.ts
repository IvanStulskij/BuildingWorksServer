import { Component, OnInit } from '@angular/core';
import { BrigadesService } from 'src/app/services/brigades.service';
import { Brigade } from 'src/app/types/brigades';

@Component({
  selector: 'app-brigades',
  templateUrl: './brigades.component.html',
  styleUrls: ['./brigades.component.scss']
})
export class BrigadesComponent implements OnInit {
  brigades: Brigade[] = [];

  constructor(private service: BrigadesService) {}

  ngOnInit(): void {
    this.service.getAll()
      .subscribe((result: Brigade[]) => {
        this.brigades = result
      });
  }

}
