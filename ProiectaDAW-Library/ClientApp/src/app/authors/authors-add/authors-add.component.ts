import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthorsService } from 'src/app/services/authors.service';

@Component({
  selector: 'app-authors-add',
  templateUrl: './authors-add.component.html',
  styleUrls: ['./authors-add.component.css']
})
export class AuthorsAddComponent implements OnInit {

  author = {
    name: ''
  };
  submitted = false;

  constructor(private authorsService: AuthorsService,
              private router: Router) { }

  ngOnInit() {
  }

  saveAuthor(): void {
    const data = {
      name: this.author.name
    };

    this.authorsService.create(data)
      .subscribe(
        response => {
          this.router.navigate(['/authors'])
          console.log(response);
          this.submitted = true;
        },
        error => {
          console.log(error);
        });
  }

  newTutorial(): void {
    this.submitted = false;
    this.author = {
      name: ''
    };
  }

}
