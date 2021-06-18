import { Component, OnInit } from '@angular/core';
import {UserService} from '../../services/user.service'
import {UserResponse} from "../../../shared/models/UserResponse";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {


  isAuth!:boolean;
  currentUserModel!:UserResponse;
  constructor(private userService:UserService) { }

  ngOnInit(): void {
    this.userService.isAuthenticatedSubject.subscribe(auth => {
      this.isAuth = auth;
    });
    this.userService.currentUser.subscribe(user => {
      this.currentUserModel = user;

      console.log(this.currentUserModel);
    });
  }


}
