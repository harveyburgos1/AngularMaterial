import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { PaginationResult } from "../domain/paginationresult";
import { Order } from "../domain/order";

@Injectable()

export class OrderService{

    constructor(private http: HttpClient){}

    getOrder(){
        return this.http.get("https://localhost:5001/api/Order")
        .toPromise()
        .then(data=> { return data as Order[]});
    }

    addOrder(objEntity: Order){

        return this.http.post("https://localhost:5001/api/Order",objEntity)
        .toPromise()
        .then(data=> { return data as Order});
    }

    editOrder(id,objEntity: Order){
        return this.http.put("https://localhost:5001/api/Order/"+id,objEntity)
        .toPromise()
        .then(data=>{ return data as Order});
    }

    deleteOrder(id){
        return this.http.delete("https://localhost:5001/api/Order/"+id)
        .toPromise()
        .then(() => null);
    }

}