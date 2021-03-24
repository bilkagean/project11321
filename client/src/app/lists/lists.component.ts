import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-lists',
  templateUrl: './lists.component.html',
  styleUrls: ['./lists.component.css']
})
export class ListsComponent implements OnInit {
  users:any;

  constructor(private http:HttpClient) { }

  ngOnInit() {
    this.http.get('https://localhost:5001/api/users').subscribe(res=>{
      this.users = res;
    },error =>{console.log(error)})
  }

}
