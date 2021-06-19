import { NgModule } from '@angular/core';

import { BrowserModule } from '@angular/platform-browser';

import {HttpClientModule} from '@angular/common/http'
import {DatePipe} from '@angular/common';

//Form Related
import { FormsModule, ReactiveFormsModule} from '@angular/forms';

//routing user-defined
import { AppRoutingModule } from './app-routing.module';

//app app-root
import { AppComponent } from './app.component';
//Home
import { HomeComponent } from './home/home.component';
//Generes
import { GeneresComponent } from './generes/generes.component';
//Shared
import { MovieCardComponent } from './shared/components/movie-card/movie-card.component';
//Header, Footer
import { HeaderComponent } from './core/layout/header/header.component';
import { FooterComponent } from './core/layout/footer/footer.component';
//admin
import { CreateMovieComponent } from './admin/create-movie/create-movie.component';
import { CreateCastComponent } from './admin/create-cast/create-cast.component';
import { UpdateMovieComponent } from './admin/update-movie/update-movie.component';
//auth
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
//user
import { PurchasesComponent } from './user/purchases/purchases.component';
import { FavoritesComponent } from './user/favorites/favorites.component';
import { ProfileComponent } from './user/profile/profile.component';
import { ReviewsComponent } from './user/reviews/reviews.component';
//movies
import { MovieDetailsComponent } from './movies/movie-details/movie-details.component';
import { MovieListComponent } from './movies/movie-list/movie-list.component';




@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    GeneresComponent,
    MovieCardComponent,
    HeaderComponent,
    FooterComponent,

    CreateMovieComponent,
    CreateCastComponent,
    UpdateMovieComponent,
    LoginComponent,
    RegisterComponent,
    PurchasesComponent,
    FavoritesComponent,
    ProfileComponent,
    ReviewsComponent,
    MovieDetailsComponent,
    MovieListComponent,



  ],
  imports: [
    BrowserModule,
    AppRoutingModule,// <-- routes Added the imported into this
    HttpClientModule,
    FormsModule,         // <-- add this
    ReactiveFormsModule
  ],
  providers: [HttpClientModule,DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }

