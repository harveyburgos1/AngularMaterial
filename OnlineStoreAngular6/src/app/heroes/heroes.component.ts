import { Component, OnInit, ViewChild } from '@angular/core';
import { HeroesService } from '../../services/heroes.service';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { Hero } from '../../domain/hero';
import { DataTable } from 'primeng/primeng';

@Component({
  selector: 'app-heroes',
  templateUrl: './heroes.component.html',
  styleUrls: ['./heroes.component.css'],
  providers: [HeroesService]

})
export class HeroesComponent implements OnInit {
  heroesList:Hero[];
  selectHero: Hero;
  heroesForm:FormGroup;
  isAddHero: boolean;
  isDeleteHero: boolean;
  indexOfHero: number = 0;
  searchHeroName: string ="";
  totalRecords:number=0;
  
  constructor(private heroesService: HeroesService, private fb: FormBuilder) { }

  @ViewChild('dt') public dataTable: DataTable;


  ngOnInit() {
  this.heroesForm = this.fb.group({
    'name': new FormControl('', Validators.required),
    'attribute': new FormControl('', Validators.required),
    'hit': new FormControl('', Validators.required),
    'mana': new FormControl('', Validators.required),
    'damage': new FormControl('', Validators.required),
    'armor': new FormControl('', Validators.required),
    'description': new FormControl('', Validators.required),
    'isMelee': new FormControl('', Validators.required),
    'aghanimsEffect': new FormControl('', Validators.required)
  })
    //this.loadAllHeroes();
  }


  cancelHero(Hero){
    this.selectHero = null;
  }

  resetTable(){
    this.dataTable.reset();
}

  loadAllHeroes() {
    this.heroesService.getHeroes().then(result => {
      this.heroesList = result
    });
  }

  searchHero(){
    if(this.searchHeroName.length != 1){
        this.resetTable();
    }
  }

  paginate($event){
    this.heroesService.getHeroesWithPagination($event.first, $event.rows,this.searchHeroName)
    .then(result => {
      this.totalRecords = result.totalRecords;
      this.heroesList = result.results;
     });
  }

  addHero() {
    this.heroesForm.enable();
    this.isAddHero = true;
    this.isDeleteHero = false;
    this.selectHero = {} as Hero;
  }
 
  editHero(Hero) {
    this.isAddHero = false;
    this.isDeleteHero = false;
    this.indexOfHero = this.heroesList.indexOf(Hero);
    this.selectHero = Hero;
    this.selectHero = Object.assign({}, this.selectHero);
  }

  saveHero() {
    this.heroesForm.enable();
    let tmpHeroesList = [...this.heroesList];
    if (this.isAddHero === true) {
      this.heroesService.addHero(this.selectHero).then(result => {
        tmpHeroesList.push(result);
        this.heroesList = tmpHeroesList;
        this.selectHero = null;
      });
    }
    else{
      this.heroesService.editHero(this.selectHero.heroID, this.selectHero)
      .then(result => {
      tmpHeroesList[this.indexOfHero] = result;
        this.heroesList = tmpHeroesList;
        this.selectHero = null;
      });
    }
  }

  deleteHero(Hero){
    this.heroesForm.disable();
    this.isDeleteHero = true;
    this.indexOfHero= this.heroesList.indexOf(Hero);
    this.selectHero = Hero;
    this.selectHero = Object.assign({}, this.selectHero);
  }

  okDelete(){
    let tmpHeroesList = [...this.heroesList];
    this.heroesService.deleteHero(this.selectHero.heroID).then(() => {
        tmpHeroesList.splice(this.indexOfHero, 1);
        this.heroesList = tmpHeroesList;
        this.selectHero = null;
    });
  }


}
