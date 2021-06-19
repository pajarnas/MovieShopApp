import {PurchasedMovie} from "./UserPurchasedMoviesResponse";
import {UserRegisterRequest} from "./UserRegisterRequest";

export interface ProfileResponse {
  email:string;
  password:string;
  firstName:string;
  lastName:string;
    dateOfBirth: Date;
    phoneNumber?: any;
    lastLoginDateTime: Date;
    purchasedMovies: PurchasedMovie[];
  }

