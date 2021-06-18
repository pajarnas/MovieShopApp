import { Component, OnInit } from '@angular/core';
import { MovieService } from '../core/services/movie.service';
import { MovieCard } from '../shared/models/MovieCard';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {

  constructor(private movieService:MovieService) { }

  movies!:MovieCard[];

  ngOnInit(): void {
    // call our service
    this.movieService.getTopRevenueMovies().subscribe(
        m=>{
          this.movies = m;
        }
    );
  }

}
