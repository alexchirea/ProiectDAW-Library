import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthorsService } from 'src/app/core/services/authors/authors.service';
import { BooksService } from 'src/app/core/services/books/books.service';

@Component({
  selector: 'app-books-add',
  templateUrl: './books-add.component.html',
  styleUrls: ['./books-add.component.css']
})
export class BooksAddComponent implements OnInit {

  book = {
    title: '',
    authorId: '',
    noCopies: 0
  };

  authors = [];

  constructor(private authorsService: AuthorsService,
              private booksService: BooksService,
              private router: Router) { }

  ngOnInit() {
    this.retrieveAuthors();
  }

  saveBook(): void {
    const data = {
      title: this.book.title,
      authorId: this.book.authorId,
      noCopies: this.book.noCopies
    };

    console.log(data);

    this.booksService.create(data)
      .subscribe(
        response => {
          this.router.navigate(['/books'])
          console.log(response);
        },
        error => {
          console.log(error);
        });
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

}
