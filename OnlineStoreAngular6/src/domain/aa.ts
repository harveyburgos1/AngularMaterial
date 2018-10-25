// import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
// import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
// import { MatDialog, MatDialogRef, MatStepper, MatPaginator, MatTableDataSource } from '@angular/material';
// import { Person } from 'src/domain/person';
// import { PersonService } from '../services/person.service';
// import * as _moment from 'moment';
// import { DatePipe } from '@angular/common';

// const moment = _moment;

// var selectedPerson: Person;
// var isEditPerson: boolean;
// var isDeletePerson: boolean;
// var isAddPerson: boolean;

// @Component({
// selector: 'app-person',
// templateUrl: './person.component.html',
// styleUrls: ['./person.component.css'],
// providers: [PersonService]
// })

// export class PersonComponent implements OnInit {
// dataSource;
// displayedColumns = ['demo', 'firstName', 'middleName', 'lastName', 'age', 'gender', 'address'];
// personList: Person[];

// constructor(private dialog: MatDialog, private personService: PersonService) {

//     }

//     @ViewChild(MatPaginator) paginator: MatPaginator;

//     ngOnInit(): void {
//         this.personService.getPerson().then(result => {
//             this.personList = result;
//             this.dataSource = new MatTableDataSource<Person>(result);

//             this.dataSource.paginator = this.paginator;
//         });

//     }
//     private refreshTable() {
//         this.paginator._changePageSize(this.paginator.pageSize);
//     }

//     addPerson() {

//         console.log('Adding person...');

//         isAddPerson = true;
//         isEditPerson = false;
//         isDeletePerson = false;

//         const dialogRef = this.dialog.open(PersonDialog, {
//             width: '80%', height: '80%'
//         });

//         dialogRef.afterClosed().subscribe(result => {
//             console.log('The dialog was closed...');
//             this.refreshTable();
//         });
//     }

//     editPerson(Person) {

//         isAddPerson = false;
//         isEditPerson = true;
//         isDeletePerson = false;
//         selectedPerson = Person;

//         const dialogRef = this.dialog.open(PersonDialog, {
//             width: '80%', height: '80%'
//         });

//         dialogRef.afterClosed().subscribe(result => {
//             this.refreshTable();
//             console.log('The dialog was closed...');
//         });

//     }

//     deletePerson(Person) {
//         isDeletePerson = true;
//         isEditPerson = false;
//         isAddPerson = false;

//         selectedPerson = Person;

//         const dialogRef = this.dialog.open(PersonDialog, {
//             width: '80%', height: '80%'
//         });

//         dialogRef.afterClosed().subscribe(result => {
//             this.refreshTable();
//             console.log('The dialog was closed...');
//         });
//     }

//     applyFilter(filterValue: string) {
//         this.dataSource.filter = filterValue.trim().toLowerCase();
//     }

// }


// @Component({
//     templateUrl: './person-dialog.html',
//     styleUrls: ['./person.component.css'],
//     providers: [PersonService, MatStepper, DatePipe]
// })

// export class PersonDialog implements OnInit {

//     basicFormGroup: FormGroup;
//     addressFormGroup: FormGroup;

//     private minDate = new Date(1900, 0, 1);
//     private maxDate = new Date(Date.now());

//     genders = ["Male", "Female"];
//     private relations = ["Single", "Married", "Separated", "Widowed"];

//     private selectPerson: Person = {} as Person;
//     private personList: Person[];

//     private selectedStepper: number;
//     private selectedImage;
//     private fileName: string;
//     private isDeletePerson;
//     dataSource;

//     constructor(public dialogRef: MatDialogRef<PersonDialog>, private formBuilder: FormBuilder,
//         private personService: PersonService, private dialog: MatDialog, private datePipe: DatePipe) {

//     }

//     @ViewChild(MatPaginator) paginator: MatPaginator;

//     ngOnInit(): void {

//         if (isEditPerson) {
//             this.selectPerson = selectedPerson;
//             this.selectPerson.phoneNumber = this.selectPerson.phoneNumber.substring(3);
//             document.getElementById('dialog-title').innerHTML = "Edit Person";
//         } else if (isDeletePerson) {
//             this.selectPerson = selectedPerson;
//             this.isDeletePerson = isDeletePerson;
//             document.getElementById('dialog-title').innerHTML = "Delete Person";
//         } else if (isAddPerson) {
//             document.getElementById('dialog-title').innerHTML = "Add Person";
//         }

