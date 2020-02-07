import { Component, OnInit, ViewChild, AfterViewInit, ChangeDetectorRef } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource, MatTable } from '@angular/material';
import { Router } from '@angular/router';
import { CorporationFormComponent } from '../corporation-form/corporation-form.component';
import { AlertService } from '../../shared/services/alert.service';
import { DialogService } from '../../shared/services/dialog.service';
import { CorporationService } from '../../shared/services/corporation.service';
import { CorporationModel } from '../../shared/models/corporation.model';

@Component({
  selector: 'app-corporation-list',
  templateUrl: './corporation-list.component.html',
  styleUrls: ['./corporation-list.component.scss']
})
export class CorporationListComponent implements OnInit, AfterViewInit {

  @ViewChild(MatPaginator, null) paginator: MatPaginator;
  @ViewChild(MatSort, null) sort: MatSort;
  dataSource = new MatTableDataSource<CorporationModel>();

  /** Columns displayed in the table. Columns numbers can be added, removed, or reordered. */
  displayedColumns = ['corpName', 'regionNo', 'street', 'city', 'stateProv', 'country', 'phoneNo', 'update'];

  submit: boolean;

  constructor(private router: Router, private readonly corpService: CorporationService, private readonly dialogService: DialogService, private readonly alertService: AlertService) {
  }

  ngOnInit() {
    this.getCorporations();
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  public doFilter = (value: string) => {
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }

  selectRow(corp) {
    this.router.navigate(['corporation-list'], { state: { "corporation-list": corp } });
  }

  getCorporations() {
    this.corpService.getCorporations().subscribe(res => {
      this.dataSource.data = res as CorporationModel[];
    });
  }

  openDialog(corp: any = null): void {
    this.dialogService.openDialog(CorporationFormComponent, corp);
    this.refreshTable();
  }

  refreshTable() {
    this.dialogService.dialogRef.componentInstance.corporationEventEmitter.subscribe((isEmitted) => {
      if (isEmitted) {
        this.submit = isEmitted;
      }
    });
    this.dialogService.dialogRef.afterClosed().subscribe(() => {
      if (this.submit)
        this.getCorporations();
    });
  }

}
