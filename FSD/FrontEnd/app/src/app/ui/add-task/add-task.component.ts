import { Component, OnInit } from '@angular/core';
import { Options } from 'ng5-slider';

@Component({
  selector: 'app-add-task',
  templateUrl: './add-task.component.html',
  styleUrls: ['./add-task.component.css']
})
export class AddTaskComponent implements OnInit {
  taskslist=  ["Task1","Task2"];
  value: number = 5;
  options: Options = {
    floor: 0,
    ceil: 10
  }; 
  selectedRam:object;
  constructor() { }
  
  ngOnInit() {
  }
  private data: any;

  addtask(){
      // do the thing
      this.data = "some data not matter how you got it";
      debugger;
  }
  resettask()
  {    
  }

  setRam(value){
    this.selectedRam = value;
    console.log(this.selectedRam);
}
}
