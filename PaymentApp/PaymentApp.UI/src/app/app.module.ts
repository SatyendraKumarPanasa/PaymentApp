import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from '../app/Shared/header/header.component';
import { SideNavComponent } from '../app/Shared/side-nav/side-nav.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { myRoutings } from './app-routing.module';
import { LoginComponent } from './login/login.component';
import { EmployeeRegisterComponent } from '../app/employee-register/employee-register.component';
import { ProjectComponent } from '../app/project/project.component';
import { EmployeeService } from './services/employee.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { JwtHelperService, JWT_OPTIONS } from '@auth0/angular-jwt';
import { CreateUserComponent } from '../app/create-user/create-user.component';
import { EmployeeSearchComponent } from './EmployeeSearch/employee-search.component';
import { ProjectSearchComponent } from './ProjectSearch/project-search.component';
import { LoginGuard } from './services/login.guard';
import { LoginService } from './services/login.service';
import { NgxPaginationModule } from 'ngx-pagination';
import { UserSearchComponent } from './UserSearch/user-search.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    SideNavComponent,
    myRoutings,
    LoginComponent,
    EmployeeRegisterComponent,
    ProjectComponent,
    CreateUserComponent,
    EmployeeSearchComponent,
    ProjectSearchComponent,
    UserSearchComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    BrowserAnimationsModule, HttpClientModule, NgxPaginationModule, ToastrModule.forRoot()
  ],
  providers: [LoginGuard, LoginService,
    { provide: JWT_OPTIONS, useValue: JWT_OPTIONS },
    EmployeeService, JwtHelperService],
  bootstrap: [AppComponent]
})
export class AppModule { }
