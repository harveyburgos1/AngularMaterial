import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Order } from '../../domain/order';
import { OrderService } from '../../services/order.services';
import { Customer } from '../../domain/customer';
import { Employee } from '../../domain/employee';
import { Shipper } from '../../domain/shipper';
import { CustomerService } from '../../services/customer.services';
import { EmployeeService } from '../../services/employee.services';
import { ShipperService } from '../../services/shipper.services';
import { OrderDetail } from '../../domain/orderdetail';
import { OrderDetailService } from '../../services/orderdetail.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css'],
  providers: [OrderService, EmployeeService, CustomerService, ShipperService,OrderDetailService]
})
export class OrderComponent implements OnInit {
  orderFormGroup: FormGroup;
  orderDetailFormGroup:FormGroup;
  selectOrder: Order;
  selectCustomer: Customer;
  selectEmployee: Employee;
  selectShipper: Shipper;
  customerList: Customer[];
  employeeList: Employee[];
  shipperList: Shipper[];
  orderList: Order[];
  indexOfOrder:number = 0;

  isAddOrder:boolean;
  isDeleteOrder:boolean;

  selectOrderDetail:OrderDetail;

  constructor(private orderService: OrderService, private fb: FormBuilder, private customerService: CustomerService,
    private employeeService: EmployeeService, private shipperService: ShipperService, private orderDetailService: OrderDetailService) { }


  ngOnInit() {
    this.orderFormGroup = this.fb.group({
      'shipName': new FormControl('', Validators.required),
      'shipAddress': new FormControl('', Validators.required),
      'shipCity': new FormControl('', Validators.required),
      'shipRegion': new FormControl('', Validators.required),
      'shipPostalCode': new FormControl('', Validators.required),
      'shipCountry': new FormControl('', Validators.required),
      'freight': new FormControl('', Validators.required),
      'orderDate': new FormControl('', Validators.required),
      'requiredDate': new FormControl('', Validators.required),
      'shippedDate': new FormControl('', Validators.required),
      'customerName': new FormControl('', Validators.required),
      'firstName': new FormControl('', Validators.required),
      'companyName': new FormControl('', Validators.required)
    });
  

    this.orderDetailFormGroup = this.fb.group({
      productName: ['', Validators.required],
      orderDetailID: ['', Validators.required],
      orderLineID: ['', Validators.required],
      orderID: ['', Validators.required],
      productID: ['', Validators.required],
      unitPrice: ['', Validators.required],
      quantity: ['', Validators.required],
      discount: ['', Validators.required]
    });

    this.loadAllOrders();
  }

  cancelOrder(Order) {
    this.selectOrder = null;
  }

  loadAllOrders() {
    this.customerService.getCustomer().then(customers => {
      console.log(customers);
      this.customerList = customers;

      this.employeeService.getEmployee().then(employees => {
        this.employeeList = employees;

        this.shipperService.getShipper().then(shippers => {
          this.shipperList = shippers;

          this.orderService.getOrder().then(orders => {
            this.orderList = orders;     


            for(let i = 0; i < this.orderList.length; i++) {
              this.orderList[i].customerName = this.customerList.find(x => x.customerID == this.orderList[i].customerID).companyName;
              this.orderList[i].employeeName = this.employeeList.find(x => x.employeeID == this.orderList[i].employeeID).firstName;
              this.orderList[i].shipViaName = this.shipperList.find(x => x.shipperID == this.orderList[i].shipperID).companyName;
            }

          });
        });
      });
    });
  }

  addOrder() {
    this.orderFormGroup.enable();
    this.isAddOrder = true;
    this.isDeleteOrder = false;
    this.selectOrder= {} as Order;
    this.selectCustomer = {} as Customer;
    this.selectEmployee = {} as Employee;
    this.selectShipper = {} as Shipper;
    this.selectOrderDetail = {} as OrderDetail;
  }

