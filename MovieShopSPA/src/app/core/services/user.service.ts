import { HttpClient , HttpHeaders} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable,BehaviorSubject } from 'rxjs';
import {catchError, map} from 'rxjs/operators';

import { MovieDetail } from 'src/app/shared/models/MovieDetail';
import { MovieDetailsComponent } from 'src/app/movies/movie-details/movie-details.component';
import { environment } from 'src/environments/environment';
import {LoginRequest} from "../../shared/models/LoginRequest";
import {TokenModel} from "../../shared/models/TokenModel";
import {UserResponse} from "../../shared/models/UserResponse";
import {JwtHelperService} from "@auth0/angular-jwt";
import {tryCatch} from "rxjs/internal-compatibility";

import {JwtStorageService} from "./jwt-storage-service.service";
import {MovieCard} from "../../shared/models/MovieCard";
import {ProfileResponse} from "../../shared/models/ProfileResponse";
import {PurchasedMovie, UserPurchasedMoviesResponse} from "../../shared/models/UserPurchasedMoviesResponse";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private currentUserSubject = new BehaviorSubject(<UserResponse>({} as UserResponse));

  public currentUser = this.currentUserSubject.asObservable();
  private userResponse!: UserResponse;

  public isAuthenticatedSubject = new BehaviorSubject<boolean>(false);
  public isAuthenticated = this.isAuthenticatedSubject.asObservable();

  constructor(private http: HttpClient,private jwtService:JwtStorageService) {

  }

  getTopRevenueMovies(): Observable<MovieCard[]> {
    //  call the API to get the json data

    return this.http.get(`${environment.apiUrl}${'movie/toprevenue'}`)
      .pipe(map(resp => resp as MovieCard[]))

  }

  login(requestBody:LoginRequest): Observable<boolean>  {
    //  call the API to get the json data

    return this.http.post(`${environment.apiUrl}${'Account/login'}`,requestBody)
      .pipe(map((res:any)=>
      {


           this.jwtService.saveToken(res.token)
           this.populateUserResponse();
           return true;
    }));
  }

  purchases():Observable<UserPurchasedMoviesResponse>{
    let headers: HttpHeaders;
    headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    headers = headers.append("Authorization","bearer "+this.jwtService.getToken());
    return this.http.get(`${environment.apiUrl}${'User/purchases'}`,{headers:headers})
      .pipe(map(res=> res as UserPurchasedMoviesResponse));
  }

  logout(): void{

     this.jwtService.destroyToken();
    this.populateUserResponse();
  }

  profile(): Observable<ProfileResponse>{

      let headers: HttpHeaders;
      headers = new HttpHeaders();
      headers.append('Content-Type', 'application/json');
      headers = headers.append("Authorization","bearer "+this.jwtService.getToken());





    return this.http.get(`${environment.apiUrl}${'Account/profile'}`,{headers:headers}).pipe(map(res=> res as ProfileResponse));
  }

  edit_profile(requestBody:ProfileResponse): Observable<boolean>{


    let headers: HttpHeaders;
    headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    headers = headers.append("Authorization","bearer "+this.jwtService.getToken());


    return this.http.post(`${environment.apiUrl}${'Account/EditProfile'}`,requestBody,{headers:headers}).pipe(map(res=> {
      return true;
    }));

  }



  populateUserResponse():void{
    //get the token from localstorage and decode the token and convert to userRespone object and push it to currentUserObject

    const myJwtToken = this.jwtService.getToken();
    const helper = new JwtHelperService();
    if(myJwtToken != null && !helper.isTokenExpired(myJwtToken)){

      const decodedToken = JSON.parse(JSON.stringify(helper.decodeToken(myJwtToken)));
      this.userResponse = decodedToken as UserResponse;
      this.userResponse = new UserResponse();
      this.userResponse.nameId = decodedToken['nameid'];
      this.userResponse.givenName = decodedToken['given_name'];
      this.userResponse.familyName = decodedToken['family_name'];
      this.userResponse.email = decodedToken['email'];


        this.currentUserSubject.next(this.userResponse);
      this.isAuthenticatedSubject.next(true);
    }else {
      this.isAuthenticatedSubject.next(false);
      this.currentUserSubject.next(new UserResponse());
    }


  }




}
