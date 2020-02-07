import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { httpOptions } from '../../config/httpOptions';
import { environment } from './../../../environments/environment';
import { CategoryModel } from '../models/category.model';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  apiUrl = `${environment.apiUrl}/categories`;

  constructor(private readonly _http: HttpClient) {}

  getCategories(): Observable<any> {
    return this._http.get<CategoryModel[]>(this.apiUrl);
  }

  createCategory(category: any): Observable<any> {
    return this._http.post(this.apiUrl, category, httpOptions);
  }

  updateCategory(category: any): Observable<CategoryModel> {
    return this._http.put<CategoryModel>(`${this.apiUrl}/${category.categoryNo}`, category, httpOptions);
  }

  deleteCategory(categoryNo: number): Observable<{}> {
    return this._http.delete(`${this.apiUrl}/${categoryNo}`, httpOptions);
  }
}
