import { Component, OnInit, Inject, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { AlertService } from '../../shared/services/alert.service';
import { DialogService } from '../../shared/services/dialog.service';
import { MemberService } from '../../shared/services/member.service';
import { RegionModel } from '../../shared/models/region.model';
import { RegionService } from '../../shared/services/region.service';

@Component({
  selector: 'app-member-form',
  templateUrl: './member-form.component.html',
  styleUrls: ['./member-form.component.scss'],
})
export class MemberFormComponent implements OnInit {
  form: FormGroup;
  isFormEdit: boolean;
  selected: number;
  Regions: Observable<RegionModel[]>;

  memberEventEmitter = new EventEmitter();

  constructor(
    private readonly _regionService: RegionService,
    private readonly _formBuilder: FormBuilder,
    private readonly _memberService: MemberService,
    //public readonly _dialogRef: MatDialogRef<MemberFormComponent>,
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
    this.isFormEdit ? this.update() : this.create();
    this.memberEventEmitter.emit(true);
    this.closeDialog();
  }

  edit() {
    this.form = this._formBuilder.group({
      lastName: ['', [Validators.required, Validators.minLength(0)]],
      firstName: ['', [Validators.required, Validators.maxLength(20)]],
      Region: [''],
      regionNo: [''],
      street: [''],
      city: [''],
      stateProv: [''],
      phoneNo: [''],
      memberNo: [''],
    });
    if (this._data.data) {
      this.form.patchValue(this._data.data);
      this.form.controls['Region'].setValue(this._data.data.regionNo);
      this.isFormEdit = true;
    }
  }

  update() {
    this._memberService.editMember(this.form.value).subscribe(
      res => {
        this._alertService.sucess();
      },
      error => {
        this._alertService.error(error.body.error);
      },
    );
  }

  create() {
    this._memberService.createMember(this.form.value).subscribe(
      res => {
        this._alertService.sucess();
      },
      error => {
        this._alertService.error(error.body.error);
      },
    );
  }

  // Region dropdown change
  regionSelectionChange(event) {
    this.form.value.regionNo = event.value;  
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
