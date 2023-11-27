import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Recipes';
  recipes: any;

  constructor(private http: HttpClient)
  {
    this.http.get('http://localhost:5090/recipe').subscribe(
      response => {this.recipes = response; },
      error => {console.log(error); }
    )
  }
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }
}
