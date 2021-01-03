import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BooksAddComponent } from './books-add/books-add.component';
import { BooksDetailsComponent } from './books-details/books-details.component';
import { BooksListComponent } from './books-list/books-list.component';


export const routes: Routes = [
  { path: '', component: BooksListComponent },
  { path: 'view/:id', component: BooksDetailsComponent },
  { path: 'new', component: BooksAddComponent }
]

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class BooksRoutingModule { }
