import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthorsService } from 'src/app/core/services/authors/authors.service';
import { BooksService } from 'src/app/core/services/books/books.service';

@Component({
  selector: 'app-books-details',
  templateUrl: './books-details.component.html',
  styleUrls: ['./books-details.component.css']
})
export class BooksDetailsComponent implements OnInit {

  currentBook = null;
  message = '';
  authors = [];

  constructor(private bookService: BooksService,
              private authorsService: AuthorsService,
              private route: ActivatedRoute,
              private router: Router) { }

  ngOnInit(): void {
    this.message = '';
    this.getBook(this.route.snapshot.paramMap.get('id'));
    this.retrieveAuthors();
  }

  getBook(id): void {
    this.bookService.get(id)
      .subscribe(
        data => {
          this.currentBook = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

  updateBook(): void {
    this.bookService.update(this.currentBook.id, this.currentBook)
      .subscribe(
        response => {
          this.router.navigate(['/books'])
          // console.log(response);
          // this.message = 'The book was updated successfully!';
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
