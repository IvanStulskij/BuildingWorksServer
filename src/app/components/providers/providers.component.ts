import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Store, select } from '@ngrx/store';
import { AddProviderToBuildingObject, DeleteProvider, GetProviders, GetProvidersByBuildingObject } from 'src/app/store/actions/provider.actions';
import { selectProviderList } from 'src/app/store/selectors/provider.selector';
import { IAppState } from 'src/app/store/states/app.state';
import { ProviderCardComponent } from './provider-card/provider-card.component';
import { MatTableDataSource } from '@angular/material/table';
import { Provider } from 'src/app/types/providers';
import { Observable, map } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { selectBuildingObjectProviderList } from 'src/app/store/selectors/building-object-provider.selector';

@Component({
  selector: 'app-providers',
  templateUrl: './providers.component.html',
  styleUrls: ['./providers.component.scss']
})

export class ProvidersComponent implements OnInit {
  displayedColumns: string[] = ['name', 'country', 'signer', 'addToBuildingObject', 'selectMaterials'];
  id: string | null;
  isAdd!: boolean;
  private dataSource = new MatTableDataSource<Provider>();
  
  providers$ : Observable<MatTableDataSource<Provider>> = new Observable<MatTableDataSource<Provider>>();

  constructor(private store: Store<IAppState>, private dialog: MatDialog, private activatedRoute: ActivatedRoute, private route: Router) {
    this.id = this.activatedRoute.snapshot.paramMap.get("id");

    this.isAdd = this.route.url.includes("add");
    let selector = select(selectProviderList);

    if (!this.isAdd) {
      if (this.route.url.includes("building-objects")) {
        selector = select(selectBuildingObjectProviderList);
      }
    }
    this.providers$ = this.store.pipe(selector, map(provider => {
      const dataSource = this.dataSource;
      dataSource.data = provider;
      return dataSource;
    }));
  }

  ngOnInit(): void {
    if (this.id) {
      if (this.isAdd) {
        this.store.dispatch(new GetProviders())
      }
      else {
        if (this.route.url.includes("building-objects")) {
          this.store.dispatch(new GetProvidersByBuildingObject(this.id));
        }
      }
    }
    else {
      this.store.dispatch(new GetProviders());
    }
  }

  navigateToProvider(id: string) : void {
    this.dialog.open(ProviderCardComponent, {
      width: '500px',
      height: '500px',
      data: {
        providerId: id
      }
    })
  }

  navigateToCreateWindow() : void {
    this.dialog.open(ProviderCardComponent, {
      width: '500px',
      height: '500px',
    })
  }

  deleteProvider(id: string) : void {
    this.store.dispatch(new DeleteProvider(id));
  }

  addToCollection(providerId: string) : void {
    if (this.route.url.includes("buildingObjects")) {
      this.store.dispatch(new AddProviderToBuildingObject({
        providersId: providerId,
        buildingObjectsId: this.id!
      }));
    }
  }
}
