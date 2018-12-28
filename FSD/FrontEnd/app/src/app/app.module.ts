import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ViewTaskComponent } from './ui/view-task/view-task.component';
import { AddTaskComponent } from './ui/add-task/add-task.component';
import { TaskService } from './service/task.service'; 
import { CommonModule} from '@angular/common';
import { Ng5SliderModule } from 'ng5-slider';

@NgModule({
  declarations: [     
    AppComponent,
    ViewTaskComponent,
    AddTaskComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    HttpClientModule,
    AppRoutingModule,
    Ng5SliderModule
  ],
  providers: [TaskService],
  bootstrap: [AppComponent]
})
export class AppModule { }
