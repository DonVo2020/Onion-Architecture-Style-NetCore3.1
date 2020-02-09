import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
@Component({
  selector: 'app-admin-login',
  templateUrl: './admin-login.component.html',
  styleUrls: ['./admin-login.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class AdminLoginComponent implements OnInit {

  errorServerMessage: String = null;
  loginAdminData = { "Role": 1 }
  registerUserData = { "Role": 5 }

  test: any;


  constructor(private _auth: AuthService,
    private _router: Router) { }

  ngOnInit() {
  }

  loginAdmin() {
    this._auth.loginAdmin(this.loginAdminData)
    .subscribe(
      res => {
        localStorage.setItem('token', res.key)
        localStorage.setItem('adminEmail',res.email)
        this._router.navigate(['/home'])
      },
      err =>{
        console.log(err);
        this.errorServerMessage = err.error.message;  
      }
    )
  }

  registerUser() {
    this._auth.registerUser(this.registerUserData)
      .subscribe(
        res => {
          localStorage.setItem('token', res.key)
          localStorage.setItem('userEmail', res.email)
          this._router.navigate(['/login'])
        },
        err => {
          console.log(err);
          this.errorServerMessage = err.error.message;
        }
      )
  }

}
