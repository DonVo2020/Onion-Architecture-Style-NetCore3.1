import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AuthService } from '../administration/auth.service';

@Component({
  selector: 'app-side-map',
  templateUrl: './side-map.component.html',
  styleUrls: ['./side-map.component.css']
})
export class SideMapComponent implements OnInit {

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches)
    );

  constructor(private breakpointObserver: BreakpointObserver, private _authService: AuthService) { }

  ngOnInit(){
  }

}
