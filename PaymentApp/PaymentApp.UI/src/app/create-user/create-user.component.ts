import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { User } from 'src/app/Models/employee';
import { EmployeeService } from 'src/app/services/employee.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent implements OnInit {

  userForm: FormGroup;
  _user: User;
  userData: any = [];
  roles: any = [];
  userid: any;
  isUserEdit: boolean = false;
  userDetails: any = [];
  constructor(private formBuilder: FormBuilder, private _route: ActivatedRoute, private employeeService: EmployeeService, private toastrService: ToastrService) { }

  ngOnInit(): void {
    this.userid = Number(this._route.snapshot.queryParams['UserID']);
    if (isNaN(this.userid)) {
      this.userid = 0
    } else
      if (this.userid != 0) {
        this.getUserData(this.userid);
      }
    this.initForm();
    this.getRoles();
  }

  initForm() {
    this.userForm = this.formBuilder.group(
      {
        id: [''],
        firstName: new FormControl(null, []),
        lastName: new FormControl(null, []),
        email: new FormControl(null, []),
        password: new FormControl(null, []),
        roleid: new FormControl(null, [])
      }
    )
  }

  getRoles() {
    this.employeeService.getAllRoles().subscribe((data) => {
      if (data != null) {
        this.roles = data;


      }
    });
  }

  getUserData(userid: any) {
    this.isUserEdit = true;
    if (userid != null) {
      this.employeeService.getUserDataById(userid).subscribe(
        (data) => {

          this.userDetails = data;
          this.userForm.get('firstName').setValue(this.userDetails.firstName);
          this.userForm.get('lastName').setValue(this.userDetails.lastName);
          this.userForm.get('email').setValue(this.userDetails.email);
          this.userForm.get('password').setValue(this.userDetails.password);
          this.userForm.get('roleid').setValue(this.userDetails.roleId);

        })
    };
  }


  saveUserData() {
    this.isUserEdit = false;
    this._user = new User();
    this._user.firstName = this.userForm.controls['firstName'].value,
      this._user.lastName = this.userForm.controls['lastName'].value,
      this._user.email = this.userForm.controls['email'].value,
      this._user.password = this.userForm.controls['password'].value,
      this._user.roleid = this.userForm.controls['roleid'].value
    this.employeeService.CreateUser(this._user).subscribe(
      (data) => {
        if (data.result.id != null) {
          this.toastrService.success('User Added Successfully');
          this.userData = data.result;
          this.clearData();
        } else {
          this.toastrService.error("Data not found");

        }
      });

  }

  updateData() {
    this.isUserEdit = true;

  }


  clearData() {
    this.userForm.reset();
  }
}
