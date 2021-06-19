import {Component, Input, OnInit} from '@angular/core';

import {PurchasedMovie} from "../../models/UserPurchasedMoviesResponse";

@Component({
  selector: 'app-purchased-movie-item',
  templateUrl: './purchased-movie-item.component.html',
  styleUrls: ['./purchased-movie-item.component.css']
})
export class PurchasedMovieItemComponent implements OnInit {

  constructor() { }
  @Input() purasedMovie!: PurchasedMovie;
  ngOnInit(): void {
  }

}
