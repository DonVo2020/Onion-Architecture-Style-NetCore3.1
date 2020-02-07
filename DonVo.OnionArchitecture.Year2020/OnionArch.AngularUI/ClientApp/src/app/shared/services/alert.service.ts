import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

const messeges = {
  succes: {
    default: 'Successful action.',
    create: 'Successfully created',
    update: 'Successfully updated',
    delete: 'Successfully deleted',
  },
  error: {
    default: 'Sorry an error happened.',
    create: 'Failed to Create',
    update: 'Failed to Update',
    delete: 'Failed to Delete',
  },
  info: {
    default: 'info ....',
  },
  color: {
    succes: 'alert-succes',
    error: 'alert-error',
    info: 'alert-info',
  },
};

const config = {
  panelClass: [],
  duration: 2000,
};

@Injectable({
  providedIn: 'root',
})
export class AlertService {
  message: string;
  constructor(private _snackBar: MatSnackBar) {}

  open() {
    this._snackBar.open(this.message, 'Close', config);
  }
  sucess(message: string = null) {
    this.message = message || messeges.succes.default;
    config.panelClass.push(messeges.color.succes);
    this.open();
  }
  error(message: string = null) {
    this.message = message || messeges.error.default;
    config.panelClass.push(messeges.color.error);
    this.open();
  }
  info(message: string = null) {
    this.message = message || messeges.info.default;
    config.panelClass.push(messeges.color.info);
    this.open();
  }
}
