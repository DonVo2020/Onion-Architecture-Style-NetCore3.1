import { Injectable, EventEmitter } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { httpOptions } from '../../config/httpOptions';
import { CorporationModel } from '../models/corporation.model';

@Injectable({ providedIn: 'root' })
export class CorporationService {
  apiUrl = `${environment.apiUrl}/corporations`;

  constructor(private _http: HttpClient) {}

  getCorporations(): Observable<any> {
    return this._http.get(this.apiUrl);
  }

  edit(corp: CorporationModel): Observable<CorporationModel> {
    return this._http.put<CorporationModel>(`${this.apiUrl}/${corp.corpNo}`, corp, httpOptions);
  }
}
