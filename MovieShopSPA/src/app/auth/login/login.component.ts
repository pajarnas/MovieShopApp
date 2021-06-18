// noinspection DuplicatedCode

import { Component, OnInit } from '@angular/core';
import {LoginRequest} from "../../shared/models/LoginRequest";


import {


  AbstractControl,
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators
} from "@angular/forms";
import {UserService} from "../../core/services/user.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent   {

  UserLogin: LoginRequest = {
    email:"",
    password : ""
  };


  constructor(fb: FormBuilder,private userService:UserService,private router:Router) {

    this.LoginForm = fb.group({
      'Email':  ['', Validators.required],
      'Password':['',Validators.required]
    });

  }

  ngOnInit(): void{

  }

  login( ):void{
    this.userService.login(this.UserLogin).subscribe(m=>{

      if(m){


        this.router.navigate(['/']).then(r => r);
        this.isInvalidLogin = false;
      }
      else {
        this.isInvalidLogin = true;
      }

    });

  }

  // Login By formValue
  LoginForm: FormGroup;

  isInvalidLogin!: boolean ;

  onSubmit(form: any): void {

    this.UserLogin.email=form.Email;
    this.UserLogin.password=form.Password;
    this.userService.login(this.UserLogin).subscribe(m=>{

      if(m){


        this.router.navigate(['/']).then(r => r);
        this.isInvalidLogin = false;
      }
      else {
        this.isInvalidLogin = true;
      }

    });


  }
}