//         this.basicFormGroup = this.formBuilder.group({
//             'firstName': ['', [Validators.required, Validators.pattern('[a-zA-Z ]*')]],
//             'middleName': ['', [Validators.pattern('[a-zA-Z ]*')]],
//             'lastName': ['', [Validators.required, Validators.pattern('[a-zA-Z ]*')]],
//             'gender': ['', [Validators.required]],
//             'relationshipStatus': ['', [Validators.required]],
//             'birthday': [moment(), [Validators.required]],
//             'phoneNumber': ['', [Validators.required]],
//             'nationality': ['', [Validators.required, Validators.pattern('[a-zA-Z ]*')]],
//             'religion': ['', [Validators.required, Validators.pattern('[a-zA-Z ]*')]]
//         });

//         this.addressFormGroup = this.formBuilder.group({
//             'house': ['', [Validators.required]],
//             'barangay': ['', [Validators.nullValidator]],
//             'city': ['', [Validators.required]],
//             'region': ['', [Validators.required]],
//             'country': ['', [Validators.required]],
//             'postalCode': ['', [Validators.required]],
//             'latitude': ['', [Validators.required]],
//             'longtitude': ['', [Validators.required]]
//         });

//         if (!isEditPerson) {
//             this.selectPerson.gender = this.genders[0];
//         }

//         if (isDeletePerson) {
//             this.basicFormGroup.disable();
//             this.addressFormGroup.disable();
//         }

//         this.selectedStepper = 0;

//         this.loadAllPersons();

//     }

//     loadAllPersons(): void {

//         console.log("Loading data...");

//         this.personService.getPerson().then(result => {
//             this.personList = result;
//             this.dataSource = new MatTableDataSource<Person>(result);

//             this.dataSource.paginator = this.paginator;
//         });
//     }

//     onNoClick(): void {

//         console.log("Closing dialog...");

//         this.dialogRef.close();
//     }

//     cancel() {

//         this.onNoClick();
//     }

//     next(stepper: MatStepper): void {
//         this.selectedStepper = this.selectedStepper + 1;
//         console.log(this.selectedStepper)
//         stepper.next();
//     }

//     previous(stepper: MatStepper): void {
//         this.selectedStepper = this.selectedStepper - 1;
//         console.log(this.selectedStepper)
//         stepper.previous();
//     }

//     onFileSelected(event) {
//         this.selectedImage = event.target.files[0];

//         this.getImage(this.selectedImage).then(data => {
//             this.selectedImage = data;
//             let uint8array = new Uint8Array(this.selectedImage);
//             let bytes: number[] = {} as number[];

//             for (let i = 0; i < uint8array.length; i++) {
//                 bytes[i] = uint8array[i];
//             }

//             this.selectedImage = bytes;
//         });
//     }

//     getImage(myImage: File) {

//         var loadedPromise = new Promise((resolve, reject) => {

//             var reader = new FileReader();

//             reader.readAsArrayBuffer(myImage)

//             reader.onload = (event: any) => resolve(event.target.result);

//         });

//         return loadedPromise;
//     }

//     savePerson() {

//         if (isEditPerson == true) {

//             this.selectPerson.phoneNumber = "+63" + this.selectPerson.phoneNumber;
//             this.selectPerson.birthday = this.datePipe.transform(this.selectPerson.birthday, 'yyyy-MM-dd');

//             let tmpPersonList = [...this.personList];
//             var person = this.selectPerson;

//             this.personService.editPerson(person.personID, person).then(result => {
//                 result.birthday = this.datePipe.transform(this.selectPerson.birthday, 'yyyy-MM-dd');
//                 tmpPersonList.push(result);
//                 this.personList = tmpPersonList;
//             });

//         } else {

//             this.selectPerson.phoneNumber = "+63" + this.selectPerson.phoneNumber;
//             this.selectPerson.age = this.computeAge();
//             this.selectPerson.birthday = this.datePipe.transform(this.selectPerson.birthday, 'yyyy-MM-dd');
//             var obj = this.selectedImage;

//             this.selectPerson.photo = Object.keys(obj).map(function (key) {
//                 return obj[key];
//             });

