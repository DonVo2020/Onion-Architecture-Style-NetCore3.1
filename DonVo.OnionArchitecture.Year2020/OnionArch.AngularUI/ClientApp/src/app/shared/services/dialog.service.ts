import { Injectable, EventEmitter } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Subject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DialogService {
  dialogRef: any;
  delete = new Subject<boolean>();
  constructor(public dialog: MatDialog) {}

  openDialog(component: any, dataf: any) {
    this.dialogRef = this.dialog.open(component, { data: { data: dataf } });
  }

  closeDialog() {
    this.dialogRef.close();
  }

  canDelete(v: boolean) {
    this.delete.next(v);
  }

  getDelete(): Observable<boolean> {
    return this.delete.asObservable();
  }
}
