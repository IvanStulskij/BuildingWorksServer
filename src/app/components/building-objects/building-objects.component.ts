import { Component, OnInit } from '@angular/core';
import { IAppState } from 'src/app/store/states/app.state';
import { Store, select } from "@ngrx/store";
import { DeleteBuildingObject, GetBuildingObjects } from 'src/app/store/actions/building-object.actions';
import { selectBuildingObjectList } from 'src/app/store/selectors/building-object.selector';
import { MatDialog } from '@angular/material/dialog';
import { BuildingObjectCardComponent } from './building-object-card/building-object-card.component';
import { MatTableDataSource } from '@angular/material/table';
import { BuildingObject } from 'src/app/types/building-objects';
import { Observable, map } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-building-objects',
  templateUrl: './building-objects.component.html',
  styleUrls: ['./building-objects.component.scss']
})
export class BuildingObjectsComponent implements OnInit {
  displayedColumns: string[] = ['objectName', 'objectCustomer', 'executorCompany', 'actions', 'selectProviders', 'selectOrders'];

  private dataSource = new MatTableDataSource<BuildingObject>();

  buildingObjects$: Observable<MatTableDataSource<BuildingObject>> = this.store.pipe(select(selectBuildingObjectList), map(buildingObject => {
    const dataSource = this.dataSource;
    dataSource.data = buildingObject;

    return dataSource;
  }));

  constructor(private store: Store<IAppState>, private dialog: MatDialog, private route: Router) { }

  ngOnInit(): void {
    this.store.dispatch(new GetBuildingObjects());
  }

  navigateToBuildingObject(id: string) : void {
    this.dialog.open(BuildingObjectCardComponent, {
      width: '500px',
      height: '500px',
      data: id
    });
  }

  navigateToCreateWindow() : void {
    this.dialog.open(BuildingObjectCardComponent, {
      width: '500px',
      height: '500px',
    })
  }

  deleteBuildingObject(id: string) : void {
    this.store.dispatch(new DeleteBuildingObject(id));
  }
}
