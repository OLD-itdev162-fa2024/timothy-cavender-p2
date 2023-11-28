import { Component, OnInit } from '@angular/core';
@Component({
  selector: 'app-fridge',
  templateUrl: './fridge.component.html',
  styleUrls: ['./fridge.component.css']
})


export class FridgeComponent implements OnInit {
  selectedOption: string;
  options = [
    {name:'Chose Action', value: 'none'},
    { name: 'Add', value: 'add' },
    { name: 'Remove', value: 'remove' }
  ];

  /*Import this from database.  */
  ingredients: any = [
    {name: "Dairy", value: [
        {name: "Milk", value: 5},
        {name: "Cheese", value: 3}
      ]
    },
    {name: "Produce", value: [
        {name: "Tomato", value: 5},
        {name: "Brocoli", value: 6}    
      ]
    },
    {name: "Meat", value: [

      ]
    },
    {name: "Bread", value: [

      ]
    }
    
  ];
  
  constructor() {}

  ngOnInit(): void {
    //Will need to pull food items/ingredients from database
    //to populate in the Fridge HTML screen

    //Will also need to add/remove ingredients
  }
  onSelect(option: string) {
    this.selectedOption = option;
  } 

}
