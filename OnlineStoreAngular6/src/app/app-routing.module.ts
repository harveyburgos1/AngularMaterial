import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CategoryComponent } from './category/category.component';
import { CustomerComponent } from './customer/customer.component';
import { EmployeeComponent } from './employee/employee.component';
import { HeroesComponent } from './heroes/heroes.component';
import { ItemsComponent } from './items/items.component';
import { ShipperComponent } from './shipper/shipper.component';
import { ProductComponent } from './product/product.component';
import { SupplierComponent } from './supplier/supplier.component';
import { OrderComponent } from './order/order.component';
import { PersonComponent } from './person/person.component';
import { TrainingComponent } from './training/training.component';

const routes: Routes = [
  {path: '', redirectTo: '/Training', pathMatch:'full'},
  // {path: 'category', component: CategoryComponent},
  // {path: 'customer', component: CustomerComponent},
  // {path: 'employee', component:  EmployeeComponent},
  // {path: 'shipper', component:  ShipperComponent},
  // {path: 'supplier', component:  SupplierComponent},
  // {path: 'product', component:  ProductComponent},
  // {path: 'order', component:  OrderComponent},
  // {path: 'person', component: PersonComponent},
  {path: 'Training', component: TrainingComponent}





];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
