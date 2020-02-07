import { Injectable, EventEmitter } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { httpOptions } from '../../config/httpOptions';
import { MemberModel } from '../models/member.model';

@Injectable({ providedIn: 'root' })
export class MemberService {
  apiUrl = `${environment.apiUrl}/basicmembers`;

  constructor(private _http: HttpClient) {}

  getMembers(): Observable<any> {
    return this._http.get(this.apiUrl);
  }

  createMember(member: MemberModel): Observable<MemberModel> {
    return this._http.post<MemberModel>(this.apiUrl, member, httpOptions);
  }

  editMember(member: MemberModel): Observable<MemberModel> {
    return this._http.put<MemberModel>(`${this.apiUrl}/${member.memberNo}`, member, httpOptions);
  }

  deleteMember(id: number): Observable<{}> {
    return this._http.delete(`${this.apiUrl}/${id}`, httpOptions);
  }
}
