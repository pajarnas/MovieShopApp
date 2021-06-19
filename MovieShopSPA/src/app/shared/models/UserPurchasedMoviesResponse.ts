import {MovieCard} from "./MovieCard";


export interface PurchasedMovie extends MovieCard{
    purchaseDateTime: Date;

  }

  export interface UserPurchasedMoviesResponse {
    userId: number;
    purchasedMovies: PurchasedMovie[];
  }



