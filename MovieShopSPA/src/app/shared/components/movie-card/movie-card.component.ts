import { Component, Input, OnInit } from '@angular/core';
import { MovieCard } from '../../models/MovieCard';

@Component({
  selector: 'app-movie-card',
  templateUrl: './movie-card.component.html',
  styleUrls: ['./movie-card.component.css']
})
export class MovieCardComponent implements OnInit {

  constructor() { }
  @Input() movieCard!: MovieCard;
  ngOnInit(): void {
    console.log(this.movieCard);
  }

}
