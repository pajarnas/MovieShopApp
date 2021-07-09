import { Component, OnInit } from '@angular/core';

import {UserService} from "../../core/services/user.service";
import {ProfileResponse} from "../../shared/models/ProfileResponse";
import {Router} from "@angular/router";


@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  profileResponse!: ProfileResponse
  constructor(private userService:UserService,private router:Router) { }
  selectedProfileResponse:ProfileResponse = new ProfileResponse();
  ngOnInit(): void {
      this.profile();
  }

  profile():void{
    this.userService.profile().subscribe(m=>this.profileResponse=m);

  }

  update(profile:ProfileResponse) {
    console.log("222")
    this.profileResponse = profile;
    let isSucceed = false;
    this.userService.edit_profile(profile).subscribe(m=>isSucceed=m);
    if(isSucceed){
      console.log("successful");
      this.router.navigate(["/profile"]);
    }

  }

  edit() {
    Object.assign(this.selectedProfileResponse,this.profileResponse)

  }
}
