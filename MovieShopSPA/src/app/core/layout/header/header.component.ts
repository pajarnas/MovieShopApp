import {Component, OnChanges, OnInit} from '@angular/core';
import {UserService} from '../../services/user.service'
import {UserResponse} from "../../../shared/models/UserResponse";
import {Router} from "@angular/router";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit,OnChanges {


  isAuth!:boolean;
  currentUserModel!:UserResponse;
  constructor(private userService:UserService,private router:Router) { }

  ngOnInit(): void {
    this.userService.isAuthenticatedSubject.subscribe((auth) => {
      this.isAuth = auth;
      console.log(this.isAuth)
    });
    this.userService.currentUser.subscribe((user) => {
      this.currentUserModel = user;
      console.log(this.currentUserModel)
    });
  }
  ngOnChanges() :void{

  }

  logout():void{
    this.userService.logout();

    this.router.navigateByUrl('/login');
  }


}
