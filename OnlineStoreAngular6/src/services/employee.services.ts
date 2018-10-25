import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Employee } from "../domain/employee";
import { PaginationResult } from "../domain/paginationresult";

@Injectable()

export class EmployeeService{
    constructor(private http: HttpClient){}


    getEmployeeWithPagination(page:number, itemsPerPage:number, filter:string){
        return this.http.get("https://localhost:5001/api/Employee/"+page + "/" + itemsPerPage + "?filter=" + filter)
        .toPromise()
        .then(data => { return data as PaginationResult<Employee>});
    }

        getEmployee(){
            return this.http.get("https://localhost:5001/api/Employee")
            .toPromise()
            .then(data=>{return data as Employee[]});
        }

        addEmployee(objEntity:Employee){
            return this.http.post("https://localhost:5001/api/Employee",objEntity)
            .toPromise()
            .then(data=>{ return data as Employee});
        }

        editEmployee(id,objEntity:Employee){
            return this.http.put("https://localhost:5001/api/Employee/"+id,objEntity)
            .toPromise()
            .then(data=>{ return data as Employee})
        }

        deleteEmployee(id){
            return this.http.delete("https://localhost:5001/api/Employee/"+id)
            .toPromise()
            .then(() => null);
        }
    }
