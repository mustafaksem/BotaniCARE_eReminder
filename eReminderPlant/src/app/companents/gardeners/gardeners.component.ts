import { Component, ElementRef, OnInit, ViewChild, viewChild } from '@angular/core';
import { RouterLink } from '@angular/router';
import { HttpService } from '../../services/http.service';
import { GardenerModel } from '../../models/gardener.model';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { FormValidateDirective } from 'form-validate-angular';
import { SwalService } from '../../services/swal.service';
import { GardenerPipe } from '../../pipe/gardener.pipe';

@Component({
  selector: 'app-gardeners',
  standalone: true,
  imports: [CommonModule ,RouterLink, FormsModule, FormValidateDirective,GardenerPipe ],
  templateUrl: './gardeners.component.html',
  styleUrl: './gardeners.component.css'
})
export class GardenersComponent implements OnInit {
  gardeners: GardenerModel[] = [];

  @ViewChild("addModalCloseBtn") addModalCloseBtn: ElementRef<HTMLButtonElement>| undefined;
  @ViewChild("updateModalCloseBtn") updateModalCloseBtn: ElementRef<HTMLButtonElement>| undefined;

  createModel: GardenerModel=new GardenerModel();
  updateModel:GardenerModel=new GardenerModel();

  search:string="";

  constructor(   
    private http:HttpService,
    private swal: SwalService
  ){}

  ngOnInit(): void {
    this.getAll();    
  }

  getAll(){
    this.http.post<GardenerModel[]>("Gardeners/GetAll",{},(res)=>{
      this.gardeners=res.data;
    });
  }

  add(form:NgForm){
    if(form.valid){
      this.http.post("Gardeners/Create",this.createModel,(res)=>{
        this.swal.callToast(res.data,"success");
        this.getAll();
        this.addModalCloseBtn?.nativeElement.click();
        this.createModel=new GardenerModel();
      })
    }
  }
  delete(id:string,fullName:string){
    this.swal.callSwal("Delete Gardener", `Do you want to delete ${fullName}? `,()=>{
      this.http.post<string>("Gardeners/DeleteById",{id:id},(res)=> {
        this.swal.callToast(res.data,"info");
        this.getAll();
      })
    })
  }

  get(data: GardenerModel){
    this.updateModel= {...data};
  }

  update(form:NgForm){
    if(form.valid){
      this.http.post("Gardeners/Update",this.updateModel,(res)=>{
        this.swal.callToast(res.data,"success");
        this.getAll();
        this.updateModalCloseBtn?.nativeElement.click();
      });
    }
  }
}
