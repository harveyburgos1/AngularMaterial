import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Hero } from "../domain/hero";
import { PaginationResult } from "../domain/paginationresult";

@Injectable()

export class HeroesService{

    constructor(private http: HttpClient){}

    getHeroesWithPagination(page:number, itemsPerPage:number,filter:string){
        return this.http.get("https://localhost:5001/api/Heroes/"+page + "/" + itemsPerPage + "?filter=" + filter)
        .toPromise()
        .then(data=> { return data as PaginationResult<Hero>});
    }
    
    getHeroes(){
        return this.http.get("https://localhost:5001/api/Heroes")
        .toPromise()
        .then(data=> { return data as Hero[]});
    }

    addHero(objEntity: Hero){

        return this.http.post("https://localhost:5001/api/Heroes",objEntity)
        .toPromise()
        .then(data=> { return data as Hero});
    }

    editHero(id,objEntity: Hero){
        return this.http.put("https://localhost:5001/api/Heroes/"+id,objEntity)
        .toPromise()
        .then(data=>{ return data as Hero});
    }

    deleteHero(id){
        return this.http.delete("https://localhost:5001/api/Heroes/"+id)
        .toPromise()
        .then(() => null);
    }
}