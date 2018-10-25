import { Component, OnInit, ViewChild } from '@angular/core';
import { Customer } from '../../domain/customer';
import { CustomerService } from '../../services/customer.services';
import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { DataTable } from 'primeng/primeng';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css'],
  providers: [CustomerService]

})
export class CustomerComponent implements OnInit {
  customerList: Customer[];
  selectCustomer: Customer;
  customerForm: FormGroup;
  isAddCustomer: boolean;
  indexOfCustomer: number = 0;
  isDeleteCustomer: boolean;
  totalRecords:number=0;
  searchCustomerName: string ="";

  constructor(private customerService: CustomerService, private fb: FormBuilder) { }

  ngOnInit() {
    this.customerForm = this.fb.group({
      'companyName': new FormControl('', Validators.required),
      'contactName': new FormControl('', Validators.required),
      'contactTitle': new FormControl('', Validators.required),
      'address': new FormControl('', Validators.required),
      'city': new FormControl('', Validators.required),
      'region': new FormControl('', Validators.required),
      'postalCode': new FormControl('', Validators.required),
      'country': new FormControl('', Validators.required),
      'phone': new FormControl('', Validators.required),
      'fax': new FormControl('', Validators.required)
    })
    this.loadAllCustomers();
  }

  @ViewChild('dt') public dataTable: DataTable;

  loadAllCustomers() {
    this.customerService.getCustomer().then(result => {
      this.customerList = result;
    });
  }
  
  paginate($event){
    this.customerService.getCustomerWithPagination($event.first, $event.rows,this.searchCustomerName)
    .then(result => {
      this.totalRecords = result.totalRecords;
      this.customerList = result.results;
     });
  }
  searchCustomer(){
    if(this.searchCustomerName.length != 1){
        this.resetTable();
    }
  }

    
  resetTable(){
    this.dataTable.reset();
  }
  addCustomer() {
    this.customerForm.enable();

    this.isAddCustomer = true;
    this.isDeleteCustomer = false;
    this.selectCustomer = {} as Customer;
  }

  saveCustomer() {
    let tmpCustomerList = [...this.customerList];
    if (this.isAddCustomer === true) {
      this.customerService.addCustomer(this.selectCustomer).then(result => {
        tmpCustomerList.push(result);
        this.customerList = tmpCustomerList;
        this.selectCustomer = null;
      });
    }
    else {
      this.customerService.editCustomer(this.selectCustomer.customerID, this.selectCustomer)
        .then(result => {
          tmpCustomerList[this.indexOfCustomer] = result;
          this.customerList = tmpCustomerList;
          this.selectCustomer = null;
        });
    }
  }

  editCustomer(Customer) {
    this.customerForm.enable();

    this.isAddCustomer = false;
    this.isDeleteCustomer = false;
    this.indexOfCustomer = this.customerList.indexOf(Customer);
    this.selectCustomer = Customer;
    this.selectCustomer = Object.assign({}, this.selectCustomer);
  }

  cancelCustomer(Customer) {
    this.selectCustomer = null;
  }
  deleteCustomer(Customer){
    this.isDeleteCustomer = true;
    this.indexOfCustomer = this.customerList.indexOf(Customer);
    this.selectCustomer = Customer;
    this.selectCustomer = Object.assign({}, this.selectCustomer);
  }

  okDeleteCustomer(){
    this.customerForm.disable();

    let tmpCustomerList = [...this.customerList];
    this.customerService.deleteCustomer(this.selectCustomer.customerID).then(() => {
        tmpCustomerList.splice(this.indexOfCustomer, 1);
        this.customerList = tmpCustomerList;
        this.selectCustomer= null;
    });
  }
}
