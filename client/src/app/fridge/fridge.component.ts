import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-fridge',
  templateUrl: './fridge.component.html',
  styleUrls: ['./fridge.component.css']
})

export class FridgeComponent implements OnInit {
  NewIngredient: any = {};
  DelIngredient: any = {};

  //Used For Drop Down Menu
  selectedOption: string;
  options = [
    {name:'Chose Action', value: 'none'},
    { name: 'Add', value: 'add' },
    { name: 'Remove', value: 'remove' }
  ];  

  types = ["Dairy","Produce","Meat","Bread","Frozen"]; 
  ingredients :any;
  
  constructor(
    private http: HttpClient,
    private route: Router
    ) 
  {
    this.types.sort();
    this.route.routeReuseStrategy.shouldReuseRoute = () => { return false; }
  }


  ngOnInit(): void {    

    this.http.get('http://localhost:5068/api/ingredients').subscribe(
        response => { this.ingredients = response; },
        error => { console.log(error); }
      );
  }
  onSelect(option: string) {
    this.selectedOption = option;
  } 
  
  AddIngredient()
  {
    this.http.post('http://localhost:5068/api/ingredients', this.NewIngredient).subscribe(
        response => (this.home()),
          error => { console.log(error); }
      )
  }

  DeleteIngredient()
  {  
    this.http.delete(`http://localhost:5068/api/ingredients/${this.DelIngredient.Name}/${this.DelIngredient.Quantity}`,{responseType: 'text'}).subscribe(
    response => this.home(),    
    error => { console.log(error); }
    )
  }

  home()
  {
    this.route.navigate(["/"]);
  }
}
