import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthorsService } from 'src/app/services/authors.service';

@Component({
  selector: 'app-authors-details',
  templateUrl: './authors-details.component.html',
  styleUrls: ['./authors-details.component.css']
})
export class AuthorsDetailsComponent implements OnInit {

  currentAuthor = null;
  message = '';

  constructor(private authorService: AuthorsService,
              private route: ActivatedRoute,
              private router: Router) { }

  ngOnInit(): void {
    this.message = '';
    this.getAuthor(this.route.snapshot.paramMap.get('id'));
  }

  getAuthor(id): void {
    this.authorService.get(id)
      .subscribe(
        data => {
          this.currentAuthor = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

  updateAuthor(): void {
    this.authorService.update(this.currentAuthor.id, this.currentAuthor)
      .subscribe(
        response => {
          this.router.navigate(['/authors'])
          // console.log(response);
          // this.message = 'The author was updated successfully!';
        },
        error => {
          console.log(error);
        });
  }

}
