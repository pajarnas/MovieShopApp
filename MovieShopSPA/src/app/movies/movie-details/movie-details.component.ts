import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MovieService } from 'src/app/core/services/movie.service';
import {MovieDetail} from 'src/app/shared/models/MovieDetail'
import { DatePipe } from '@angular/common';
@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {

  constructor(private route: ActivatedRoute,private movieService:MovieService,private datePipe:DatePipe) { }

  id!: number;
  movie!:MovieDetail;

  ngOnInit(): void {
    // read the id from the Route
    console.log('inside Movie details page');
    this.route.paramMap.subscribe(
      params => {
        console.log(params);
        console.log(params.get('id'));
        this.id = Number(params.get('id'));
        console.log('Movie Id:' + this.id);
        // call the MovieService that will call the Movie Details API.
        this.movieService.getMovieDetails(this.id).subscribe(
          m=>{

            this.movie = m;
            this.movie.releaseDate = m.releaseDate;
            console.log(this.movie);

          }
      );
      }
    )

  }

}
