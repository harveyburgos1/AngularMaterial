import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Person } from "../domain/person";
import { PaginationResult } from "../domain/paginationresult";

@Injectable()

export class PersonService{

    constructor(private http: HttpClient){}
    getPersonsWithPagination(page, itemsPerPage,filter:string){
        return this.http.get("https://localhost:5001/api/Person/"+page + "/" + itemsPerPage + "?filter=" + filter)
        .toPromise()
        .then(data => { return data as PaginationResult<Person>});
    }
    getPersons(){
        return this.http.get("https://localhost:5001/api/Person")
        .toPromise()
        .then(data=> { return data as Person[]});
    }

    addPerson(person:Person){
        return this.http.post("https://localhost:5001/api/Person",person)
        .toPromise()
        .then(data => { return data as Person });
    }

    updatePerson(id,person:Person){
        return this.http.put("https://localhost:5001/api/Person/"+id,person)
        .toPromise()
        .then(data => { return data as Person});
    }

    deletePerson(id){
        return this.http.delete("https://localhost:5001/api/Person/"+id)
        .toPromise()
        .then(() => null);
    }
}