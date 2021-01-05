import { Pipe, PipeTransform } from '@angular/core';

@Pipe({name: 'exemplare'})
export class ExemplarePipe implements PipeTransform {
  transform(nr: number): string {
    if (nr == 1) {
      return nr + " exemplar";
    } else {
      return nr + " exemplare";
    }
  }
}
