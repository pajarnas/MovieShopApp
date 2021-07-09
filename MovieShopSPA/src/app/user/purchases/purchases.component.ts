import { Component, OnInit } from '@angular/core';
import {UserPurchasedMoviesResponse} from "../../shared/models/UserPurchasedMoviesResponse";
import {UserService} from "../../core/services/user.service";

@Component({
  selector: 'app-purchases',
  templateUrl: './purchases.component.html',
  styleUrls: ['./purchases.component.css']
})
export class PurchasesComponent implements OnInit {

  constructor(private userService: UserService) { }
  userPurchasedMovies!: UserPurchasedMoviesResponse;

  ngOnInit(): void {
      this.userService.purchases().subscribe(m=>this.userPurchasedMovies=m);
  }



}
