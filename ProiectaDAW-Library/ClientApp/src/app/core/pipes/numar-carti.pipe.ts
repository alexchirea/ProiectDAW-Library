import { Pipe, PipeTransform } from '@angular/core';

@Pipe({name: 'numarCarti'})
export class NumarCartiPipe implements PipeTransform {
  transform(autor: any): number {
    return autor.books.length;
  }
}
