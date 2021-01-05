import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LibraryListComponent } from './library-list/library-list.component';
import { LibraryRoutingModule } from './library-routing.module';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [LibraryListComponent],
  imports: [
    LibraryRoutingModule,
    CommonModule,
    FormsModule
  ]
})
export class LibraryModule { }
