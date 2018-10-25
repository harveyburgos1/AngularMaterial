import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { OrderDetail } from '../../../domain/orderdetail';
// import { Order } from '../../domain/order';
import { Product } from '../../../domain/product';
import { ProductService } from '../../../services/product.service';
import { OrderService } from '../../../services/order.services';
import { OrderDetailService } from '../../../services/orderdetail.service';
// import { OrderService } from '../../services/order.service';
// import { OrderDetailService } from '../../services/orderDetail.service';

@Component({
  selector: 'app-order-detail;',
  templateUrl: './order-detail.component.html',
  styleUrls: ['./order-detail.component.css'],
  providers: [ProductService,OrderDetailService]
  // OrderService, OrderDetailService

})
export class OrderDetailComponent implements OnInit {
  selectOrderDetail: OrderDetail = {} as OrderDetail;
  // orderList: Order[];
  selectProduct: Product;
  productList: Product[];
  // isAddOrderDetail: boolean;
  // isDeleteOrderDetail: boolean;
  // indexOfOrderDetail: number=0;


  constructor(private fb: FormBuilder, private productService: ProductService, private orderDetailService: OrderDetailService) {}
  // , private orderDetailService: OrderDetailService, private orderService: OrderService

  //Child from the order component html //Passive values
  @Input() orderDetailFormGroup; FormGroup;
  @Input() orderID:string;
  @Output() saveEvent = new EventEmitter();
  ngOnInit() {
    this.loadAllOrderDetails();
    console.log(this.orderID);
    this.orderDetailService.getOrderDetailWithID(this.orderID).then(result => {
      this.selectOrderDetail = result;
      this.selectProduct = this.selectOrderDetail.productID;
    })
  }


  loadAllOrderDetails(){
    this.productService.getProduct().then(product => {
      this.productList=product;
      console.log(this.productList)
    });
  }

  callingSaveEvent(){
    this.saveEvent.emit();
  }

}