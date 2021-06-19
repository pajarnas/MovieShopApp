import { Component, OnInit } from '@angular/core';

import {UserService} from "../../core/services/user.service";
import {ProfileResponse} from "../../shared/models/ProfileResponse";


@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  profileResponse!: ProfileResponse
  constructor(private userService:UserService) { }

  ngOnInit(): void {
      this.profile();
  }

  profile():void{

  }

}
