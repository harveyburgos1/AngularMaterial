import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { DataTable } from 'primeng/primeng';
import { SupplierService } from '../../services/supplier.services';
import { Supplier } from '../../domain/supplier';


@Component({
  selector: 'app-supplier',
  templateUrl: './supplier.component.html',
  styleUrls: ['./supplier.component.css'],
  providers: [SupplierService]
  
})
export class SupplierComponent implements OnInit {
  supplierList:Supplier[];
  selectSupplier: Supplier;
  supplierForm:FormGroup;
  isAddSupplier: boolean;
  isDeleteSupplier: boolean;
  indexOfSupplier: number = 0;
  searchSupplierName: string ="";
  totalRecords:number=0;

  constructor(private supplierService: SupplierService, private fb: FormBuilder) { }

  ngOnInit() {
    this.supplierForm = this.fb.group({
      'companyName': new FormControl('', Validators.required),
      'contactName': new FormControl('', Validators.required),
      'contactTitle': new FormControl('', Validators.required),
      'address': new FormControl('', Validators.required),
      'city': new FormControl('', Validators.required),
      'region': new FormControl('', Validators.required),
      'postalCode': new FormControl('', Validators.required),
      'country': new FormControl('', Validators.required),
      'phone': new FormControl('', Validators.required),
      'fax': new FormControl('', Validators.required),
      'homePage': new FormControl('', Validators.required)
    })
  }
  @ViewChild('dt') public dataTable: DataTable;

  loadAllSuppliers(){
     this.supplierService.getSupplier().then(result => {       
        this.supplierList = result;
  });
  }

  paginate($event){
    this.supplierService.getSupplierWithPagination($event.first, $event.rows,this.searchSupplierName)
    .then(result => {
      this.totalRecords = result.totalRecords;
      this.supplierList = result.results;
     });
  }

  addSupplier(){
    this.supplierForm.enable();
    this.isAddSupplier = true;
    this.isDeleteSupplier = false;
    this.selectSupplier = {} as Supplier;
  }


  saveSupplier(){
    
    let tmpSupplierList = [...this.supplierList];
    if (this.isAddSupplier === true) {
      this.supplierService.addSupplier(this.selectSupplier).then(result => {      
        tmpSupplierList.push(result);
        this.supplierList = tmpSupplierList;
        this.selectSupplier = null;
        
      });
    }
    else {
      this.supplierService.editSupplier(this.selectSupplier.supplierID, this.selectSupplier)
        .then(result => {
          tmpSupplierList[this.indexOfSupplier] = result;
          this.supplierList = tmpSupplierList;
          this.selectSupplier = null;
        });
    }
  }

  editSupplier(Supplier) {
    this.supplierForm.enable();

    this.isAddSupplier = false;
    this.isDeleteSupplier = false;
    this.indexOfSupplier = this.supplierList.indexOf(Supplier);
    this.selectSupplier = Supplier;
    this.selectSupplier = Object.assign({}, this.selectSupplier);

  }

  cancelSupplier(Supplier) {
    this.selectSupplier = null;
  }
  deleteSupplier(Supplier){
    this.supplierForm.disable();

    this.isDeleteSupplier = true;
    this.indexOfSupplier = this.supplierList.indexOf(Supplier);
    this.selectSupplier = Supplier;
    this.selectSupplier = Object.assign({}, this.selectSupplier);
  }

  okDeleteSupplier(){
    let tmpSupplierList = [...this.supplierList];
    this.supplierService.deleteSupplier(this.selectSupplier.supplierID).then(() => {
        tmpSupplierList.splice(this.indexOfSupplier, 1);
        this.supplierList = tmpSupplierList;
        this.selectSupplier= null;
    });
  }
}
