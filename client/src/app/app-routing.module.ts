import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { FridgeComponent } from './fridge/fridge.component';
import { RecipesComponent } from './recipes/recipes.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'fridge', component: FridgeComponent},
  {path: 'recipes', component: RecipesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
