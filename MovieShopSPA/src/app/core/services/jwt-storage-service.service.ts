import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class JwtStorageService {

  getToken(): string {
    let token = localStorage.getItem('token');
    if(token!=null)
       return token;
    return "";
  }

  saveToken(token: string) {
    localStorage.setItem('token', token);
  }

  destroyToken() {
    localStorage.removeItem('token');
  }
}
