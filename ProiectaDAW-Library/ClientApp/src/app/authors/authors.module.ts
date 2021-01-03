import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthorsRoutingModule } from './authors-routing.module';
import { AuthorsListComponent } from './authors-list/authors-list.component';
import { AuthorsDetailsComponent } from './authors-details/authors-details.component';
import { AuthorsAddComponent } from './authors-add/authors-add.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [AuthorsListComponent, AuthorsDetailsComponent, AuthorsAddComponent],
  imports: [
    CommonModule,
    AuthorsRoutingModule,
    FormsModule
  ]
})
export class AuthorsModule { }
