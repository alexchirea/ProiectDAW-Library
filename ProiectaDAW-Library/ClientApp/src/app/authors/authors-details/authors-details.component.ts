import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthorsService } from 'src/app/core/services/authors/authors.service';

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
              private router: Router,
              private toastService: ToastrService) { }

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
          this.toastService.success("Autorul a fost salvat");
          this.router.navigate(['/authors'])
          // console.log(response);
          // this.message = 'The author was updated successfully!';
        },
        error => {
          console.log(error);
        });
  }

}
