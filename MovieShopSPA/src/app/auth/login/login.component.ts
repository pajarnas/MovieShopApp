import { Component, OnInit } from '@angular/core';
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

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent   {

  LoginForm: FormGroup;
  Email: AbstractControl;
  Password:AbstractControl;
  private Token! : string;
  constructor(fb: FormBuilder,private userService:UserService) {

    this.LoginForm = fb.group({
      'Email':  ['', Validators.required],
      'Password':['',Validators.required]
    });

    this.Email = this.LoginForm.controls['Email'];
    this.Password = this.LoginForm.controls['Password'];
  }
  onSubmit(form: any): void {
    console.log('you submitted value:', form);
    this.userService.login(form).subscribe(m=>{
      console.log(m);
      this.Token=m['token'];
    });


  }
}

