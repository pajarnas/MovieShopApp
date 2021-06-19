import {PurchasedMovie} from "./UserPurchasedMoviesResponse";
import {UserRegisterRequest} from "./UserRegisterRequest";

export interface ProfileResponse extends UserRegisterRequest{

    dateOfBirth: Date;
    phoneNumber?: any;
    lastLoginDateTime: Date;
    purchasedMovies: PurchasedMovie[];
  }

