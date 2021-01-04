import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BooksRoutingModule } from './books-routing.module';
import { BooksAddComponent } from './books-add/books-add.component';
import { BooksListComponent } from './books-list/books-list.component';
import { BooksDetailsComponent } from './books-details/books-details.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [BooksAddComponent, BooksListComponent, BooksDetailsComponent],
  imports: [
    CommonModule,
    BooksRoutingModule,
    FormsModule
  ]
})
export class BooksModule { }
