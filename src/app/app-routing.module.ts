import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MaterialsComponent } from './components/materials/materials.component';
import { PlansComponent } from './components/plans/plans.component';
import { BuildingObjectsComponent } from './components/building-objects/building-objects.component';
import { ProvidersComponent } from './components/providers/providers.component';
import { WorkersComponent } from './components/workers/workers.component';
import { WorkersSalariesComponent } from './components/workers-salaries/workers-salaries.component';
import { ErrorComponent } from './components/error/error.component';
import { OrdersComponent } from './components/orders/orders.component';

const routes: Routes = [
  { path: '', redirectTo: "/buildingObjects", pathMatch: 'full' },
  { path: 'buildingObjects', component: BuildingObjectsComponent },
  { path: "buildingObjects/:id/orders", component: OrdersComponent },
  { path: "buildingObjects/:id/orders/:orderId/materials", component: MaterialsComponent },
  { path: "buildingObjects/:id/orders/:orderId/materials/add", component: MaterialsComponent },
  { path: "buildingObjects/:id/providers", component: ProvidersComponent },
  { path: "buildingObjects/:id/providers/add", component: ProvidersComponent },
  { path: "providers/:providerId/materials", component: MaterialsComponent },
  { path: "providers/:providerId/materials/add", component: MaterialsComponent },
  { path: 'plans', component: PlansComponent },
  { path: "materials", component: MaterialsComponent },
  { path: "providers", component: ProvidersComponent },
  { path: "workers", component: WorkersComponent },
  { path: "workers-salaries", component: WorkersSalariesComponent },
  { path: "error", component: ErrorComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
