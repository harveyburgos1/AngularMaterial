import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { PaginationResult } from "../domain/paginationresult";
import { Product } from "../domain/product";

@Injectable()

export class ProductService{

    constructor(private http: HttpClient){}

    getProductWithPagination(page:number, itemsPerPage:number,filter:string){
        return this.http.get("https://localhost:5001/api/Product/"+page + "/" + itemsPerPage + "?filter=" + filter)
        .toPromise()
        .then(data=> { return data as PaginationResult<Product>});
    }

    getProduct(){
        return this.http.get("https://localhost:5001/api/Product")
        .toPromise()
        .then(data=> { return data as Product[]});
    }

    addProduct(objEntity: Product){

        return this.http.post("https://localhost:5001/api/Product",objEntity)
        .toPromise()
        .then(data=> { return data as Product});
    }

    editProduct(id,objEntity: Product){
        return this.http.put("https://localhost:5001/api/Product/"+id,objEntity)
        .toPromise()
        .then(data=>{ return data as Product});
    }

    deleteProduct(id){
        return this.http.delete("https://localhost:5001/api/Product/"+id)
        .toPromise()
        .then(() => null);
    }

}