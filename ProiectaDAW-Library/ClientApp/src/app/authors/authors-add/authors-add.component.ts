import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthorsService } from 'src/app/core/services/authors/authors.service';

@Component({
  selector: 'app-authors-add',
  templateUrl: './authors-add.component.html',
  styleUrls: ['./authors-add.component.css']
})
export class AuthorsAddComponent implements OnInit {

  author = {
    name: ''
  };

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
        },
        error => {
          console.log(error);
        });
  }

}