  editOrder(Order) {
    this.isAddOrder = false;
    this.isDeleteOrder= false;
    this.indexOfOrder = this.orderList.indexOf(Order);

    this.orderDetailService.getOrderDetailWithID(Order.orderID).then(result => { this.selectOrderDetail = result; });
    this.selectOrder= Order;
    this.selectEmployee = this.selectOrder.employeeID;
    this.selectCustomer = this.selectOrder.customerID;
    this.selectShipper = this.selectOrder.shipperID;
    
    this.selectOrder= Object.assign({}, this.selectOrder);
  }

  deleteOrder(Order){
    this.orderFormGroup.disable();
    this.isDeleteOrder= true;
    this.indexOfOrder= this.orderList.indexOf(Order);
    this.selectOrder = Order;
    console.log(this.selectOrder);
    
    this.selectShipper = Order.shipperID;
    this.selectEmployee = this.selectOrder.employeeID;
    this.selectCustomer = this.selectOrder.customerID;
  
    this.selectOrder = Object.assign({}, this.selectOrder);
  }


  
  saveOrder($event) {
    this.selectOrder.employeeID = this.orderFormGroup.value.firstName;
    this.selectOrder.customerID = this.orderFormGroup.value.customerName;
    this.selectOrder.shipperID = this.orderFormGroup.value.companyName;


    this.orderFormGroup.enable();
    let tmpOrderList = [...this.orderList];
    if (this.isAddOrder === true) {
      this.orderService.addOrder(this.selectOrder).then(result => {
          result.customerName=this.customerList.find(x=>x.customerID==result.customerID).companyName;
          result.employeeName=this.employeeList.find(x=>x.employeeID==result.employeeID).firstName;
          result.shipViaName=this.shipperList.find(x=>x.shipperID==result.shipperID).companyName;
        
        tmpOrderList.push(result);
        this.orderList = tmpOrderList;

        this.selectOrderDetail.orderID = result.orderID;
        this.selectOrderDetail.discount = this.orderDetailFormGroup.value.discount;
        this.selectOrderDetail.orderLineID= this.orderDetailFormGroup.value.orderLineID;
        this.selectOrderDetail.productID = this.orderDetailFormGroup.value.productName;
        this.selectOrderDetail.quantity = this.orderDetailFormGroup.value.quantity;
        this.selectOrderDetail.unitPrice = this.orderDetailFormGroup.value.unitPrice;




        this.orderDetailService.addOrderDetail(this.selectOrderDetail)
        .then(resultOD => { this.selectOrder = null ;
        });
      });
    }
    else{
      this.orderService.editOrder(this.selectOrder.orderID, this.selectOrder)
      .then(result => {
        result.customerName=this.customerList.find(x=>x.customerID==result.customerID).companyName;
          console.log(this.customerList);
          result.employeeName=this.employeeList.find(x=>x.employeeID==result.employeeID).firstName;
          console.log(result.employeeName);
          result.shipViaName=this.shipperList.find(x=>x.shipperID==result.shipperID).companyName;
      tmpOrderList[this.indexOfOrder] = result;

        this.orderList = tmpOrderList;
        this.selectOrderDetail.orderID = result.orderID;
        this.selectOrderDetail.discount = this.orderDetailFormGroup.value.discount;
        this.selectOrderDetail.orderLineID= this.orderDetailFormGroup.value.orderLineID;
        this.selectOrderDetail.productID = this.orderDetailFormGroup.value.productName;
        this.selectOrderDetail.quantity = this.orderDetailFormGroup.value.quantity;
        this.selectOrderDetail.unitPrice = this.orderDetailFormGroup.value.unitPrice;




        this.orderDetailService.editOrderDetail(this.selectOrderDetail.orderDetailID,this.selectOrderDetail)
        .then(resultOD => { this.selectOrder = null ;
        });
      });
    }
  }


  okDelete(){
    let tmpOrderList = [...this.orderList];
    
    this.orderService.deleteOrder(this.selectOrder.orderID).then(() => {
        tmpOrderList.splice(this.indexOfOrder, 1);
        this.orderList = tmpOrderList;
        this.selectOrder= null;

    });
  }

}
