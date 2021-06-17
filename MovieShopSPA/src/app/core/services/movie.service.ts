import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { MovieCard } from 'src/app/shared/models/MovieCard';
import { MovieDetail } from 'src/app/shared/models/MovieDetail';
import { MovieDetailsComponent } from 'src/app/movies/movie-details/movie-details.component';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  // HttpClient class from Angular to coomunicate with API
  // Ctrl+P for Project file names searching
  // Ctr+Shift+P VS Code searching
  // Alt+Shift+f => Formatting your code
  // Ctr+F search for text inside a file
  // Ctrl+Shift+f for searching text throughout the project

  constructor(private http: HttpClient) { }

  getTopRevenueMovies(): Observable<MovieCard[]> {
    //  call the API to get the json data
   
    return this.http.get(`${environment.apiUrl}${'movie/toprevenue'}`)
    .pipe(map(resp => resp as MovieCard[]))

  }

  getMovieDetails(id:Number): Observable<MovieDetail> {
    //  call the API to get the json data
   
    return this.http.get(`${environment.apiUrl}${'movie/details?id='}${id}`)
    .pipe(map(resp => resp as MovieDetail))

  }

//   MovieCOmponent should read the id value from Route inside ngOninit
// API call to MovieService
// getMovieDetails
// return the MovieDetails model to the view and show data in View.



// MovieService
// getMovieDetails(id: number) : Observable<MovieDetails>
// {
//   //call the API
//   //localhost:433/api/movies/23
// }

}
