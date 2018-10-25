import { Component } from '@angular/core';
import {MenuItem} from 'primeng/api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  menuItems: MenuItem[];
  title = 'OnlineStoreAngular6';

  ngOnInit(): void{
    this.menuItems = [
      // { label: "Category", icon: "fa fa-calendar", routerLink: ['\category']},
      // { label: "Customer", icon: "fa fa-ban", routerLink: ['\customer']},
      // { label: "Employee",  icon: "fa fa-trash", routerLink:['\employee']},
      // { label: "Shipper",  icon: "fa fa-user", routerLink:['\shipper']},
      // { label: "Supplier",  icon: "fa fa-user", routerLink:['\supplier']},
      // { label: "Product",  icon: "fa fa-user", routerLink:['\product']},
      // { label: "Order",  icon: "fa fa-user", routerLink:['\order']},
      // { label: "Person",  icon: "fa fa-user", routerLink:['\person']},
      { label: "training",  icon: "fa fa-user", routerLink:['\Training']}





    ]
  }
}
