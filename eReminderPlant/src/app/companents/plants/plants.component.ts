import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { PlantModal } from '../../models/plant.model';
import { HttpService } from '../../services/http.service';
import { SwalService } from '../../services/swal.service';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { FormValidateDirective } from 'form-validate-angular';
import { PlantPipe } from '../../pipe/plant.pipe';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-plant',
  standalone: true,
  imports: [CommonModule,FormsModule,RouterLink, FormValidateDirective,PlantPipe],
  templateUrl: './plants.component.html',
  styleUrl: './plants.component.css'
})
export class PlantsComponent implements OnInit {
  plants: PlantModal[] = [];

  @ViewChild("addModalCloseBtn") addModalCloseBtn: ElementRef<HTMLButtonElement>| undefined;
  @ViewChild("updateModalCloseBtn") updateModalCloseBtn: ElementRef<HTMLButtonElement>| undefined;

  createModel: PlantModal=new PlantModal();
  updateModel:PlantModal=new PlantModal();

  search:string="";

  constructor(   
    private http:HttpService,
    private swal: SwalService
  ){}

  ngOnInit(): void {
    this.getAll();    
  }

  getAll(){
    this.http.post<PlantModal[]>("Plants/GetAll",{},(res)=>{
      this.plants=res.data;
    });
  }

  add(form:NgForm){
    if(form.valid){
      this.http.post("Plants/Create",this.createModel,(res)=>{
        this.swal.callToast(res.data,"success");
        this.getAll();
        this.addModalCloseBtn?.nativeElement.click();
        this.createModel=new PlantModal();
      })
    }
  }
  delete(id:string,fullName:string){
    this.swal.callSwal("Delete Plant", `Do you want to delete ${name}? `,()=>{
      this.http.post<string>("Plants/DeleteById",{id:id},(res)=> {
        this.swal.callToast(res.data,"info");
        this.getAll();
      })
    })
  }

  get(data: PlantModal){
    this.updateModel= {...data};
  }

  update(form:NgForm){
    if(form.valid){
      this.http.post("Plants/Update",this.updateModel,(res)=>{
        this.swal.callToast(res.data,"success");
        this.getAll();
        this.updateModalCloseBtn?.nativeElement.click();
      });
    }
  }
}
