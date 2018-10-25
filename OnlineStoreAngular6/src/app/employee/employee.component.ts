import { Component, OnInit, ViewChild } from '@angular/core';
import { EmployeeService } from '../../services/employee.services';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { Employee } from '../../domain/employee';
import {DatePipe} from '@angular/common';
import { DataTable } from 'primeng/primeng';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css'],
  providers: [EmployeeService,DatePipe]
})
export class EmployeeComponent implements OnInit {
  employeeList: Employee[];
  selectEmployee: Employee;
  employeeForm: FormGroup;
  isAddEmployee: boolean;
  indexOfEmployee: number = 0;
  isDeleteEmployee:boolean;
  hireDate: Date;
  birthDate: Date;
  totalRecords:number=0;
  searchEmployeeName: string ="";

  constructor(private employeeService: EmployeeService, private fb: FormBuilder, private datePipe:DatePipe) { }

  ngOnInit() {
    this.employeeForm = this.fb.group({
      'firstName': new FormControl('', Validators.required),
      'lastName': new FormControl('', Validators.required),
      'title': new FormControl('', Validators.required),
      'titleOfCourtesy': new FormControl('', Validators.required),
      'birthDate': new FormControl('', Validators.required),
      'hireDate': new FormControl('', Validators.required),
      'address': new FormControl('', Validators.required),
      'city': new FormControl('', Validators.required),
      'region': new FormControl('', Validators.required),
      'postalCode': new FormControl('', Validators.required),
      'country': new FormControl('', Validators.required),
      'homePhone': new FormControl('', Validators.required),
      'extension': new FormControl('', Validators.required),
      'photos': new FormControl(''),
      'notes': new FormControl('', Validators.required),
      'reportsTo': new FormControl('', Validators.required)
    })
    this.loadAllEmployees();
  }
  @ViewChild('dt') public dataTable: DataTable;

  loadAllEmployees(){
     this.employeeService.getEmployee().then(result => {       
        this.employeeList = result;
    for (let i = 0; i < this.employeeList.length; i++) {
      this.employeeList[i].birthDate =
        this.datePipe.transform(this.employeeList[i].birthDate, 'yyyy-MM-dd');

      this.employeeList[i].hireDate =
        this.datePipe.transform(this.employeeList[i].hireDate, 'yyyy-MM-dd');
    }
  });
  }

  paginate($event){
    this.employeeService.getEmployeeWithPagination($event.first, $event.rows,this.searchEmployeeName)
    .then(result => {
      this.totalRecords = result.totalRecords;
      this.employeeList = result.results;
     });
  }

  addEmployee(){
    this.employeeForm.enable();
    this.isAddEmployee = true;
    this.isDeleteEmployee = false;
    this.selectEmployee = {} as Employee;
  }


  saveEmployee(){
    
    let tmpEmployeeList = [...this.employeeList];
    this.selectEmployee.birthDate = this.datePipe.transform(this.birthDate, 'yyyy-MM-dd');
    this.selectEmployee.hireDate = this.datePipe.transform(this.hireDate, 'yyyy-MM-dd');
    if (this.isAddEmployee === true) {
      this.employeeService.addEmployee(this.selectEmployee).then(result => {      
        tmpEmployeeList.push(result);
        this.employeeList = tmpEmployeeList;
        this.selectEmployee = null;
        
      });
    }
    else {
      this.employeeService.editEmployee(this.selectEmployee.employeeID, this.selectEmployee)
        .then(result => {
          result.birthDate = this.datePipe.transform(this.birthDate, 'yyyy-MM-dd');
          result.hireDate = this.datePipe.transform(this.hireDate, 'yyyy-MM-dd');
          tmpEmployeeList[this.indexOfEmployee] = result;
          this.employeeList = tmpEmployeeList;
          this.selectEmployee = null;
        });
    }
  }

  editEmployee(Employee) {
    this.employeeForm.enable();

    this.isAddEmployee = false;
    this.isDeleteEmployee = false;
    this.indexOfEmployee = this.employeeList.indexOf(Employee);
    this.selectEmployee = Employee;
    this.selectEmployee = Object.assign({}, this.selectEmployee);
    this.birthDate = new Date(this.selectEmployee.birthDate);
    this.hireDate = new Date(this.selectEmployee.hireDate);
  }

  cancelEmployee(Employee) {
    this.selectEmployee = null;
  }
  deleteEmployee(Employee){
    this.employeeForm.disable();

    this.isDeleteEmployee = true;
    this.indexOfEmployee = this.employeeList.indexOf(Employee);
    this.selectEmployee = Employee;
    this.selectEmployee = Object.assign({}, this.selectEmployee);
  }

  okDeleteEmployee(){
    let tmpEmployeeList = [...this.employeeList];
    this.employeeService.deleteEmployee(this.selectEmployee.employeeID).then(() => {
        tmpEmployeeList.splice(this.indexOfEmployee, 1);
        this.employeeList = tmpEmployeeList;
        this.selectEmployee= null;
    });
  }

}
