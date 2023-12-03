import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-recipes',
  templateUrl: './recipes.component.html',
  styleUrls: ['./recipes.component.css']
})
export class RecipesComponent implements OnInit {

  recipes = [
    { Name: "Pizza",
    Ingredients: [
      {name: "Dough", value: 1},
      {name: "Cheese", value: 4},
      {name: "Sauce", value: 1},
      {name: "Pepperoni", value: 15}
    ],
    Instructions: "Here are some instructions on making a pizza"
  },
  { Name: "Pasta",
    Ingredients: [
      {name: "Noodles", value:1},
      {name: "Pasta Sauce", value: 1},
      {name: "Parmesian Cheese", value: 1}
    ],
    Instructions: "Here are some instructions on making pasta"
  },
  { Name: "Cheese Omelet",
    Ingredients: [
      {name: "Eggs", value: 2},
      {name: "Cheese", value: 2}
    ],
    Instructions: "Here are some instructions on making a cheese omelet"
  },
  { Name: "Hamburger",
    Ingredients: [
      {name: "Hamburger Buns", value: 8},
      {name: "Ground Beef", value: 3},
      {name: "Cheese", value:4}
    ],
    Instructions: "Here are some instructions on making a hamburger"
  }
];
  constructor() { }

  ngOnInit(): void {
  }

}
