import { Component, OnInit, Inject, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AlertService } from '../../shared/services/alert.service';
import { DialogService } from '../../shared/services/dialog.service';
import { CategoryService } from '../../shared/services/category.service';

@Component({
  selector: 'app-category-form',
  templateUrl: './category-form.component.html',
  styleUrls: ['./category-form.component.scss'],
})
export class CategoryFormComponent implements OnInit {
  form: FormGroup;
  isFormEdit: boolean;
  selected: number;
  //Regions: Observable<RegionModel[]>;

  categoryEventEmitter = new EventEmitter();

  constructor(
    private readonly _categoryService: CategoryService,
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
    this.categoryEventEmitter.emit(true);
    this.closeDialog();
  }

  edit() {
    this.form = this._formBuilder.group({
      categoryNo: ['', [Validators.required, Validators.minLength(0)]],
      categoryDesc: ['', [Validators.required, Validators.maxLength(50)]],
      categoryCode: ['', [Validators.required, Validators.maxLength(10)]]
    });
    if (this._data.data) {
      this.form.patchValue(this._data.data);
      this.isFormEdit = true;
    }
  }

  update() {
    this._categoryService.updateCategory(this.form.value).subscribe(
      res => {
        this._alertService.sucess();
      },
      error => {
        this._alertService.error(error.body.error);
      },
    );
  }

  create() {
    this._categoryService.createCategory(this.form.value).subscribe(
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
