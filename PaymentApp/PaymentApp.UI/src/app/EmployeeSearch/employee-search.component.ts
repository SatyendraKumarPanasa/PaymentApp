import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { EmployeeService } from 'src/app/services/employee.service';
import { EmployeeSearch } from 'src/app/Models/employee';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-employee-search',
  templateUrl: './employee-search.component.html',
  styleUrls: ['./employee-search.component.css']
})
export class EmployeeSearchComponent implements OnInit {
  employees: any = [];
  formvalid: boolean;
  employeeSearchForm: FormGroup
  employeeSearch: EmployeeSearch;
  visa: any = [];
  employeeTypesData: any = [];
  locData: any = [];
  page: number = 1;
  count: number = 0;
  tableSize: number = 5;
  tableSizes: any = [3, 6, 9, 12];
  constructor(private employeeService: EmployeeService, private formBuilder: FormBuilder, private toastrService: ToastrService,
    private router: Router) { }

  ngOnInit(): void {
    this.initForm();
    this.getAllVisaStatus();
    this.getAllEmployeeTypes();
    this.getAllLocations();

  }
  initForm() {
    this.employeeSearchForm = this.formBuilder.group(
      {
        AdpFileNumber: new FormControl(null, []),
        firstname: new FormControl(null, []),
        lastname: new FormControl(null, []),
        EmployeeTypeId: new FormControl(null, []),
        VisaStatusId: new FormControl(null, []),
        locationId: new FormControl(null, []),
      }
    )
  }

  getAllLocations() {
    this.employeeService.getAllLocations().subscribe(
      (data) => {
        this.locData = data;      
      }
    )
  }

  getAllVisaStatus() {
    this.employeeService.getvisaStatus().subscribe(
      (data) => {
        this.visa = data;
      }
    )
  }

  getAllEmployeeTypes() {
    this.employeeService.getAllEmployeeTypes().subscribe(
      (data) => {
        this.employeeTypesData = data;
      }
    )
  }


  onTableDataChange(event: any) {
    this.page = event;
    this.Search();
  }
  onTableSizeChange(event: any): void {
    this.tableSize = event.target.value;
    this.page = 1;
    this.Search();
  }

  Search() {
    this.employeeSearch = new EmployeeSearch();
    this.employeeSearch.firstName = this.employeeSearchForm.controls['firstname'].value
    this.employeeSearch.lastName = this.employeeSearchForm.controls['lastname'].value
    this.employeeSearch.AdpFileNumber = this.employeeSearchForm.controls['AdpFileNumber'].value
    this.employeeSearch.employeetypeId = Number(this.employeeSearchForm.controls['EmployeeTypeId'].value)
    this.employeeSearch.VisaStatusId = Number(this.employeeSearchForm.controls['VisaStatusId'].value)
    this.employeeSearch.locationId = Number(this.employeeSearchForm.controls['locationId'].value)
    this.employeeService.searchRegisteredEmployee(this.employeeSearch).subscribe(
      (data) => {
        if (data.length > 0) {
          this.employees = data;
        } else {
          this.toastrService.error('Data Not Found');
        }
      });
  }

  NavigateToCreateEmployee(id: any) {
    this.router.navigate(['/CreateEmployee'], { queryParams: { EmployeeID: id } });
  }

  clearData() {
    this.employeeSearchForm.reset();
  }

}
