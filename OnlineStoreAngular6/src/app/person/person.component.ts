import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PersonService } from '../../services/person.service';
import { Person } from '../../domain/person';
import { DataTable } from 'primeng/primeng';
import {DatePipe} from '@angular/common';
import { MatPaginator, MatTableDataSource } from '@angular/material';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css'],
  providers: [PersonService,DatePipe]
})
export class PersonComponent implements OnInit {
  personList: Person[];
  selectPerson: Person;
  personFormGroup: FormGroup;
  isAddPerson = false;
  isDeletePerson = false;
  age:number = 0;
  indexOfPerson:number = 0;
  searchPersonName:string="";
  totalRecords:number=0;
  maxDate = new Date();
  dataSource;
  displayedColumns: string[] = 
  ['photo','fullName','age','birthday','gender',
   'relationshipStatus','nationality','phoneNumber','longtitude','latitude','actions'];
   private selectedImage;
   private fileName: string;

  constructor(private fb: FormBuilder, private personService: PersonService, private datePipe:DatePipe) { }
 
  @ViewChild('dt') public dataTable: DataTable;
  @ViewChild(MatPaginator) paginator: MatPaginator;


  ngOnInit() {
    this.personFormGroup = this.fb.group({
      firstName: ['', Validators.required],
      middleName: [''],
      lastName: ['', Validators.required],
      birthday: ['', Validators.required],
      age: ['', Validators.required],
      gender: ['', Validators.required],
      relationshipStatus: ['', Validators.required],
      nationality: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      religion: ['', Validators.required],
      street: ['', Validators.required],
      barangay: ['', Validators.required],
      city: ['', Validators.required],
      region: ['', Validators.required],
      country: ['', Validators.required],
      postalCode: ['', Validators.required],
      latitude: ['', Validators.required],
      longtitude: ['', Validators.required]
    });

    this.paginate();
  }

  loadAllPerson() {
    this.personService.getPersons().then(persons => {
      this.personList = persons
      for (var i = 0; i < this.personList.length; i++) {

        if (this.personList[i].middleName == null || this.personList[i].barangay == null) {
          this.personList[i].fullName = this.personList[i].firstName + this.personList[i].lastName;
          this.personList[i].address =
            this.personList[i].street + " "
            + this.personList[i].city + " "
            + this.personList[i].region + " "
            + this.personList[i].country + ","
            + this.personList[i].postalCode

            this.personList[i].birthday =
            this.datePipe.transform(this.personList[i].birthday, 'yyyy-MM-dd');
        }
        else if (this.personList[i].middleName != null) {
          this.personList[i].fullName = this.personList[i].firstName + " " + this.personList[i].middleName.substr(0, 1) + "." + this.personList[i].lastName;
          this.personList[i].address =
            this.personList[i].street + " "
            + this.personList[i].barangay + " "
            + this.personList[i].city + " "
            + this.personList[i].region + ","
            + this.personList[i].postalCode + "  "
            + this.personList[i].country

            this.personList[i].birthday =
            this.datePipe.transform(this.personList[i].birthday, 'yyyy-MM-dd');
        }
      }

    });
  }

  
  searchPerson(){
    if(this.searchPersonName.length != 1){
        this.resetTable();
    }
  }

 

  paginate(){
    this.personService.getPersons().then(result => {
      
      this.personList = result;
      for (var i = 0; i < this.personList.length; i++) {

        if (this.personList[i].middleName == null || this.personList[i].barangay == null) {
          this.personList[i].fullName = this.personList[i].firstName + this.personList[i].lastName;
          this.personList[i].address =
            this.personList[i].street + " "
            + this.personList[i].city + " "
            + this.personList[i].region + " "
            + this.personList[i].country + ","
            + this.personList[i].postalCode

            this.personList[i].birthday =
            this.datePipe.transform(this.personList[i].birthday, 'yyyy-MM-dd');
        }
        else if (this.personList[i].middleName != null) {
          this.personList[i].fullName = this.personList[i].firstName + " " + this.personList[i].middleName.substr(0, 1) + "." + this.personList[i].lastName;
          this.personList[i].address =
            this.personList[i].street + " "
            + this.personList[i].barangay + " "
            + this.personList[i].city + " "
            + this.personList[i].region + ","
            + this.personList[i].postalCode + "  "
            + this.personList[i].country

            this.personList[i].birthday =
            this.datePipe.transform(this.personList[i].birthday, 'yyyy-MM-dd');
        }
      }
      
			this.dataSource = new MatTableDataSource<Person>(result);
			this.dataSource.paginator = this.paginator;
		});
  }


