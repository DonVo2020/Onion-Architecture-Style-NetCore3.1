import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { httpOptions } from '../../config/httpOptions';
import { environment } from './../../../environments/environment';
import { ProviderModel } from '../../shared/models/provider.model';

@Injectable({
  providedIn: 'root',
})
export class ProviderService {
  apiUrl = `${environment.apiUrl}/providers`;

  constructor(private readonly _http: HttpClient) {}

  getProviders(): Observable<any> {
    return this._http.get<ProviderModel[]>(this.apiUrl);
  }

  createProvider(provider: any): Observable<any> {
    return this._http.post(this.apiUrl, provider, httpOptions);
  }

  updateProvider(provider: any): Observable<ProviderModel> {
    return this._http.put<ProviderModel>(`${this.apiUrl}/${provider.providerNo}`, provider, httpOptions);
  }

  deleteProvider(providerNo: number): Observable<{}> {
    return this._http.delete(`${this.apiUrl}/${providerNo}`, httpOptions);
  }
}
