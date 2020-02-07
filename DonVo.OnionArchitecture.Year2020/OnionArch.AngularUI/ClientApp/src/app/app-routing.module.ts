import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MemberListComponent } from './member/member-list/member-list.component';
import { MemberFormComponent } from './member/member-form/member-form.component';
import { AdministrationComponent } from './administration/administration.component';
import { AdminLoginComponent } from './administration/admin-login/admin-login.component';
import { CorporationListComponent } from './corporation/corporation-list/corporation-list.component';
import { CorporationFormComponent } from './corporation/corporation-form/corporation-form.component';
import { RegionFormComponent } from './administration/region-form/region-form.component';
import { CategoryFormComponent } from './administration/category-form/category-form.component';
import { ProviderFormComponent } from './administration/provider-form/provider-form.component';
import { AuthAdminGuard } from './administration/auth-admin.guard';


const routes: Routes = [
  //{ path: '', component: HomeComponent },
  { path: '', canActivate: [AuthAdminGuard],component: AdminLoginComponent },
  { path: 'member-list', canActivate: [AuthAdminGuard],component: MemberListComponent },
  { path: 'member/new', canActivate: [AuthAdminGuard],component: MemberFormComponent },
  { path: 'corporation-list', canActivate: [AuthAdminGuard], component: CorporationListComponent },
  { path: 'corporation/new', canActivate: [AuthAdminGuard],component: CorporationFormComponent },
  { path: 'administration', canActivate: [AuthAdminGuard], component: AdministrationComponent },
  { path: 'region/new', canActivate: [AuthAdminGuard],component: RegionFormComponent },
  { path: 'category/new', canActivate: [AuthAdminGuard],component: CategoryFormComponent },
  { path: 'provider/new', canActivate: [AuthAdminGuard],component: ProviderFormComponent },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
