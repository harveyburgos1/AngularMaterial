import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-departments',
  templateUrl: './departments.component.html'
})
export class DepartmentsComponent {
  public departments: Department[];

  constructor(http: HttpClient) {
    http.get<Department[]>('https://localhost:44351/api/departments')
        .subscribe(result => {
      this.departments = result;
    }, error => console.error(error));
  }
}

interface Department {
  departmentID: string;
  departmentName: string;
  isActive: boolean;
  
}
