import { Pipe, PipeTransform } from '@angular/core';
import { PlantModal } from '../models/plant.model';

@Pipe({
  name: 'plant',
  standalone: true
})
export class PlantPipe implements PipeTransform {

  transform(value: PlantModal[], search:string): PlantModal[] {
    if(!search){
      return value;
    }
    return value.filter(p=> 
      p.name.toLocaleLowerCase().includes(search.toLocaleLowerCase())||
      p.description.toLocaleLowerCase().includes(search.toLocaleLowerCase())
    )
  }

}
