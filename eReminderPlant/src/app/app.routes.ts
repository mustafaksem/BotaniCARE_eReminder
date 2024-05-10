import { Routes } from '@angular/router';
import { LoginComponent } from './companents/login/login.component';
import { LayoutsComponent } from './companents/layouts/layouts.component';
import { HomeComponent } from './companents/home/home.component';
import { NotFoundComponent } from './companents/not-found/not-found.component';
import { inject } from '@angular/core';
import { AuthService } from './services/auth.service';
import { GardenersComponent } from './companents/gardeners/gardeners.component';
import { PlantsComponent } from './companents/plants/plants.component';


export const routes: Routes = [
    {
        path:"login",
        component:LoginComponent
    },
    {
        path:"",
        component:LayoutsComponent,
        canActivateChild:[()=> inject(AuthService).isAuthenticated()],
        children:[
            {
                path:"",
                component:HomeComponent
            },
            {
                path:"gardeners",
                component:GardenersComponent
            },
            {
                path:"plants",
                component:PlantsComponent
            }
        ]
    },
    {
        path:"**",
        component:NotFoundComponent
    }
];
