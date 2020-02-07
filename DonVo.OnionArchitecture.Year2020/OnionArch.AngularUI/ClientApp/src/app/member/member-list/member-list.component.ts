import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource, MatTable } from '@angular/material';
import { Router } from '@angular/router';
import { MemberFormComponent } from '../member-form/member-form.component';
import { AlertService } from '../../shared/services/alert.service';
import { DialogService } from '../../shared/services/dialog.service';
import { MemberService } from '../../shared/services/member.service';
import { MemberModel } from '../../shared/models/member.model';
import { ConfirmDeleteComponent } from '../../shared/confirm-delete/confirm-delete.component';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit, AfterViewInit {

  @ViewChild(MatPaginator, null) paginator: MatPaginator;
  @ViewChild(MatSort, null) sort: MatSort;
  dataSource = new MatTableDataSource<MemberModel>();

  /** Columns displayed in the table. Columns numbers can be added, removed, or reordered. */
  displayedColumns = ['lastName', 'firstName', 'regionNo', 'street', 'city', 'stateProv','phoneNo', 'update', 'delete'];

  member: MemberModel;
  submit: boolean;

  constructor(private router: Router, private readonly memberService: MemberService, private readonly dialogService: DialogService, private readonly alertService: AlertService,) {
  }

  ngOnInit() {
    this.getMembers();
    this.dialogService.getDelete().subscribe(ok => (ok && this.member ? this.deleteMember(this.member)  : ''));
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  public doFilter = (value: string) => {
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }

  selectRow(member) {
    this.router.navigate(['member-list'], { state: { "member-list": member } });
  }

  getMembers() {
    this.memberService.getMembers().subscribe(res => {
      this.dataSource.data = res as MemberModel[];
    });
  }

  openDialogDelete(member: MemberModel) {
    this.member = member;
    this.dialogService.openDialog(ConfirmDeleteComponent, { member, tipo: 'Member' });
  }
  deleteMember(member) {
    this.memberService.deleteMember(member.memberNo).subscribe(
      resp => {
        this.getMembers();
        this.alertService.sucess();
      },
      _ => {
        this.alertService.error();
      },
    );
  }

  openDialog(member: any = null): void {
    this.dialogService.openDialog(MemberFormComponent, member);
    this.refreshTable();
  }

  refreshTable() {
    this.dialogService.dialogRef.componentInstance.memberEventEmitter.subscribe((isEmitted) => {
      if (isEmitted) {
        this.submit = isEmitted;
      }
    });
    this.dialogService.dialogRef.afterClosed().subscribe(() => {
      if (this.submit)
        this.getMembers();
    });
  }
}
