import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
//import { Jsonp, URLSearchParams } from '@angular/http';  
import { Observable, of } from 'rxjs';

import   'rxjs/add/operator/map';  
import {task} from "../Models/task.model";
@Injectable({
  providedIn: 'root'
})
export class TaskService { 
  constructor(private _http:HttpClient) { }
  urlTask="http://www.omdbapi.com/?t=%27matrix%27&apikey=8b8b3f2";
  getTaskdata() 
  {         
      let faketask = [{Name: 'Task1', parent: 1, Priority: 2, startDate: '10/01/2018',EndDate:'10/02/2018'},
      {Name: 'Task2', parent: 0, Priority: 1, startDate: '10/01/2018',EndDate:'10/02/2018'},      
    ];
     // return of(faketask); 
      return   this._http.get<task[]>(this.urlTask);  
  }  

}

