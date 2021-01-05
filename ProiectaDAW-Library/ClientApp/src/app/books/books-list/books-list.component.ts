import { Component, OnInit } from '@angular/core';
import { BooksService } from 'src/app/core/services/books/books.service';

@Component({
  selector: 'app-books-list',
  templateUrl: './books-list.component.html',
  styleUrls: ['./books-list.component.css']
})
export class BooksListComponent implements OnInit {

  books: any;
  currentBook = null;
  currentIndex = -1;
  title = '';

  constructor(private booksService: BooksService) { }

  ngOnInit() {
    this.retrieveBooks();
  }

  retrieveBooks(): void {
    this.booksService.getAll()
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
    this.currentBook = null;
    this.currentIndex = -1;
  }

  setActiveBook(book, index): void {
    this.currentBook = book;
    this.currentIndex = index;
  }

  searchBook(): void {
    this.booksService.findByTitle(this.title)
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
    this.booksService.findByAuthor(this.title)
      .subscribe(
        data => {
          this.books = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

  deleteBook(book): void {
    if(confirm("Sunteti sigur ca vreti sa stergeti cartea " + book.title + "?")) {
      this.booksService.delete(book.id)
      .subscribe(
        data => {
          this.refreshList();
        },
        error => {
          console.log(error);
        });
    }
  }

}