  applyFilter(filterValue: string) {
    
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  
  resetTable(){
    this.dataTable.reset();
}


  addPerson() {
    this.personFormGroup.enable();
    this.isAddPerson = true;
     this.isDeletePerson = false;
    this.selectPerson = {} as Person;
  }

  cancelPerson(Person){
    this.selectPerson = null; 
  }

  computeAge() {
    var dateold = new Date(this.personFormGroup.value.birthday);
    var datenew = new Date();
    var ynew = datenew.getFullYear();
    var mnew = datenew.getMonth();
    var dnew = datenew.getDate(); 
    var yold = dateold.getFullYear();
    var mold = dateold.getMonth();
    var dold = dateold.getDate();
    var diff = ynew - yold;
    if (mold > mnew) diff--;
    else {
        if (mold == mnew) {
            if (dold > dnew) diff--;
        }
    }
    this.selectPerson.age = diff;


  }
  
  savePerson(){
    this.personFormGroup.enable();
    let tmpPersonList = [...this.personList];
    if (this.isAddPerson === true) {
   //   this.selectPerson.photo = this.selectedImage;
      this.personService.addPerson(this.selectPerson).then(result => {
        //#region Concat fields
        if (result.middleName == null || result.barangay ==null) {
          result.fullName = result.firstName + result.lastName;
          result.address =
          result.street + " "
            + result.city + " "
            + result.region + " "
            + result.country + ","
            + result.postalCode;

             result.birthday =
             this.datePipe.transform(this.selectPerson.birthday, 'yyyy-MM-dd');


            tmpPersonList.push(result);
            this.personList = tmpPersonList;     
            this.selectPerson = null;

        }
        else if (result.middleName != null ) {
          result.fullName = result.firstName + " " + result.middleName.substr(0, 1) + "." + result.lastName
          result.address =
          result.street + " "
            + result.city + " "
            + result.region + " "
            + result.country + ","
            + result.postalCode;


             result.birthday =
             this.datePipe.transform(this.selectPerson.birthday, 'yyyy-MM-dd');
             
            tmpPersonList.push(result);
            this.personList = tmpPersonList;     
            this.selectPerson = null;
        }
//#endregion

        this.paginate();

      });
    }
    else {
      this.personService.updatePerson(this.selectPerson.personID, this.selectPerson)
        .then(result => {

          //#region Concat Fields
          if (result.middleName == null || result.barangay ==null) {
            result.fullName = result.firstName + result.lastName;
            result.address =
            result.street + " "
              + result.city + " "
              + result.region + " "
              + result.country + ","
    
              result.birthday =
              this.datePipe.transform(this.selectPerson.birthday, 'yyyy-MM-dd');
    
    
          }
          else if (result.middleName != null) {
            result.fullName = result.firstName + " " + result.middleName.substr(0, 1) + "." + result.lastName
            result.address =
            result.street + " "
              + result.city + " "
              + result.region + " "
              + result.country + ","
              + result.postalCode;
    
              result.birthday =
              this.datePipe.transform(this.selectPerson.birthday, 'yyyy-MM-dd');
          }
          //#endregion
          tmpPersonList[this.indexOfPerson] = result;
        
          this.personList = tmpPersonList;
          this.selectPerson = null;
          this.paginate();

        });

    }
  }

  editPerson(Person){
    this.personFormGroup.enable();
    this.isAddPerson = false;
    this.isDeletePerson = false;
    this.indexOfPerson = this.personList.indexOf(Person);
    this.selectPerson = Person;

    this.selectPerson = Object.assign({}, this.selectPerson);
    this.personFormGroup.value.birthday = Person.birthday;

  }



  displayDeletePerson(Person){
    this.selectPerson = null;
    this.personFormGroup.disable();
    this.isDeletePerson = true;
    this.isAddPerson=false;
    this.indexOfPerson = this.personList.indexOf(Person);
    this.selectPerson = Person;
    this.selectPerson = Object.assign({}, this.selectPerson);
  }


  deletePerson(){

    this.isDeletePerson = true;
    let tmpPersonList = [...this.personList];
    this.personService.deletePerson(this.selectPerson.personID).then(() => {
     tmpPersonList.splice(this.indexOfPerson, 1);
     this.personList = tmpPersonList;
     this.selectPerson = null;      
      this.paginate();
    });
  }

  onFileSelected(event) {
   
    this.selectedImage = event.target.files[0];

    this.getImage(this.selectedImage).then(data => {
        this.selectedImage = data;
        let uint8array = new Uint8Array(this.selectedImage);
        let bytes: number[] = {} as number[];

        for (let i = 0; i < uint8array.length; i++) {
            bytes[i] = uint8array[i];
        }

         this.selectedImage = bytes;

        var a = this.ToBase64(uint8array); // as uInt8
    });
}


getImage(myImage:File) {

    var loadedPromise = new Promise((resolve, reject) => {

        var reader = new FileReader();

        reader.readAsArrayBuffer(myImage)

        reader.onload = (event: any) => resolve(event.target.result);

    });
    return loadedPromise;
}
Convert(buffer) {
      var binary = '';
      var bytes = new Uint8Array(buffer);
      var len = bytes.byteLength;
      for (var i = 0; i < len; i++) {
          binary += String.fromCharCode(bytes[i]);
      }
      return window.btoa(binary);
  }
  ToBase64(u8) {
    return btoa(String.fromCharCode.apply(null, u8));
}

  

}

