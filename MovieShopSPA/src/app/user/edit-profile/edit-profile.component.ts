import {Component, Input, OnInit, Output, EventEmitter} from '@angular/core';

import {ProfileResponse} from "../../shared/models/ProfileResponse";

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css']
})
export class EditProfileComponent implements OnInit {

  constructor() { }
  @Input()
  profileResponse:ProfileResponse = new ProfileResponse();
  @Output()
  profileResponseChange:EventEmitter<ProfileResponse> = new EventEmitter<ProfileResponse>();

  ngOnInit(): void {
  }

  save() {
    console.log("???")
    this.profileResponseChange.emit(this.profileResponse);
  }



}
