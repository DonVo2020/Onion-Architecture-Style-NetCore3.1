import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { httpOptions } from '../../config/httpOptions';
import { environment } from './../../../environments/environment';
import { RegionModel } from '../../shared/models/region.model';

@Injectable({
  providedIn: 'root',
})
export class RegionService {
  apiUrl = `${environment.apiUrl}/regions`;

  constructor(private readonly _http: HttpClient) {}

  getRegions(): Observable<any> {
    return this._http.get<RegionModel[]>(this.apiUrl);
  }

  createRegion(region: any): Observable<any> {
    return this._http.post(this.apiUrl, region, httpOptions);
  }

  updateRegion(region: any): Observable<RegionModel> {
    return this._http.put<RegionModel>(`${this.apiUrl}/${region.regionNo}`, region, httpOptions);
  }

  deleteRegion(regionNo: number): Observable<{}> {
    return this._http.delete(`${this.apiUrl}/${regionNo}`, httpOptions);
  }
}
