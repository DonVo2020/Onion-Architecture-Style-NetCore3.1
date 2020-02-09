import { Component, OnInit, Inject, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AlertService } from '../../shared/services/alert.service';
import { DialogService } from '../../shared/services/dialog.service';
import { RegionService } from '../../shared/services/region.service';

@Component({
  selector: 'app-region-form',
  templateUrl: './region-form.component.html',
  styleUrls: ['./region-form.component.scss'],
})
export class RegionFormComponent implements OnInit {
  form: FormGroup;
  isFormEdit: boolean;
  selected: number;

  regionEventEmitter = new EventEmitter();

  constructor(
    private readonly _regionService: RegionService,
    private readonly _formBuilder: FormBuilder,
    private readonly _dialogService: DialogService,
    private readonly _alertService: AlertService,
    @Inject(MAT_DIALOG_DATA) public _data: any,
    public _router: Router,
  ) { }

  ngOnInit() {
    this.edit();
  }
  onSubmit() {
    this.isFormEdit ? this.update() : this.create();
    this.regionEventEmitter.emit(true);
    this.closeDialog();
  }

  edit() {
    this.form = this._formBuilder.group({
      regionNo: ['', [Validators.required, Validators.minLength(0)]],
      regionName: ['', [Validators.required, Validators.maxLength(20)]],
      street: [''],
      city: [''],
      stateProv: [''],
      phoneNo: [''],
      country: ['']
    });
    if (this._data.data) {
      this.form.patchValue(this._data.data);
      this.isFormEdit = true;
    }
  }

  update() {
    this._regionService.updateRegion(this.form.value).subscribe(
      res => {
        this._alertService.sucess();
      },
      error => {
        this._alertService.error(error.body.error);
      },
    );
  }

  create() {
    this._regionService.createRegion(this.form.value).subscribe(
      res => {
        this._alertService.sucess();
      },
      error => {
        this._alertService.error(error.body.error);
      },
    );
  }

  isEdit() {
    return this.isFormEdit ? 'Update' : 'Create';
  }

  formClear() {
    this.form.reset();
  }

  closeDialog() {
    this._dialogService.closeDialog();
  }
}
