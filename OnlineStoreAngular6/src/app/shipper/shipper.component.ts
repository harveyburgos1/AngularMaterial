import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { DataTable } from 'primeng/primeng';
import { ShipperService } from '../../services/shipper.services';
import { Shipper } from '../../domain/shipper';

@Component({
  selector: 'app-shipper',
  templateUrl: './shipper.component.html',
  styleUrls: ['./shipper.component.css'],
  providers: [ShipperService]

})
export class ShipperComponent implements OnInit {
  shipperList:Shipper[];
  selectShipper: Shipper;
  shipperForm:FormGroup;
  isAddShipper: boolean;
  isDeleteShipper: boolean;
  indexOfShipper: number = 0;
  searchShipperName: string ="";
  totalRecords:number=0;

  constructor(private shipperService: ShipperService, private fb: FormBuilder) { }

  ngOnInit() {
    this.shipperForm = this.fb.group({
      'companyName': new FormControl('', Validators.required),
      'phone': new FormControl('', Validators.required)
    })
  }
  @ViewChild('dt') public dataTable: DataTable;

  //#region Misc
  cancelShipper(Shipper){
    this.selectShipper = null;
  }
  
  resetTable(){
    this.dataTable.reset();
}
  //#endregion 

  loadAllShipper() {
    this.shipperService.getShipper().then(result => {
      this.shipperList = result
    });
  }

  paginate($event){
    this.shipperService.getShipperWithPagination($event.first, $event.rows,this.searchShipperName)
    .then(result => {
      this.totalRecords = result.totalRecords;
      this.shipperList = result.results;
     });
  }

  
  addShipper() {
    this.shipperForm.enable();
    this.isAddShipper = true;
    this.isDeleteShipper = false;
    this.selectShipper = {} as Shipper;
  }

  saveShipper() {
    this.shipperForm.enable();
    let tmpShipperList = [...this.shipperList];
    if (this.isAddShipper === true) {
      this.shipperService.addShipper(this.selectShipper).then(result => {
        tmpShipperList.push(result);
        this.shipperList = tmpShipperList;
        this.selectShipper = null;
      });
    }
    else{
      this.shipperService.editShipper(this.selectShipper.shipperID, this.selectShipper)
      .then(result => {
      tmpShipperList[this.indexOfShipper] = result;
        this.shipperList = tmpShipperList;
        this.selectShipper = null;
      });
    }
  }

  editShipper(Shipper) {
    this.isAddShipper = false;
    this.isDeleteShipper = false;
    this.indexOfShipper = this.shipperList.indexOf(Shipper);
    this.selectShipper = Shipper;
    this.selectShipper = Object.assign({}, this.selectShipper);
  }

  deleteShipper(Shipper){
    this.shipperForm.disable();
    this.isDeleteShipper = true;
    this.indexOfShipper= this.shipperList.indexOf(Shipper);
    this.selectShipper = Shipper;
    this.selectShipper = Object.assign({}, this.selectShipper);
  }

  okDelete(){
    let tmpShipperList = [...this.shipperList];
    this.shipperService.deleteShipper(this.selectShipper.shipperID).then(() => {
        tmpShipperList.splice(this.indexOfShipper, 1);
        this.shipperList = tmpShipperList;
        this.selectShipper = null;
    });
  }

  searchShipper(){
    if(this.searchShipperName.length != 1){
        this.resetTable();
    }
  }
}
