import { Component, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-footer-form',
  templateUrl: './footer-form.component.html',
  styleUrls: ['./footer-form.component.scss'],
})
export class FooterFormComponent {
  @Input() nameForm: FormGroup;
  @Output() closeForm: EventEmitter<any> = new EventEmitter();
  @Output() clearForm: EventEmitter<any> = new EventEmitter();
  @Input() isFormEdit: boolean;

  closeFormFn() {
    this.closeForm.emit(this);
  }

  submitFormFn() {
    this.closeForm.emit(this);
  }

  clearFormFn() {
    this.clearForm.emit(this);
  }
}
