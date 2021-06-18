import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { MovieCard } from 'src/app/shared/models/MovieCard';
import { MovieDetail } from 'src/app/shared/models/MovieDetail';
import { MovieDetailsComponent } from 'src/app/movies/movie-details/movie-details.component';
import { environment } from 'src/environments/environment';
import {LoginRequest} from "../../shared/models/LoginRequest";
import {TokenModel} from "../../shared/models/TokenModel";

@Injectable({
  providedIn: 'root'
})
export class UserService {



  constructor(private http: HttpClient) { }

  getTopRevenueMovies(): Observable<MovieCard[]> {
    //  call the API to get the json data

    return this.http.get(`${environment.apiUrl}${'movie/toprevenue'}`)
      .pipe(map(resp => resp as MovieCard[]))

  }

  login(requestBody:LoginRequest): Observable<TokenModel>  {
    //  call the API to get the json data
    return this.http.post(`${environment.apiUrl}${'Account/login'}`,requestBody).pipe(map(res=>res as TokenModel));

  }


}
