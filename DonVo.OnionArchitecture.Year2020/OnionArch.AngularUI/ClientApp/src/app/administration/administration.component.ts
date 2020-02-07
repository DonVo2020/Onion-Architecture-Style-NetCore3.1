import { Component, OnInit, ViewEncapsulation, ViewChild, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
import { RegionModel } from '../shared/models/region.model';
import { RegionService } from '../shared/services/region.service';
import { MatPaginator, MatSort, MatTableDataSource, MatTable } from '@angular/material';
import { Title } from '@angular/platform-browser';
import { AlertService } from '../shared/services/alert.service';
import { DialogService } from '../shared/services/dialog.service';
import { ConfirmDeleteComponent } from '../shared/confirm-delete/confirm-delete.component';
import { ProviderModel } from '../shared/models/provider.model';
import { ProviderService } from '../shared/services/provider.service';
import { CategoryModel } from '../shared/models/category.model';
import { CategoryService } from '../shared/services/category.service';
import { RegionFormComponent } from './region-form/region-form.component';
import { CategoryFormComponent } from './category-form/category-form.component';
import { ProviderFormComponent } from './provider-form/provider-form.component';

@Component({
  selector: 'app-administration',
  templateUrl: './administration.component.html',
  styleUrls: ['./administration.component.css']
})
export class AdministrationComponent implements OnInit, AfterViewInit {

  @ViewChild('paginator', null) paginator: MatPaginator;
  @ViewChild('sort', { static: true }) sort: MatSort;
  @ViewChild('paginatorProvider', null) paginatorProvider: MatPaginator;
  @ViewChild('sortProvider', { static: true }) sortProvider: MatSort;
  @ViewChild('paginatorCategory', null) paginatorCategory: MatPaginator;
  @ViewChild('sortCategory', { static: true }) sortCategory: MatSort;
  dataSource = new MatTableDataSource<RegionModel>();
  dataSourceProvider = new MatTableDataSource<ProviderModel>();
  dataSourceCategory = new MatTableDataSource<CategoryModel>();

  /** Columns displayed in the table. Columns numbers can be added, removed, or reordered. */
  displayedColumns = ['regionName', 'country', 'update'];
  displayedProviderColumns = ['providerName', 'regionNo', 'update', 'delete'];
  displayedCategoryColumns = ['categoryNo', 'categoryDesc', 'categoryCode', 'update', 'delete'];

  category: CategoryModel;
  provider: ProviderModel;
  submit: boolean;

  constructor(private router: Router, private readonly regionService: RegionService,
    private readonly providerService: ProviderService, private readonly categoryService: CategoryService,
    private readonly dialogService: DialogService, private readonly alertService: AlertService) {
  }

  ngOnInit() {
    this.getRegions();
    this.getProviders();
    this.getCategories();
    this.dialogService.getDelete().subscribe(ok => (ok && this.category ? this.deleteCategory(this.category) : (this.provider ? this.deleteProvider(this.provider) : '')));
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
    this.dataSourceProvider.sort = this.sortProvider;
    this.dataSourceProvider.paginator = this.paginatorProvider;
    this.dataSourceCategory.sort = this.sortCategory;
    this.dataSourceCategory.paginator = this.paginatorCategory;
  }

  public doFilter = (value: string) => {
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }

  public doFilterCategory = (value: string) => {
    this.dataSourceCategory.filter = value.trim().toLocaleLowerCase();
  }

  public doFilterProvider = (value: string) => {
    this.dataSourceProvider.filter = value.trim().toLocaleLowerCase();
  }

  selectRow(region) {
    //this.router.navigate(['region-list'], { state: { "region-list": region } });
  }

  getRegions() {
    this.regionService.getRegions().subscribe(res => {
      this.dataSource.data = res as RegionModel[];
    });
  }

  getCategories() {
    this.categoryService.getCategories().subscribe(res => {
      this.dataSourceCategory.data = res as CategoryModel[];
    });
  }

  getProviders() {
    this.providerService.getProviders().subscribe(res => {
      this.dataSourceProvider.data = res as ProviderModel[];
    });
  }

  openDialog(region: any = null): void {
    this.dialogService.openDialog(RegionFormComponent, region);
    this.refreshTableByTableName('region');
  }

  openDialogCategory(category: any = null): void {
    this.dialogService.openDialog(CategoryFormComponent, category);
    this.refreshTableByTableName('category');
  }

  openDialogProvider(provider: any = null): void {
    this.dialogService.openDialog(ProviderFormComponent, provider);
    this.refreshTableByTableName('provider');
  }

  openDialogCategoryDelete(category: CategoryModel) {
    this.category = category;
    this.dialogService.openDialog(ConfirmDeleteComponent, { category, tipo: 'Category' });
  }

  deleteCategory(category) {
    this.categoryService.deleteCategory(category.categoryNo).subscribe(
      resp => {
        this.getCategories();
        this.alertService.sucess();
      },
      _ => {
        this.alertService.error();
      },
    );
  }

  openDialogProviderDelete(provider: ProviderModel) {
    this.provider = provider;
    this.dialogService.openDialog(ConfirmDeleteComponent, { provider, tipo: 'Provider' });
  }
  deleteProvider(provider) {
    this.providerService.deleteProvider(provider.providerNo).subscribe(
      resp => {
        this.getProviders();
        this.alertService.sucess();
      },
      _ => {
        this.alertService.error();
      },
    );
  }

  refreshTableByTableName(tableName: string) {
    if (tableName === 'category') {
      this.dialogService.dialogRef.componentInstance.categoryEventEmitter.subscribe((isEmitted) => {
        if (isEmitted) {
          this.submit = isEmitted;
        }
      });
      this.dialogService.dialogRef.afterClosed().subscribe(() => {
        if (this.submit)
          this.getCategories();
      });
    }
    else if (tableName === 'region') {
      this.dialogService.dialogRef.componentInstance.regionEventEmitter.subscribe((isEmitted) => {
        if (isEmitted) {
          this.submit = isEmitted;
        }
      });
      this.dialogService.dialogRef.afterClosed().subscribe(() => {
        if (this.submit)
          this.getRegions();
      });
    }
    else if (tableName === 'provider') {
      this.dialogService.dialogRef.componentInstance.providerEventEmitter.subscribe((isEmitted) => {
        if (isEmitted) {
          this.submit = isEmitted;
        }
      });
      this.dialogService.dialogRef.afterClosed().subscribe(() => {
        if (this.submit)
          this.getProviders();
      });
    }
  }

}
