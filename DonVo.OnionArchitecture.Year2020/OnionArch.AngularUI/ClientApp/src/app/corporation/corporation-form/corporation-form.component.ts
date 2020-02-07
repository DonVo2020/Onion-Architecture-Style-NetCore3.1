import { Component, OnInit, Inject, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { DialogService } from '../../shared/services/dialog.service';
import { AlertService } from '../../shared/services/alert.service';
import { CorporationService } from '../../shared/services/corporation.service';
import { RegionModel } from '../../shared/models/region.model';
import { RegionService } from '../../shared/services/region.service';

@Component({
  selector: 'app-corporation-form',
  templateUrl: './corporation-form.component.html',
  styleUrls: ['./corporation-form.component.scss'],
})
export class CorporationFormComponent implements OnInit {
  form: FormGroup;
  isFormEdit: boolean;
  selected: number;
  Regions: Observable<RegionModel[]>;

  corporationEventEmitter = new EventEmitter();

  constructor(
    private readonly _regionService: RegionService,
    private readonly _formBuilder: FormBuilder,
    private readonly _corpService: CorporationService,
    public readonly _dialogRef: MatDialogRef<CorporationFormComponent>,
    private readonly _dialogService: DialogService,
    private readonly _alertService: AlertService,
    @Inject(MAT_DIALOG_DATA) public _data: any,
    public _router: Router,
  ) { }

  ngOnInit() {
    this.Regions = this._regionService.getRegions();
    this.edit();
  }
  onSubmit() {
    this.isFormEdit ? this.update() : '';
    this.corporationEventEmitter.emit(true);
    this.closeDialog();
  }

  edit() {
    this.form = this._formBuilder.group({
      corpNo: [''],
      corpName: ['', [Validators.required, Validators.minLength(0)]],
      regionNo: [''],
      street: [''],
      city: [''],
      stateProv: [''],
      phoneNo: [''],
      country: [''],
      Region: [''],
      //Member: [''],
    });
    if (this._data.data) {
      this.form.patchValue(this._data.data);
      this.form.controls['Region'].setValue(this._data.data.regionNo);
      this.isFormEdit = true;
    }
  }

  update() {
    this._corpService.edit(this.form.value).subscribe(
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

  // Region dropdown change
  regionSelectionChange(event) {
    this.form.value.regionNo = event.value;
  }
}
