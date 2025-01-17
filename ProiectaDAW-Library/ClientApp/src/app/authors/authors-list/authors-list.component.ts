import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AuthorsService } from 'src/app/core/services/authors/authors.service';

@Component({
  selector: 'app-authors-list',
  templateUrl: './authors-list.component.html',
  styleUrls: ['./authors-list.component.css']
})
export class AuthorsListComponent implements OnInit {

  authors: any;
  currentAuthor = null;
  currentIndex = -1;
  name = '';

  constructor(private authorsService: AuthorsService, private toastService: ToastrService,) { }

  ngOnInit() {
    this.retrieveAuthors();
  }

  retrieveAuthors(): void {
    this.authorsService.getAll()
      .subscribe(
        data => {
          this.authors = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

  refreshList(): void {
    this.retrieveAuthors();
    this.currentAuthor = null;
    this.currentIndex = -1;
  }

  setActiveAuthor(author, index): void {
    this.currentAuthor = author;
    this.currentIndex = index;
  }

  searchAuthor(): void {
    this.authorsService.findByName(this.name)
      .subscribe(
        data => {
          this.authors = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

  deleteAuthor(author): void {
    if(confirm("Sunteti sigur ca vreti sa stergeti autorul " + author.name + "?")) {
      this.authorsService.delete(author.id)
      .subscribe(
        data => {
          this.toastService.success("Autorul a fost sters");
          this.refreshList();
        },
        error => {
          console.log(error);
        });
    }
  }

}
