import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { PaginationResult } from "../domain/paginationresult";
import { Shipper } from "../domain/shipper";


@Injectable()

export class ShipperService{
    constructor(private http: HttpClient){}


    getShipperWithPagination(page:number, shipperPerPage:number,filter:string){
        return this.http.get("https://localhost:5001/api/Shipper/"+page + "/" + shipperPerPage + "?filter=" + filter)
        .toPromise()
        .then(data=> { return data as PaginationResult<Shipper>});
    }

    getShipper(){
        return this.http.get("https://localhost:5001/api/Shipper")
        .toPromise()
        .then(data=> { return data as Shipper[]});
    }

    addShipper(objEntity: Shipper){

        return this.http.post("https://localhost:5001/api/Shipper",objEntity)
        .toPromise()
        .then(data=> { return data as Shipper});
    }

    editShipper(id,objEntity: Shipper){
        return this.http.put("https://localhost:5001/api/Shipper/"+id,objEntity)
        .toPromise()
        .then(data=>{ return data as Shipper});
    }

    deleteShipper(id){
        return this.http.delete("https://localhost:5001/api/Shipper/"+id)
        .toPromise()
        .then(() => null);
    }
}


