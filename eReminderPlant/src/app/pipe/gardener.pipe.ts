import { Pipe, PipeTransform } from '@angular/core';
import { GardenerModel } from '../models/gardener.model';

@Pipe({
  name: 'gardener',
  standalone: true
})
export class GardenerPipe implements PipeTransform {

  transform(value: GardenerModel[], search:string): GardenerModel[] {
    if(!search){
      return value;
    }
    return value.filter(p=> 
      p.fullName.toLocaleLowerCase().includes(search.toLocaleLowerCase())||
      p.mail.toLocaleLowerCase().includes(search.toLocaleLowerCase())
    )
  }

}
