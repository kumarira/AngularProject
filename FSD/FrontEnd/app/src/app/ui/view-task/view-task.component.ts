import { Component, OnInit } from '@angular/core';
import {TaskService} from '../../service/task.service';
import {task} from '../../Models/task.model';
import { BrowserModule } from '@angular/platform-browser';
@Component({
  selector: 'app-view-task',
  templateUrl: './view-task.component.html',
  styleUrls: ['./view-task.component.css']
})
 
export class ViewTaskComponent implements OnInit {
  taskslist=  ["Task1","Task2"];
  tasks: task[];

  constructor(private taskservice:TaskService) { }

  ngOnInit() {
      
      this.taskservice.getTaskdata()
      .subscribe(data=>
        { this.tasks=data;
      });
  }

}
