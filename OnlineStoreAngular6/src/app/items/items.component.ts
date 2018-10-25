import { Component, OnInit, ViewChild } from '@angular/core';
import { ItemsService } from '../../services/items.services';
import { Item } from '../../domain/item';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { DataTable } from 'primeng/primeng';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.css'],
  providers: [ItemsService]
})
export class ItemsComponent implements OnInit {
  itemsList:Item[];
  selectItem: Item;
  itemsForm:FormGroup;
  isAddItem: boolean;
  isDeleteItem: boolean;
  indexOfItem: number = 0;
  searchItemName: string ="";
  totalRecords:number=0;
  
  constructor(private itemsService: ItemsService, private fb: FormBuilder) { }

  ngOnInit() {
    this.itemsForm = this.fb.group({
      'name': new FormControl('', Validators.required),
      'type': new FormControl('', Validators.required),
      'description': new FormControl('', Validators.required),
      'cost': new FormControl('', Validators.required),
      'cooldown': new FormControl('', Validators.required),
      'isChanneling': new FormControl('', Validators.required),
      'isDisassemble': new FormControl('', Validators.required),
      'isTargetable': new FormControl('', Validators.required),
      'upgradeLevel': new FormControl('')
    })
     // this.loadAllItems();
  }

  @ViewChild('dt') public dataTable: DataTable;

  //#region Misc
  cancelItem(Item){
    this.selectItem = null;
  }
  
  resetTable(){
    this.dataTable.reset();
}
  //#endregion 

  loadAllItems() {
    this.itemsService.getItems().then(result => {
      this.itemsList = result
    });
  }

  paginate($event){
    this.itemsService.getItemsWithPagination($event.first, $event.rows,this.searchItemName)
    .then(result => {
      this.totalRecords = result.totalRecords;
      this.itemsList = result.results;
     });
  }

  
  addItem() {
    this.itemsForm.enable();
    this.isAddItem = true;
    this.isDeleteItem = false;
    this.selectItem = {} as Item;
  }

  saveItem() {
    this.itemsForm.enable();
    let tmpItemsList = [...this.itemsList];
    if (this.isAddItem === true) {
      this.itemsService.addItem(this.selectItem).then(result => {
        tmpItemsList.push(result);
        this.itemsList = tmpItemsList;
        this.selectItem = null;
      });
    }
    else{
      this.itemsService.editItem(this.selectItem.itemID, this.selectItem)
      .then(result => {
      tmpItemsList[this.indexOfItem] = result;
        this.itemsList = tmpItemsList;
        this.selectItem = null;
      });
    }
  }

  editItem(Item) {
    this.isAddItem = false;
    this.isDeleteItem = false;
    this.indexOfItem = this.itemsList.indexOf(Item);
    this.selectItem = Item;
    this.selectItem = Object.assign({}, this.selectItem);
  }

  deleteItem(Item){
    this.itemsForm.disable();
    this.isDeleteItem = true;
    this.indexOfItem= this.itemsList.indexOf(Item);
    this.selectItem = Item;
    this.selectItem = Object.assign({}, this.selectItem);
  }

  okDelete(){
    let tmpItemsList = [...this.itemsList];
    this.itemsService.deleteItem(this.selectItem.itemID).then(() => {
        tmpItemsList.splice(this.indexOfItem, 1);
        this.itemsList = tmpItemsList;
        this.selectItem = null;
    });
  }

  searchItem(){
    if(this.searchItemName.length != 1){
        this.resetTable();
    }
  }
}
