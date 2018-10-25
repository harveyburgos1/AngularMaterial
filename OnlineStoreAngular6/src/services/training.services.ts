import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Training } from "src/domain/training";

@Injectable()

export class TrainingService{

    constructor(private http: HttpClient){}


    getTraining(){
        return this.http.get("https://localhost:5001/api/training")
        .toPromise()
        .then(data=> { return data as Training[]});
    }

    addTraining(objEntity: Training){

        return this.http.post("https://localhost:5001/api/training",objEntity)
        .toPromise()
        .then(data=> { return data as Training});
    }

    editTraining(id,objEntity: Training){
        return this.http.put("https://localhost:5001/api/training/"+id,objEntity)
        .toPromise()
        .then(data=>{ return data as Training});
    }

    deleteTraining(id){
        return this.http.delete("https://localhost:5001/api/training/"+id)
        .toPromise()
        .then(() => null);
    }

}