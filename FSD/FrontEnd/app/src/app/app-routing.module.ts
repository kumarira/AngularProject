import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddTaskComponent } from './ui/add-task/add-task.component';
import { ViewTaskComponent } from './ui/view-task/view-task.component';

const routes: Routes = [
  {path:'Add',component:AddTaskComponent},
  {path:'View',component:ViewTaskComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

 