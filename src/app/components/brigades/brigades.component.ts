import { Component, OnInit } from '@angular/core';
import { DefaultItemsPerPage } from 'src/app/constants';
import { BrigadesService } from 'src/app/services/brigades.service';
import { Brigade } from 'src/app/types/brigades';
import { LoadResult } from 'src/app/types/loader';

@Component({
  selector: 'app-brigades',
  templateUrl: './brigades.component.html',
  styleUrls: ['./brigades.component.scss']
})
export class BrigadesComponent implements OnInit {
  brigades: Brigade[] = [];

  constructor(private service: BrigadesService) {}

  ngOnInit(): void {
    this.service.getAll({
      page: 1,
      pageSize: DefaultItemsPerPage,
      filter: null,
      sorter: null
    })
      .subscribe((result: LoadResult<Brigade>) => {
        this.brigades = result.data;
      });
  }

}
