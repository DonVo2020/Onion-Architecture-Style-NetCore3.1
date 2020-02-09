import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Router } from '@angular/router'

@Injectable()
export class AuthService {
  private _baseUrl ="https://localhost:44353/api/v1/account";
  //private _baseAdminUrl="https://localhost:44370/adminservice";
  private _registerUrl = this._baseUrl+"/register";
  private _loginUrl = this._baseUrl+"/login";
  private _registerMentorUrl = this._baseUrl+"/register";
  private _loginDevUrl = this._baseUrl+"/login";
  private _loginAdminUrl = this._baseUrl+"/login";
  //public _blockUserUrl =this._baseAdminUrl+"/blockunblock/";

  constructor(private http: HttpClient,
              private _router: Router) { }

  registerUser(user) {
    return this.http.post<any>(this._registerUrl, user)
  }

  loginUser(user) {
    return this.http.post<any>(this._loginUrl, user)
  }

  logoutUser() {
    localStorage.removeItem('token')
    localStorage.removeItem('userEmail')
    this._router.navigate(['/'])
  }

  registerDev(user) {
    return this.http.post<any>(this._registerMentorUrl, user)
  }

  loginDev(user) {
    return this.http.post<any>(this._loginDevUrl, user)
  }

  logoutDev() {
    localStorage.removeItem('token')
    localStorage.removeItem('developerEmail')
    this._router.navigate(['/'])
  }

  //getRoleByEmail(email: string) {
  //  return this.http.get<any>('https://localhost:44353/api/v1/account/login/' + email);
  //}



  loginAdmin(user) {
    return this.http.post<any>(this._loginAdminUrl, user)
  }

  logoutAdmin() {
    localStorage.removeItem('token')
    localStorage.removeItem('adminEmail')
    //this._router.navigate(['/admin-login'])
    this._router.navigate(['/'])
  }

  getToken() {
    return localStorage.getItem('token');
  }

  getMentorToken() {
    return localStorage.getItem('token')
  }

  getAdminToken() {
    return localStorage.getItem('token')
  }

  loggedIn() {
    return !!localStorage.getItem('token')    
  }

  loggedInUserName() {
    return localStorage.getItem('userEmail')   
  }

  loggedInDev() {
    return !!localStorage.getItem('token')    
  }

  loggedInDevName() {
    return localStorage.getItem('devEmail')   
  }

  loggedInAdmin() {
    return !!localStorage.getItem('token')    
  }

  loggedInAdminName() {
    return localStorage.getItem('adminEmail')   
  }

  public blockById(id) {
    //return this.http.get<any>(this._blockUserUrl+id)
    return null;
  }
  
  public unBlockById(id) {
    //return this.http.get<any>(this._blockUserUrl+id)
    return null;
  }

}
