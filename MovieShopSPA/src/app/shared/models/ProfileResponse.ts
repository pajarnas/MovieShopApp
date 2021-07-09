import {PurchasedMovie} from "./UserPurchasedMoviesResponse";
import {UserRegisterRequest} from "./UserRegisterRequest";

export class ProfileResponse {
  email!:string;
  password!:string;
  firstName!:string;
  lastName!:string;
    dateOfBirth!: Date;
    phoneNumber!: string;
    lastLoginDateTime!: Date;
    purchasedMovies!: PurchasedMovie[];
  }

