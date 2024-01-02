import { Component, OnInit } from '@angular/core';
import { IAppState } from 'src/app/store/states/app.state';
import { Store, select } from "@ngrx/store";
import { DeleteBuildingObject, GetBuildingObjects } from 'src/app/store/actions/building-object.actions';
import { selectBuildingObjectList } from 'src/app/store/selectors/building-object.selector';
import { MatDialog } from '@angular/material/dialog';
import { BuildingObjectCardComponent } from './building-object-card/building-object-card.component';
import { MatTableDataSource } from '@angular/material/table';
import { BuildingObject } from 'src/app/types/building-objects';
import { BehaviorSubject, Observable, Subject, map } from 'rxjs';
import { DefaultItemsPerPage } from 'src/app/constants';
import { FilterDefinition, LoadConditions, SortDefinition } from 'src/app/types/loader';

@Component({
  selector: 'app-building-objects',
  templateUrl: './building-objects.component.html',
  styleUrls: ['./building-objects.component.scss']
})
export class BuildingObjectsComponent implements OnInit {
  currentPage: number = 1;
  filterDefinitions: FilterDefinition[] = [];
  sorter!: SortDefinition | null;
  filterValue: string = "";
  selectedProperty!: string;
  loadConditions!: LoadConditions;
  properties!: string[];

  displayedColumns: string[] = ['objectName', 'objectCustomer', 'executorCompany', 'actions', 'selectProviders', 'selectOrders'];
  sortAsc: boolean = true;
  filterProperty: string = "";
  example: BuildingObject = {
    id: "",
    executorCompany: "",
    buildingObjectType: 0,
    buildingObjectTypeName: "",
    objectCustomer: "",
    objectName: ""
  };

  private dataSource = new MatTableDataSource<BuildingObject>();

  buildingObjects$: Observable<MatTableDataSource<BuildingObject>> = this.store.pipe(select(selectBuildingObjectList), map(buildingObject => {
    const dataSource = this.dataSource;
    dataSource.data = buildingObject?.data!;
    
    return dataSource;
  }));

  constructor(private store: Store<IAppState>, private dialog: MatDialog) {
    this.loadConditions = {
      page: this.currentPage,
      pageSize: DefaultItemsPerPage,
      filter: null,
      sorter: null
    };
    this.properties = Object.keys(this.example);
  }

  ngOnInit(): void {
    this.store.dispatch(new GetBuildingObjects(this.loadConditions));
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

  applySorting(field: string) : void {
    this.sortAsc = !this.sortAsc;
    let order = this.sortAsc ? "asc" : "desc";
    this.filterProperty = field;
    this.sorter = {
      field: field,
      order: order
    };

    if (this.sorter) {
      this.store.dispatch(new GetBuildingObjects({
        page: this.currentPage,
        pageSize: DefaultItemsPerPage,
        filter: null,
        sorter: [this.sorter]
      }));
    }
  }

  clearSorting(field: string) : void {
    if (field == this.filterProperty) {
      this.filterProperty = "";
      this.sortAsc = true;
      this.sorter = null;
      this.updateLoadConditions();
      this.store.dispatch(new GetBuildingObjects(this.loadConditions));
    }
  }

  applyFilter() : void {
    this.updateLoadConditions();
    this.store.dispatch(new GetBuildingObjects(this.loadConditions));
  }

  addToFilter(property: string) : void {
    this.filterDefinitions.push({
      property: property,
      comparor: "=",
      value: ""
    });
    this.filterValue = "";
    this.selectedProperty = "";
  }

  removeFilterDefinition(property: string) : void {
    this.filterDefinitions = this.filterDefinitions.filter(filterDefinition => filterDefinition.property != property);
  }

  updateLoadConditions() : void {
    let filter: string[] = [];
    this.filterDefinitions.forEach(filterDefinition => {
      if (filterDefinition.value){
        filter.push(filterDefinition.property);
        filter.push(filterDefinition.comparor);
        filter.push(filterDefinition.value);
      }
    });

    if (this.sorter) {
      this.loadConditions = {
        page: this.currentPage,
        pageSize: DefaultItemsPerPage,
        filter: filter,
        sorter: [this.sorter!]
      };
    }
    else {
      this.loadConditions = {
        page: this.currentPage,
        pageSize: DefaultItemsPerPage,
        filter: filter,
        sorter: null
      };
    }
  }

  navigateNextPage() : void {
    this.currentPage++;
    this.updateLoadConditions();
    this.store.dispatch(new GetBuildingObjects(this.loadConditions));
  }

  navigatePreviousPage() : void {
    if (this.currentPage > 1){
      this.currentPage--;
      this.updateLoadConditions();
      this.store.dispatch(new GetBuildingObjects(this.loadConditions));
    }
  }
}
