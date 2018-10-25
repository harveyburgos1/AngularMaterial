import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Item } from "../domain/item";
import { PaginationResult } from "../domain/paginationresult";


@Injectable()


export class ItemsService{
    constructor(private http: HttpClient){}


    getItemsWithPagination(page:number, itemsPerPage:number,filter:string){
        return this.http.get("https://localhost:5001/api/Items/"+page + "/" + itemsPerPage + "?filter=" + filter)
        .toPromise()
        .then(data=> { return data as PaginationResult<Item>});
    }

    getItems(){
        return this.http.get("https://localhost:5001/api/Items")
        .toPromise()
        .then(data=> { return data as Item[]});
    }

    addItem(objEntity: Item){

        return this.http.post("https://localhost:5001/api/Items",objEntity)
        .toPromise()
        .then(data=> { return data as Item});
    }

    editItem(id,objEntity: Item){
        return this.http.put("https://localhost:5001/api/Items/"+id,objEntity)
        .toPromise()
        .then(data=>{ return data as Item});
    }

    deleteItem(id){
        return this.http.delete("https://localhost:5001/api/Items/"+id)
        .toPromise()
        .then(() => null);
    }
}