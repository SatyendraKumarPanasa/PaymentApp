import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { EmployeeRegisterComponent } from '../app/employee-register/employee-register.component';
import { ProjectComponent } from '../app/project/project.component';
import { CreateUserComponent } from '../app/create-user/create-user.component';
import { EmployeeSearchComponent } from './EmployeeSearch/employee-search.component';
import { ProjectSearchComponent } from './ProjectSearch/project-search.component';
import { LoginGuard } from './services/login.guard';
import { UserSearchComponent } from './UserSearch/user-search.component';


const routes: Routes = [
  { path: '', component: LoginComponent, canActivate: [LoginGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'app', component: AppComponent, canActivate: [LoginGuard] },
  { path: 'CreateEmployee', component: EmployeeRegisterComponent, canActivate: [LoginGuard] },
  { path: 'CreateProject', component: ProjectComponent, canActivate: [LoginGuard] },
  { path: 'CreateUser', component: CreateUserComponent, canActivate: [LoginGuard] },
  { path: 'EmployeeSearch', component: EmployeeSearchComponent, canActivate: [LoginGuard] },
  { path: 'ProjectSearch', component: ProjectSearchComponent, canActivate: [LoginGuard] },
  { path: 'UsersSearch', component: UserSearchComponent, canActivate: [LoginGuard] },






];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const myRoutings = [
  LoginComponent,
  AppComponent,
];
