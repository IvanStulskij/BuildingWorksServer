import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BuildingObjectsComponent } from './components/building-objects/building-objects.component';
import { HttpClientModule } from '@angular/common/http'
import { PlansComponent } from './components/plans/plans.component';
import { BrigadesComponent } from './components/brigades/brigades.component';
import { MaterialsComponent } from './components/materials/materials.component';
import { ProvidersComponent } from './components/providers/providers.component';
import { WorkersComponent } from './components/workers/workers.component';
import { WorkersSalariesComponent } from './components/workers-salaries/workers-salaries.component';
import { ErrorComponent } from './components/error/error.component';
import { BuildingObjectService } from './services/building-object.service';
import { PlansService } from './services/plans.service';
import { BrigadesService } from './services/brigades.service';
import { MaterialsService } from './services/materials.service';
import { ProvidersService } from './services/providers.service';
import { WorkersService } from './services/workers.service';
import { WorkersSalariesService } from './services/workers-salaries.service';
import { AgGridModule } from 'ag-grid-angular';
import { StoreModule } from '@ngrx/store';
import { appReducers } from './store/reducers/app.reducer';
import { EffectsModule } from '@ngrx/effects';
import { BuildingObjectEffects } from './store/effects/building-object.effects';
import { StoreRouterConnectingModule } from '@ngrx/router-store';
import { environment } from 'src/environments/environment';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { BuildingObjectCardComponent } from './components/building-objects/building-object-card/building-object-card.component';
import { MatIconModule } from '@angular/material/icon';
import { DeleteMenuComponent } from './components/delete-menu/delete-menu.component'
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDialogModule } from '@angular/material/dialog';
import { PlanEffects } from './store/effects/plan.effects';
import { ProviderEffects } from './store/effects/provider.effects';
import { WorkerEffects } from './store/effects/worker.effects';
import { WorkerCardComponent } from './components/workers/worker-card/worker-card.component';
import { ProviderCardComponent } from './components/providers/provider-card/provider-card.component';
import { MaterialCardComponent } from './components/materials/material-card/material-card.component';
import { MaterialEffects } from './store/effects/material.effects';
import { TabsComponent } from './components/tabs/tabs.component';
import { MatTabsModule } from '@angular/material/tabs';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatTableModule } from '@angular/material/table';
import { RouterLink } from '@angular/router';
import { ShortInfosComponent } from './components/short-infos/short-infos.component';
import { NotifierModule } from 'angular-notifier';
import { DictionaryEffects } from './store/effects/dictionary.effects';
import { MatSelectModule } from '@angular/material/select';
import { BuildingObjectProviderEffects } from './store/effects/building-object-provider.effects';
import { ProviderMaterialEffects } from './store/effects/provider-material.effects';
import { OrderEffects } from './store/effects/order.effects';
import { OrdersComponent } from './components/orders/orders.component';
import { OrdersService } from './services/order.service';
import { OrderCardComponent } from './components/orders/order-card/order-card.component';
import { OrderMaterialComponent } from './components/orders/order-material/order-material.component';
import { MatDatepickerModule } from '@angular/material/datepicker';

@NgModule({
  declarations: [
    AppComponent,
    BuildingObjectsComponent,
    PlansComponent,
    BrigadesComponent,
    MaterialsComponent,
    PlansComponent,
    ProvidersComponent,
    WorkersComponent,
    WorkersSalariesComponent,
    BuildingObjectCardComponent,
    ErrorComponent,
    DeleteMenuComponent,
    WorkerCardComponent,
    ProviderCardComponent,
    MaterialCardComponent,
    TabsComponent,
    ShortInfosComponent,
    OrdersComponent,
    OrderCardComponent,
    OrderMaterialComponent,
  ],
  imports: [
    MatDatepickerModule,
    MatSelectModule,
    RouterLink,
    MatTableModule,
    MatCheckboxModule,
    MatTabsModule,
    MatDialogModule,
    BrowserModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule,
    MatIconModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    AgGridModule,
    MatCardModule,
    NotifierModule,
    FormsModule,
    StoreModule.forRoot(appReducers),
    EffectsModule.forRoot([BuildingObjectEffects, PlanEffects, ProviderEffects, WorkerEffects, MaterialEffects, DictionaryEffects, BuildingObjectProviderEffects, ProviderMaterialEffects, OrderEffects ]),
    StoreRouterConnectingModule.forRoot({ stateKey: 'router' }),
    !environment.production? StoreDevtoolsModule.instrument() : [],
  ],
  providers: [
    BuildingObjectService,
    PlansService,
    BrigadesService,
    MaterialsService,
    PlansService,
    ProvidersService,
    WorkersService,
    WorkersSalariesService,
    OrdersService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