//             let tmpPersonList = [...this.personList];

//             var person = this.selectPerson;

//             this.personService.addPerson(person).then(result => {
//                 result.birthday = this.datePipe.transform(this.selectPerson.birthday, 'yyyy-MM-dd');
//                 tmpPersonList.push(result);
//                 this.personList = tmpPersonList;
//             });

//         }

//         this.selectPerson = {} as Person;

//         this.dialogRef.close();
//     }

//     okDelete() {
//         let tmpPersonList = [...this.personList];

//         this.personService.deletePerson(this.selectPerson.personID).then(result => {
//             tmpPersonList.splice(tmpPersonList.indexOf(this.selectPerson), 1);
//             this.personList = tmpPersonList;

//         });

//         this.selectPerson = {} as Person;

//         this.dialogRef.close();
//     }

//     computeAge() {

//         let birthdate = new Date(this.selectPerson.birthday);
//         let today = new Date(Date.now());

//         let birthdateYear = birthdate.getFullYear();
//         let birthdateMonth = birthdate.getMonth();
//         let birthdateDay = birthdate.getDay();

//         let todayYear = today.getFullYear();
//         let todayMonth = today.getMonth();
//         let todayDay = today.getDay();

//         var age = todayYear - birthdateYear - 1;

//         if (todayMonth > birthdateMonth) {
//             age = todayYear - birthdateYear;
//         } else if (todayMonth == birthdateMonth) {
//             if (todayDay == birthdateDay) {
//                 age = todayYear - birthdateYear;
//             }
//         }

//         return age;
//     }

//     getErrorMessage(formControl: FormControl) {
//         switch (formControl) {
//             case this.basicFormGroup.controls['firstName']:

//                 return formControl.hasError('required') ? "You must enter a first name." :
//                     formControl.hasError('pattern') ? "Not a valid first name." : "";
//                 break;

//             case this.basicFormGroup.controls['middleName']:

//                 return formControl.hasError('pattern') ? "Not a valid middle name." : "";
//                 break;

//             case this.basicFormGroup.controls['lastName']:

//                 return formControl.hasError('required') ? "You must enter a last name." :
//                     formControl.hasError('pattern') ? "Not a valid last name." : "";
//                 break;

//             case this.basicFormGroup.controls['gender']:

//                 return formControl.hasError('required') ? "You must choose a gender." : "";
//                 break;

//             case this.basicFormGroup.controls['relationshipStatus']:

//                 return formControl.hasError('required') ? "You must choose a relationship status." : "";
//                 break;

//             case this.basicFormGroup.controls['birthday']:

//                 return formControl.hasError('required') ? "You must choose a birth date." : "";
//                 break;

//             case this.basicFormGroup.controls['phoneNumber']:

//                 return formControl.hasError('required') ? "You must enter a phone number." : "";
//                 break;

//             case this.basicFormGroup.controls['nationality']:

//                 return formControl.hasError('required') ? "You must enter a nationality." :
//                     formControl.hasError('pattern') ? "Not a valid nationality." : "";
//                 break;

//             case this.basicFormGroup.controls['religion']:

//                 return formControl.hasError('required') ? "You must enter a religion." :
//                     formControl.hasError('pattern') ? "Not a valid religion." : "";
//                 break;

//             case this.addressFormGroup.controls['house']:

//                 return formControl.hasError('required') ? "You must enter a house no./street/building." : "";
//                 break;

//             case this.addressFormGroup.controls['city']:

//                 return formControl.hasError('required') ? "You must enter a city." : "";
//                 break;

//             case this.addressFormGroup.controls['region']:

//                 return formControl.hasError('required') ? "You must enter a region." : "";
//                 break;

//             case this.addressFormGroup.controls['country']:

//                 return formControl.hasError('required') ? "You must enter a country." : "";
//                 break;

//             case this.addressFormGroup.controls['postalCode']:

//                 return formControl.hasError('required') ? "You must enter a postal code." : "";
//                 break;

//             case this.addressFormGroup.controls['latitude']:

//                 return formControl.hasError('required') ? "You must enter a latitude." : "";
//                 break;

//             case this.addressFormGroup.controls['longtitude']:

//                 return formControl.hasError('required') ? "You must enter a longtitude." : "";
//                 break;

//             default:
//                 break;
//         }
//     }
// }