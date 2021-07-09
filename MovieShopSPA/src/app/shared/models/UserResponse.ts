export class UserResponse {
  email: string;
  familyName:string;
  givenName:string;
  nameId:number;
  constructor() {
    this.nameId=0 ;
      this.email="";
      this.familyName="";
      this.givenName="";
  }
}
