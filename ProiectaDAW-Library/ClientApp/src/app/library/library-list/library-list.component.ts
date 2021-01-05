import { Component, OnInit } from '@angular/core';
import { LibraryService } from 'src/app/core/services/library/library.service';

@Component({
  selector: 'app-library-list',
  templateUrl: './library-list.component.html',
  styleUrls: ['./library-list.component.css']
})
export class LibraryListComponent implements OnInit {

  books: any;
  title = '';

  constructor(private libraryService: LibraryService) { }

  ngOnInit() {
    this.retrieveBooks();
  }

  retrieveBooks(): void {
    this.libraryService.getBooks()
      .subscribe(
        data => {
          this.books = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

  searchBook(): void {
    this.libraryService.findByTitle(this.title)
      .subscribe(
        data => {
          this.books = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

  searchBooByAuthor(): void {
    this.libraryService.findByAuthor(this.title)
      .subscribe(
        data => {
          this.books = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

  refreshList(): void {
    this.retrieveBooks();
  }

  borrow(book): void {
    if (book.noCopies == 0) {
      alert("Din pacate, nu mai exista nicio copie disponibila pentru '" + book.title + "'.")
    } else {
      if(confirm(`Sunteti sigur ca vreti sa imprumutati cartea ${book.title} scrisa de ${book.author.name}?`)) {
        this.libraryService.borrow(book.id).subscribe(
          data => {
            this.refreshList();
            this.books = data;
            console.log(data);
          },
          error => {
            console.log(error);
          });
      }
    }
  }

  return(book): void {
      if(confirm(`Sunteti sigur ca vreti sa returnati cartea ${book.title} scrisa de ${book.author.name}?`)) {
        this.libraryService.return(book.id).subscribe(
          data => {
            this.refreshList();
            this.books = data;
            console.log(data);
          },
          error => {
            console.log(error);
          });
      }
  }

}
