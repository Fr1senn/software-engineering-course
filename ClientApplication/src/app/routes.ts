import { Routes } from "@angular/router";
import { RandomNumberComponent } from "./components/random-number/random-number.component";
import { IntegralGraphComponent } from "./components/integral-graph/integral-graph.component";

export const routes: Routes = [
    { path: 'RandomNumber', component: RandomNumberComponent },
    { path: 'Integral', component: IntegralGraphComponent }
];