import { Component, OnInit, Inject, EventEmitter } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, } from '@angular/material/dialog';
//import { MatCardModule } from '@angular/material';
import { DialogService } from '../services/dialog.service';

@Component({
  selector: 'app-confirm-delete',
  templateUrl: './confirm-delete.component.html',
  styleUrls: ['./confirm-delete.component.scss'],
})
export class ConfirmDeleteComponent implements OnInit {
  item: object;
  title: string = '';
  constructor(
    public _dialogRef: MatDialogRef<ConfirmDeleteComponent>,
    private _diaLogService: DialogService,
    @Inject(MAT_DIALOG_DATA) public _data: any,
  ) {}

  ngOnInit() {
    
  }

  close() {
    this._dialogRef.close();
  }

  confirm() {
    this._diaLogService.canDelete(true);
    this.close();
  }
}
