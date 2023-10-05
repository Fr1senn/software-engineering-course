import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { RandomNumberComponent } from './components/random-number/random-number.component';

@NgModule({
  imports: [RouterModule.forRoot([
    { path: 'RandomNumber', component: RandomNumberComponent }
  ])],
  exports: [RouterModule]
})
export class AppRoutingModule { }
