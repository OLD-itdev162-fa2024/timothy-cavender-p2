import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Smart Fridge';
  weatherForecasts: any;
  ingredients: any;

  constructor(private http: HttpClient) {

  } 
  ngOnInit(): void {
    this.http.get('http://localhost:5068/ingredients').subscribe(
        response => { this.ingredients = response; },
        error => { console.log(error); }
      );
      /*this.http.get('http://localhost:5068/weatherforecast').subscribe(
        response => { this.weatherForecasts = response; },
        error => { console.log(error); }
      );*/
  }
}


