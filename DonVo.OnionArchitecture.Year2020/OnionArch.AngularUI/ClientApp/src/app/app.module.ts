import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
//import { RouterModule } from '@angular/router';
import { MaterialsModule } from './shared/materials.module';
import { MatExpansionModule } from '@angular/material/expansion';
import { SharedModule } from './shared/shared.module';
import { ToastrModule } from 'ngx-toastr';
import { LayoutModule } from '@angular/cdk/layout';
import { CommonModule } from '@angular/common';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { MemberListComponent } from './member/member-list/member-list.component';
import { MemberFormComponent } from './member/member-form/member-form.component';
import { SideMapComponent } from './side-map/side-map.component';
import { HomeComponent } from './home/home.component';
import { AdminLoginComponent } from './administration/admin-login/admin-login.component';
import { AdministrationComponent } from './administration/administration.component';
import { CorporationListComponent } from './corporation/corporation-list/corporation-list.component';
import { CorporationFormComponent } from './corporation/corporation-form/corporation-form.component';
import { RegionFormComponent } from './administration/region-form/region-form.component';
import { CategoryFormComponent } from './administration/category-form/category-form.component';
import { ProviderFormComponent } from './administration/provider-form/provider-form.component';
import { AuthService } from './administration/auth.service';
import { TokenInterceptorService } from './administration/token-interceptor.service';
import { AuthAdminGuard } from './administration/auth-admin.guard';

import { CarouselDirective } from './shared/directives/carousel.directive';

@NgModule({
  declarations: [
    AppComponent,
    SideMapComponent,
    HomeComponent,
    AdminLoginComponent,
    MemberListComponent,
    MemberFormComponent,
    CorporationListComponent,
    CorporationFormComponent,
    AdministrationComponent,
    RegionFormComponent,
    CategoryFormComponent,
    ProviderFormComponent,
    CarouselDirective,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    SharedModule,
    MatExpansionModule,
    ToastrModule.forRoot(
      {
        progressBar: true
      }
    ),
    FormsModule,
    LayoutModule,
    CommonModule,
    MaterialsModule,
    MatExpansionModule,
  ],
  providers: [AuthService, AuthAdminGuard,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true
    }],
  bootstrap: [AppComponent]
})
export class AppModule { }
