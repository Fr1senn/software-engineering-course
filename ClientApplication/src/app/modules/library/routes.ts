import { Routes } from "@angular/router";
import { LibraryComponent } from "./components/library/library.component";
import { BooksComponent } from "./components/books/books.component";
import { OrdersComponent } from "./components/orders/orders.component";


export const routes: Routes = [{
    path: 'Library', component: LibraryComponent, children: [
        { path: '', redirectTo: 'Books', pathMatch: 'full' },
        { path: 'Books', component: BooksComponent },
        { path: 'Orders', component: OrdersComponent }
    ]
}];