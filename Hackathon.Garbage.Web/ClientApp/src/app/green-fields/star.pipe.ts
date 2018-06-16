import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'star'
})
export class StarPipe implements PipeTransform {

  transform(value: number, args?: any): string {


    return  ` <text>&#9734;</text>`


  }

}
