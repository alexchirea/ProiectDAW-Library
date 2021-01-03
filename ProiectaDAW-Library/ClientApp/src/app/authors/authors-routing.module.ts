import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthorsListComponent } from './authors-list/authors-list.component';
import { ModuleWithProviders } from '@angular/core'
import { AuthorsDetailsComponent } from './authors-details/authors-details.component';
import { AuthorsAddComponent } from './authors-add/authors-add.component';


export const routes: Routes = [
  { path: '', component: AuthorsListComponent },
  { path: 'view/:id', component: AuthorsDetailsComponent },
  { path: 'new', component: AuthorsAddComponent }
]

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AuthorsRoutingModule { }
