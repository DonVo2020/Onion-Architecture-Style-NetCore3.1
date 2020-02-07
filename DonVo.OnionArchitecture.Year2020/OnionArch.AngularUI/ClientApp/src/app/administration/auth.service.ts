import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Router } from '@angular/router'

@Injectable()
export class AuthService {
  private _baseUrl ="https://localhost:44353/api/v1/account";
  private _baseAdminUrl="https://localhost:44370/adminservice";
  private _registerUrl = this._baseUrl+"/register";
  private _loginUrl = this._baseUrl+"/login";
  private _registerMentorUrl = this._baseUrl+"/register";
  private _loginMentorUrl = this._baseUrl+"/login";
  private _loginAdminUrl = this._baseUrl+"/login";
  public _blockUserUrl =this._baseAdminUrl+"/blockunblock/";
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

  registerMentor(user) {
    return this.http.post<any>(this._registerMentorUrl, user)
  }

  loginMentor(user) {
    return this.http.post<any>(this._loginMentorUrl, user)
  }

  logoutMentor() {
    localStorage.removeItem('token')
    localStorage.removeItem('mentorEmail')
    this._router.navigate(['/mentor-login'])
  }


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

  loggedInMentor() {
    return !!localStorage.getItem('token')    
  }

  loggedInMentorName() {
    return localStorage.getItem('mentorEmail')   
  }

  loggedInAdmin() {
    return !!localStorage.getItem('token')    
  }

  loggedInAdminName() {
    return localStorage.getItem('adminEmail')   
  }

  public blockById(id) {
    return this.http.get<any>(this._blockUserUrl+id)
      
  }
  
  public unBlockById(id) {
    return this.http.get<any>(this._blockUserUrl+id)
  }

}
