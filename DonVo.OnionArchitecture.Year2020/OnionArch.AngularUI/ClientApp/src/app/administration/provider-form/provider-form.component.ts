import { Component, OnInit, Inject, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AlertService } from '../../shared/services/alert.service';
import { DialogService } from '../../shared/services/dialog.service';
import { ProviderService } from '../../shared/services/provider.service';

@Component({
  selector: 'app-provider-form',
  templateUrl: './provider-form.component.html',
  styleUrls: ['./provider-form.component.scss'],
})
export class ProviderFormComponent implements OnInit {
  form: FormGroup;
  isFormEdit: boolean;
  selected: number;
  //Regions: Observable<RegionModel[]>;

  providerEventEmitter = new EventEmitter();

  constructor(
    private readonly _providerService: ProviderService,
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
    this.providerEventEmitter.emit(true);
    this.closeDialog();
  }

  edit() {
    this.form = this._formBuilder.group({
      providerNo: ['', [Validators.required, Validators.minLength(0)]],
      providerName: ['', [Validators.required, Validators.maxLength(10)]],
      regionNo: [''],
      street: [''],
      city: [''],
      stateProv: [''],
      phoneNo: [''],
      country: [''],
      providerCode: ['']
    });
    if (this._data.data) {
      this.form.patchValue(this._data.data);
      this.isFormEdit = true;
    }
  }

  update() {
    this._providerService.updateProvider(this.form.value).subscribe(
      res => {
        this._alertService.sucess();
      },
      error => {
        this._alertService.error(error.body.error);
      },
    );
  }

  create() {
    this._providerService.createProvider(this.form.value).subscribe(
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
