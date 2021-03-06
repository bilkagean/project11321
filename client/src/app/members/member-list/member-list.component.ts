import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_models/user';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {
  users:any;

  constructor(private http:HttpClient) { }

  ngOnInit(): void {
   this.getUsers();
  }

  
  getUsers(){
    this.http.get('https://localhost:5001/api/users').subscribe(res => {this.users = res;})
  }
}
