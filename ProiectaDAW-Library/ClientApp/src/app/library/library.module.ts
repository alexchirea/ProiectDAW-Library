import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LibraryListComponent } from './library-list/library-list.component';
import { LibraryRoutingModule } from './library-routing.module';



@NgModule({
  declarations: [LibraryListComponent],
  imports: [
    LibraryRoutingModule,
    CommonModule
  ]
})
export class LibraryModule { }
