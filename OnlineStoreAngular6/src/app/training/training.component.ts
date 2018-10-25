import { Component, OnInit, ViewChild } from '@angular/core';
import { TrainingService } from 'src/services/training.services';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Training } from 'src/domain/training';
import { MatPaginator, MatTableDataSource } from '@angular/material';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-training',
  templateUrl: './training.component.html',
  styleUrls: ['./training.component.css'],
  providers:[TrainingService,DatePipe]
})
export class TrainingComponent implements OnInit {
  selectTraining:Training;
  trainingList:Training[];
  isAddTraining=false;
  isDeleteTraining=false;
  minDate = new Date();
  TrainingFormGroup:FormGroup;
  dataSource;
  indexOfTraining:number =0;
  displayedColumns: string[] = 
  ['description','price','isActive','dateCreated','actions'];
  isActive:boolean;

  constructor(private fb: FormBuilder, private trainingService:TrainingService, private datePipe:DatePipe) { }


  @ViewChild(MatPaginator) paginator: MatPaginator;

  
  ngOnInit() {

    this.TrainingFormGroup= this.fb.group({
      'description': new FormControl('', Validators.required),
      'price': new FormControl('', Validators.required),
      'isActive': new FormControl('', Validators.required),
      'dateCreated': new FormControl('', Validators.required)
    });
    this.loadAllTraining();
  }

  loadAllTraining() {
    this.trainingService.getTraining().then(result => {

      this.trainingList = result;
      for (var i = 0; i < this.trainingList.length; i++) {
        this.trainingList[i].dateCreated =
        this.datePipe.transform(this.trainingList[i].dateCreated, 'yyyy-MM-dd');
      }
      this.dataSource = new MatTableDataSource<Training>(result);
      this.dataSource.paginator = this.paginator;
    });
  }
  addTraining(){
    this.isAddTraining=true;  
    this.TrainingFormGroup.enable();
    this.isDeleteTraining = false;
    this.selectTraining = {} as Training;
  }


  applyFilter(filterValue: string) {
    
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

 

  
  editTraining(Training) {
    this.isAddTraining = false;
    this.isDeleteTraining = false;
    this.indexOfTraining = this.trainingList.indexOf(Training);
    this.selectTraining = Training;
    this.selectTraining.isActive = Training.isActive;


    this.selectTraining = Object.assign({}, this.selectTraining);
    console.log(this.selectTraining.isActive)
    this.TrainingFormGroup.value.isActive = this.selectTraining.isActive;
  }

  
  saveTraining() {
    this.TrainingFormGroup.enable();
    let tmpTrainingList = [...this.trainingList];
    this.selectTraining.dateCreated = this.datePipe.transform(this.selectTraining.dateCreated, 'yyyy-MM-dd');
    if (this.isAddTraining === true) {
      this.trainingService.addTraining(this.selectTraining).then(result => {

        this.selectTraining.dateCreated =
        tmpTrainingList.push(result);
        this.trainingList = tmpTrainingList;
        this.selectTraining = null;
        this.loadAllTraining();
      });
    }
    else {
      this.trainingService.editTraining(this.selectTraining.trainingID, this.selectTraining)
        .then(result => {
        tmpTrainingList[this.indexOfTraining] = result;
          this.trainingList = tmpTrainingList;
          this.selectTraining = null;
          this.loadAllTraining();
        });

    }
  }


  
  displayDeleteTraining(Training){
    this.TrainingFormGroup.disable();
    this.isDeleteTraining = true;
    this.indexOfTraining = this.trainingList.indexOf(Training);
    this.selectTraining = Training;
    this.selectTraining = Object.assign({}, this.selectTraining);
  }

  deleteTraining(){
    let tmpTrainingList = [...this.trainingList];
    this.trainingService.deleteTraining(this.selectTraining.trainingID).then(() => {
        tmpTrainingList.splice(this.indexOfTraining, 1);
        this.trainingList = tmpTrainingList;
        this.selectTraining = null;
        this.loadAllTraining();
    });
  }


  cancelTraining(){
    this.selectTraining = null;
  }
}
