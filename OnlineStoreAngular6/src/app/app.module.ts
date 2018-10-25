import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SampleComponent } from './sample/sample.component';

import { ButtonModule } from 'primeng/button';
import { CategoryComponent } from './category/category.component';
import { TableModule } from 'primeng/table';
import { DataTableModule, InputTextModule, InputTextareaModule } from 'primeng/primeng';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DialogModule } from 'primeng/dialog';
import { CalendarModule } from 'primeng/calendar';
import { MenuModule } from 'primeng/menu';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';
import { CustomerComponent } from './customer/customer.component';
import { EmployeeComponent } from './employee/employee.component';
import { HeroesComponent } from './heroes/heroes.component';
import { ItemsComponent } from './items/items.component';
import { RadioButtonModule } from 'primeng/radiobutton';
import { ShipperComponent } from './shipper/shipper.component';
import { SupplierComponent } from './supplier/supplier.component';
import { ProductComponent } from './product/product.component';
import { DropdownModule } from 'primeng/dropdown';
import { OrderComponent } from './order/order.component';
import { OrderDetailComponent } from './order/order-detail/order-detail.component';
import {NgxMaskModule} from 'ngx-mask'
import {
  MatAutocompleteModule,
  MatButtonModule,
  MatButtonToggleModule,
  MatCardModule,
  MatCheckboxModule,
  MatChipsModule,
  MatDatepickerModule,
  MatDialogModule,
  MatExpansionModule,
  MatFormFieldModule,
  MatGridListModule,
  MatIconModule,
  MatInputModule,
  MatListModule,
  MatMenuModule,
  MatPaginatorModule,
  MatProgressBarModule,
  MatProgressSpinnerModule,
  MatRadioModule,
  MatSelectModule,
  MatSidenavModule,
  MatSliderModule,
  MatSlideToggleModule,
  MatSnackBarModule,
  MatSortModule,
  MatTableModule,
  MatTabsModule,
  MatToolbarModule,
  MatTooltipModule,
  MatStepperModule,
  MatNativeDateModule
} from '@angular/material';
import { PersonComponent } from './person/person.component';
import { TrainingComponent } from './training/training.component';

@NgModule({
  declarations: [
    AppComponent,
    SampleComponent,
    CategoryComponent,
    CustomerComponent,
    EmployeeComponent,
    HeroesComponent,
    ItemsComponent,
    ShipperComponent,
    SupplierComponent,
    ProductComponent,
    OrderComponent,
    OrderDetailComponent,
    PersonComponent,
    TrainingComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ButtonModule,
    TableModule,
    DataTableModule,
    HttpModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    InputTextModule,
    InputTextareaModule,
    DialogModule,
    BrowserAnimationsModule,
    CalendarModule,
    MenuModule,
    CommonModule,
    RadioButtonModule,
    DropdownModule,
    MatAutocompleteModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatDatepickerModule,
    MatDialogModule,
    MatExpansionModule,
    MatFormFieldModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatRadioModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSortModule,
    MatTableModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule,
    MatStepperModule,
    MatNativeDateModule,
    NgxMaskModule.forRoot()


  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
