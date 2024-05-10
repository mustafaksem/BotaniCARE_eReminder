import { Component, ElementRef, ViewChild, viewChild } from '@angular/core';
import { GardenerModel } from '../../models/gardener.model';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule, DatePipe } from '@angular/common';
import { DxSchedulerModule } from 'devextreme-angular';
import { HttpService } from '../../services/http.service';
import { ReminderModel } from '../../models/reminder.model';
import { CreateReminderModel } from '../../models/create-reminder.model';
import { FormValidateDirective } from 'form-validate-angular';
import { SwalService } from '../../services/swal.service';
import { PlantModal } from '../../models/plant.model';

declare const $:any;

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [FormsModule,CommonModule,DxSchedulerModule,FormValidateDirective],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
  providers:[DatePipe]
})
export class HomeComponent {
  gardeners: GardenerModel[]=[];
  selectedGardenerId:string="";

  @ViewChild("addModalCloseBtn") addModalCloseBtn:ElementRef<HTMLButtonElement> | undefined;

  reminder :ReminderModel[]=[]
  createModel: CreateReminderModel = new CreateReminderModel();

  constructor(
    private http:HttpService,
    private date:DatePipe,
    private swal: SwalService
  ){}

  getAll(){
    this.http.post<GardenerModel[]>("Gardeners/GetAll",{},(res)=>{
      this.gardeners=res.data;
    });
  }
  getAllReminders(){
      if(this.selectedGardenerId){
        this.http.post<ReminderModel[]>("Reminders/GetAllGardenerById",{
          gardenerId: this.selectedGardenerId },(res)=>{
          this.reminder=res.data;
      });
    }
  }
  onAppointmentFormOpening(e:any){
    e.cancel=true;
    this.createModel.startDate=this.date.transform(e.appointmentData.startDate, "dd.MM.yyyy HH:mm")?? "";
    this.createModel.endDate=this.date.transform(e.appointmentData.endDate, "dd.MM.yyyy HH:mm")?? "";
    this.createModel.gardenerId=this.selectedGardenerId;

    $("#addModal").modal("show");
  }

  getPlantByName(){
    this.http.post<PlantModal>("Reminders/GetPlantByName",{name:this.createModel.name}, res=>{
      if(res.data ===null){
        this.createModel.description="";
        this.createModel.plantId=null;

        return
      } ;

        this.createModel.plantId=res.data.id;
        this.createModel.name=res.data.name;
        this.createModel.description=res.data.description;
    })
  }

  create(form: NgForm){
    if(form.valid){
      this.http.post("Reminders/Create", this.createModel, res=>{
        this.swal.callToast(res.data);
        this.addModalCloseBtn?.nativeElement.click();
        this.createModel = new CreateReminderModel();
        this.getAllReminders();
      });
    }
  }
  onAppointmentDeleted(e:any){
    e.cancel=true; 
  }
  onAppointmentDeleting(e:any){
    e.cancel=true;

    this.swal.callSwal("Delete reminder?", "Do you want to delete this reminder?", ()=>{
      this.http.post<string>("Reminders/DeleteById", {id:e.appointmentData.id}, res =>{
        this.swal.callToast(res.data,"info");
        this.getAllReminders();
      })
    })
  }

  onAppointmentUpdating(e:any){
    e.cancel=true;
    
    const data={
      id:e.oldData.id,
      startDate:this.date.transform(e.newData.startDate,"dd.MM.yyyy HH:mm"),
      endDate:this.date.transform(e.newData.endDate,"dd.MM.yyyy HH:mm"),
    };

    this.http.post<string>("Reminders/Update", data,res=>{
      this.swal.callToast(res.data);
      this.getAllReminders();
    })
  }
}
