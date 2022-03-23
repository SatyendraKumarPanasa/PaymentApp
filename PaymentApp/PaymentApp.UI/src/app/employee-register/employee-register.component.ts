import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from 'src/app/services/employee.service';
import { ToastrService } from 'ngx-toastr';
import { ProjectService } from '../services/project.service';
import { EmployeeNotes, EmployeeProjectDetails, EmployeeProjectPayDetails } from '../Models/employee';

@Component({
  selector: 'app-employee-register',
  templateUrl: './employee-register.component.html',
  styleUrls: ['./employee-register.component.css']
})
export class EmployeeRegisterComponent implements OnInit {
  employeeForm: FormGroup;
  editProjectForm: FormGroup;
  employeeprojectDetailsForm: FormGroup;
  employeeprojectPaymentDetailsForm: FormGroup;
  employeeNotesForm: FormGroup;
  _employeeProjectDetails: EmployeeProjectDetails;
  _employeeProjectPayDetails: EmployeeProjectPayDetails;
  employeeNotes: EmployeeNotes;
  isEdit: boolean = false;
  employees: any = [];
  minDate: Date;
  formvalid = false;
  visa: any = [];
  locData: any = [];
  employeeTypesData: any = [];
  empData: any = [];
  getSalaryType: any = [];
  projData: any = [];
  empProjData: any = [];
  projectStatusData: any = [];
  prjData: any = [];
  projectDetails: any = [];
  empNotes: any = [];
  AllempNotes: any = []
  empNotesData:any = [];
  page: number = 1;
  count: number = 0;
  tableSize: number = 10;
  tableSizes: any = [3, 6, 9, 12];
  isEmployeeEdit: boolean = false;
  isEmployeeProjectsedit: boolean = false;
  isEmployeeNotesedit:boolean = false;
  _showAddprojectModal = 'none';
  _showAddprojectPayModal = 'none'
  _showAddEmployeeNotesModal = 'none'
  @ViewChild('closebutton') closebutton;
  getEmpPrjId: any;
  getNotesForEmpId:any;
  employeeid: any;
  empDetails: any = []
  constructor(
    private router: Router,
    private employeeService: EmployeeService,
    private route: ActivatedRoute,
    private formBuilder: FormBuilder, private toastrService: ToastrService, private _route: ActivatedRoute, private projectService: ProjectService,
  ) { }

  ngOnInit(): void {
    this.employeeid = Number(this._route.snapshot.queryParams['EmployeeID']);
    if(isNaN(this.employeeid)){
      this.employeeid = 0
    }else
    if(this.employeeid != 0){
      this.getEmployeeData(this.employeeid);
    }
    this.initForm();
    this.employees = [];
    this.getData();
    this.getAllVisaStatus();
    this.getAllLocations();
    this.getAllEmployeeTypes();
    this.getAllProjectStatus();
    this.getProjectData();
    this.getemployeesalary();
    this.getEmployeeProjectsdata();
    this.getEmployeeNotesData();
  }

  initForm() {
    this.employeeForm = this.formBuilder.group(
      {
        Id: [""],
        adpFileNumber: new FormControl(null, []),
        firstName: new FormControl(null, []),
        lastName: new FormControl(null, []),
        locationId: new FormControl(null, []),
        VisaStatusId: new FormControl(null, []),
        MarkettingBy: new FormControl(null, []),
        referredBy: new FormControl(null, []),
        DOJ: new FormControl(null, []),
        EmployeeTypeId: new FormControl(null, []),
        DOL: new FormControl(null, []),
        payrollstartDate: new FormControl(null, []),
        h1Wage: new FormControl(null, [])
      }
    )

    this.employeeprojectDetailsForm = this.formBuilder.group(
      {
        Id: [""],
        projectname: new FormControl(null, []),
        employeename: new FormControl(null, []),
        ProjectStatus: new FormControl(null, []),
        Vendor1: new FormControl(null, []),
        Vendor2: new FormControl(null, []),
        EndClient: new FormControl(null, []),
        ProjectStartDate: new FormControl(null, []),
        ProjectEndDate: new FormControl(null, [])
      }
    )

    this.employeeprojectPaymentDetailsForm = this.formBuilder.group(
      {
        Id: [""],

        BillRate: new FormControl(null, []),
        H1Wages: new FormControl(null, []),
        SalaryTypeId: new FormControl(null, []),
        SalaryOffered: new FormControl(null, []),
        PayPercentage: new FormControl(null, []),
        HourlyRate: new FormControl(null, []),
        PTO: new FormControl(null, []),
        InsurenceByUs: new FormControl(null, [])
      }
    )
    this.employeeNotesForm = this.formBuilder.group(
      {
        Id: [""],
        EmployeeId: [""],
        Notes: new FormControl(null, [])

      })


  }


  onTableDataChange(event: any) {
    this.page = event;
    this.getEmployeeProjectsdata();
    this.getEmployeeNotesData();
  }
  onTableSizeChange(event: any): void {
    this.tableSize = event.target.value;
    this.page = 1;
    this.getEmployeeProjectsdata();
    this.getEmployeeNotesData();
  }

  getData() {
    this.employeeService.getMember().subscribe((data) => {
      if (data != null) {
        this.employees = data;
      }
    });
  }

 

  getAllVisaStatus() {
    this.employeeService.getvisaStatus().subscribe(
      (data) => {
        this.visa = data;
      }
    )
  }

  getAllProjectStatus() {
    this.projectService.getAllProjetStatus().subscribe(
      (data) => {
        this.projectStatusData = data;
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

  getemployeesalary() {
    this.projectService.getemployeesalary().subscribe(
      (data) => {
        this.getSalaryType = data;
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



  getProjectData() {
    this.projectService.getAllProjects().subscribe((data) => {
      if (data != null) {
        this.projData = data;

      }
    });
  }

 
  ShowAddprojectModal() {
    this._showAddprojectModal = 'block'
  }
  ShowAddprojectPayModal() {
    this._showAddprojectPayModal = 'block'
  }

  ShowEmployeeNotesModal(){
    this._showAddEmployeeNotesModal = 'block'
  }

  CloseContractChangeModel() {
    this._showAddprojectModal = 'none'
  }
  CloseAddProjectPayModal() {
    this._showAddprojectPayModal = 'none'
  }

  CloseEmployeeNotesModal(){
    this._showAddEmployeeNotesModal = 'none'
  }
  updateEmployeesData() {
    this.isEmployeeEdit = true;
    let memdata = {
      Id: Number(this.employeeForm.get('Id')?.value),
      adpFileNumber: this.employeeForm.get('adpFileNumber')?.value,
      firstName: this.employeeForm.get('firstName')?.value,
      lastName: this.employeeForm.get('lastName')?.value,
      locationId: this.employeeForm.get('locationId')?.value,
      VisaStatusId: this.employeeForm.get('VisaStatusId')?.value,
      MarkettingBy: this.employeeForm.get('MarkettingBy')?.value,
      referredBy: this.employeeForm.get('referredBy')?.value,
      DOJ: this.employeeForm.get('DOJ')?.value.Tostring(),
      EmployeeTypeId: this.employeeForm.get('EmployeeTypeId')?.value,
      DOL: this.employeeForm.get('DOL')?.value.Tostring(),
      payrollstartDate: this.employeeForm.get('payrollstartDate')?.value.Tostring(),
      h1Wage: this.employeeForm.get('h1Wage')?.value.Tostring(),

    }
    this.employeeService.updateEmployeesData(memdata).subscribe(
      (data) => {
        if (data != null) {
          if (data.Success == 'true') {
            this.getData();
          }
        }
      });
    this.clearEmployeeData()
    this.isEdit = false;
  }

  formatDate(d) {
    var date = new Date(d)
    var dd = date.getDate();
    var mm = date.getMonth() + 1;
    var s = dd.toString();
    var m = mm.toString();
    var yyyy = date.getFullYear();
    if (dd < 10) { s = '0' + dd }
    if (mm < 10) { m = '0' + mm };
    return d = yyyy + '-' + m + '-' + s
  }

  submitEmployeesData() {
    this.isEmployeeEdit = false;
      let memdata = {
        Id: Number(this.employeeForm.get('Id')?.value),
        adpFileNumber: this.employeeForm.get('adpFileNumber')?.value,
        firstName: this.employeeForm.get('firstName')?.value,
        lastName: this.employeeForm.get('lastName')?.value,
        locationId: this.employeeForm.get('locationId')?.value,
        VisaStatusId: this.employeeForm.get('VisaStatusId')?.value,
        MarkettingBy: this.employeeForm.get('MarkettingBy')?.value,
        referredBy: this.employeeForm.get('referredBy')?.value,
        DOJ: this.employeeForm.get('DOJ')?.value,
        EmployeeTypeId: this.employeeForm.get('EmployeeTypeId')?.value,
        DOL: this.employeeForm.get('DOL')?.value,
        payrollstartDate: this.employeeForm.get('payrollstartDate')?.value,
        H1wageDate: this.employeeForm.get('h1Wage')?.value,
      }
      this.employeeService.saveEmployeesData(memdata).subscribe(
        (data) => {
          if (data.errors != null) {
            this.isEmployeeEdit = false;
            this.toastrService.error(data.errors.Es201[0]);
          } else {
            if (data.result.id != null) {
              this.toastrService.success('Employee Added Successfully');
              this.empData = data.result;
              if (this.empData.id != null) {
                this.isEmployeeEdit = true;
               var dojDate = new Date(this.empData.doj);
               var gDojDate = this.formatDate(dojDate);

               var dolDate = new Date(this.empData.dol);
               var gDolDate = this.formatDate(dolDate);

               var h1Date = new Date(this.empData.h1wageDate);
               var gH1Date = this.formatDate(h1Date);

               var payrollDate = new Date(this.empData.payrollStartDate);
               var gPayRollDate = this.formatDate(this.empData.payrollStartDate);

                this.employeeForm.get('adpFileNumber').setValue(this.empData.adpFileNumber);
                this.employeeForm.get('firstName').setValue(this.empData.firstName);
                this.employeeForm.get('lastName').setValue(this.empData.lastName);
                this.employeeForm.get('MarkettingBy').setValue(this.empData.markettingBy);
                this.employeeForm.get('referredBy').setValue(this.empData.referredBy);
                this.employeeForm.get('EmployeeTypeId').setValue(this.empData.employeeTypeId);
                this.employeeForm.get('VisaStatusId').setValue(this.empData.visaStatusId);
                this.employeeForm.get('locationId').setValue(this.empData.locationId);
                this.employeeForm.get('DOJ').setValue(gDojDate);
                this.employeeForm.get('DOL').setValue(gDolDate);
                this.employeeForm.get('h1Wage').setValue(gH1Date);
                this.employeeForm.get('payrollstartDate').setValue(gPayRollDate);
              }
              localStorage.setItem("EmployeeId", data.result.id);
              this.getEmployeeProjectsdata();
              this.getData();
            }
          }
        });  
  }

  getEmployeeData(employeeid: any) {
    this.isEmployeeEdit = true;
    if (employeeid != null) {
      this.employeeService.getEmpDataById(employeeid).subscribe(
        (data) => {
         
            this.empDetails = data;
            var eDojDate = new Date(this.empDetails.doj);
            var egDojDate = this.formatDate(eDojDate);

            var eDolDate = new Date(this.empDetails.dol);
            var egDolDate = this.formatDate(eDolDate);

            var eH1Date = new Date(this.empDetails.h1wageDate);
            var egH1Date = this.formatDate(eH1Date);

            var ePayrollDate = new Date(this.empDetails.payrollStartDate);
            var egPayRollDate = this.formatDate(ePayrollDate);

            this.employeeForm.get('adpFileNumber').setValue(this.empDetails.adpFileNumber);
            this.employeeForm.get('firstName').setValue(this.empDetails.firstName);
            this.employeeForm.get('lastName').setValue(this.empDetails.lastName);
            this.employeeForm.get('MarkettingBy').setValue(this.empDetails.markettingBy);
            this.employeeForm.get('referredBy').setValue(this.empDetails.referredBy);
            this.employeeForm.get('EmployeeTypeId').setValue(this.empDetails.employeeTypeId);
            this.employeeForm.get('VisaStatusId').setValue(this.empDetails.visaStatusId);
            this.employeeForm.get('locationId').setValue(this.empDetails.locationId);
            this.employeeForm.get('DOJ').setValue(egDojDate);
            this.employeeForm.get('DOL').setValue(egDolDate);
            this.employeeForm.get('h1Wage').setValue(egH1Date);
            this.employeeForm.get('payrollstartDate').setValue(egPayRollDate);
          })
    };
  }

  submitEmployeeProjects() {
    this.isEmployeeProjectsedit = false;
    this._employeeProjectDetails = new EmployeeProjectDetails();
    this._employeeProjectDetails.ProjectId = Number(this.employeeprojectDetailsForm.controls['projectname'].value)
    this._employeeProjectDetails.EmployeeId = Number(localStorage.getItem('EmployeeId'));
    this._employeeProjectDetails.ProjectStatusID = Number(this.employeeprojectDetailsForm.controls['ProjectStatus'].value)
    this._employeeProjectDetails.Vendor1Id = this.employeeprojectDetailsForm.controls['Vendor1'].value
    this._employeeProjectDetails.Vendor2Id = this.employeeprojectDetailsForm.controls['Vendor2'].value
    this._employeeProjectDetails.EndClientId = this.employeeprojectDetailsForm.controls['EndClient'].value
    this._employeeProjectDetails.StartDate = this.employeeprojectDetailsForm.controls['ProjectStartDate'].value
    this._employeeProjectDetails.EndDate = this.employeeprojectDetailsForm.controls['ProjectEndDate'].value
    this.projectService.addPersonProjectDetails(this._employeeProjectDetails).subscribe(
      (data) => {
        if (data.errors > 0) {
          this.toastrService.error(data.errors.Es201[0]);
        } else
          if (data.result.id != null) {
            this.toastrService.success('EmployeeProjects Added Successfully');
            this.prjData = data.result;
            this.getEmployeeProjectsdata();
            this.clearEmployeeProjectData();
            this.CloseContractChangeModel();
          }
      });
  }


  getEmployeeProjectsdata() {
    if(this.employeeid != null){
      this.getEmpPrjId = this.employeeid;
    }else{
      this.getEmpPrjId = Number(localStorage.getItem('EmployeeId'));
    }
    this.employeeService.getAllEmpProjectsDetils(this.getEmpPrjId).subscribe(
      (data) => {
        this.empProjData = data;
      });
  }

  ShoweditprojectModal(EmpProjDetails: any) {
    this.isEmployeeProjectsedit = true;
    this._showAddprojectModal = 'block'
  var prjStartDate = new Date(EmpProjDetails.startDate);
  var ePrjStartDate = this.formatDate(prjStartDate);

  var prjEndDate = new Date(EmpProjDetails.endDate);
  var ePrjEndDate = this.formatDate(prjEndDate);

     this.employeeprojectDetailsForm.get('Id').setValue(EmpProjDetails.id);
    this.employeeprojectDetailsForm.get('projectname').setValue(EmpProjDetails.projectId);
    this.employeeprojectDetailsForm.get('Vendor1').setValue(EmpProjDetails.vendor1Id);
    this.employeeprojectDetailsForm.get('Vendor2').setValue(EmpProjDetails.vendor2Id);
    this.employeeprojectDetailsForm.get('EndClient').setValue(EmpProjDetails.endClientId);
    this.employeeprojectDetailsForm.get('ProjectStartDate').setValue(ePrjStartDate);
    this.employeeprojectDetailsForm.get('ProjectEndDate').setValue(ePrjEndDate);
    this.employeeprojectDetailsForm.get('ProjectStatus').setValue(EmpProjDetails.projectStatusID);

  }

  updateEmployeeProjects() {
    this.isEmployeeProjectsedit = true;
    this._employeeProjectDetails = new EmployeeProjectDetails();
    this._employeeProjectDetails.Id = Number(this.employeeprojectDetailsForm.controls['Id'].value)
    this._employeeProjectDetails.ProjectId = Number(this.employeeprojectDetailsForm.controls['projectname'].value)
    this._employeeProjectDetails.EmployeeId = Number(localStorage.getItem('EmployeeId'));
    this._employeeProjectDetails.ProjectStatusID = Number(this.employeeprojectDetailsForm.controls['ProjectStatus'].value)
    this._employeeProjectDetails.Vendor1Id = this.employeeprojectDetailsForm.controls['Vendor1'].value
    this._employeeProjectDetails.Vendor2Id = this.employeeprojectDetailsForm.controls['Vendor2'].value
    this._employeeProjectDetails.EndClientId = this.employeeprojectDetailsForm.controls['EndClient'].value
    this._employeeProjectDetails.StartDate = this.employeeprojectDetailsForm.controls['ProjectStartDate'].value
    this._employeeProjectDetails.EndDate = this.employeeprojectDetailsForm.controls['ProjectEndDate'].value
    this.projectService.updateEmployeeProjectDetails(this._employeeProjectDetails).subscribe(
      (data) => {
        if (data.errors > 0) {
          this.toastrService.error(data.errors.Es201[0]);
        } else
          if (data.result.id != null) {
            this.toastrService.success('EmployeeProjects Updated Successfully');
            this.prjData = data.result;
            this.getEmployeeProjectsdata();
            this.clearEmployeeProjectData();
            this.CloseContractChangeModel();
          }
      });
  }

  employeePayDetailsSubmit() {
    this._employeeProjectPayDetails = new EmployeeProjectPayDetails();
    this._employeeProjectPayDetails.EmployeeProjectId = this.empProjData[0].id
    this._employeeProjectPayDetails.BillRate = this.employeeprojectPaymentDetailsForm.controls['BillRate'].value
    this._employeeProjectPayDetails.H1Wages = this.employeeprojectPaymentDetailsForm.controls['H1Wages'].value
    this._employeeProjectPayDetails.SalaryTypeId = this.employeeprojectPaymentDetailsForm.controls['SalaryTypeId'].value
    this._employeeProjectPayDetails.SalaryOffered = this.employeeprojectPaymentDetailsForm.controls['SalaryOffered'].value
    this._employeeProjectPayDetails.PayPercentage = this.employeeprojectPaymentDetailsForm.controls['PayPercentage'].value
    this._employeeProjectPayDetails.HourlyRate = this.employeeprojectPaymentDetailsForm.controls['HourlyRate'].value
    this._employeeProjectPayDetails.PTO = Number(this.employeeprojectPaymentDetailsForm.controls['PTO'].value)
    if (this._employeeProjectPayDetails.PTO == 1) {
      this._employeeProjectPayDetails.PTO = true;
    } else {
      this._employeeProjectPayDetails.PTO = false;
    }
    this._employeeProjectPayDetails.InsurenceByUs = Number(this.employeeprojectPaymentDetailsForm.controls['InsurenceByUs'].value)
    if (this._employeeProjectPayDetails.InsurenceByUs == 1) {
      this._employeeProjectPayDetails.InsurenceByUs = true;
    } else {
      this._employeeProjectPayDetails.InsurenceByUs = false;
    }
    this.projectService.addEmployeeProjectPayDetails(this._employeeProjectPayDetails).subscribe(
      (data) => {
        if (data.result.id != null) {
          this.toastrService.success('Payment Done Successfully');
          this.prjData = data.result;
          this.clearProjectPayData();
        
        }

      });
  }

  submitEmployeeNotes() {
    this.isEmployeeNotesedit = false;
    this.employeeNotes = new EmployeeNotes();
    this.employeeNotes.EmployeeId = Number(localStorage.getItem('EmployeeId'));
      this.employeeNotes.Notes = this.employeeNotesForm.controls['Notes'].value
    this.employeeService.saveEmployeeNotes(this.employeeNotes).subscribe(
      (data) => {
        if(data.errors != null){
          this.toastrService.error(data.errors.Es201[0]);
        }
        if (data != null) {
          this.toastrService.success('EmployeeNotes Added Successfully');
          this.AllempNotes = data.result;
          this.clearEmployeeNotesData();
          this.CloseEmployeeNotesModal();
          this.getEmployeeNotesData();


        }

      });
  }

  getEmployeeNotesData(){
    if(this.employeeid != null){
      this.getNotesForEmpId = this.employeeid;
    }else{
      this.getNotesForEmpId = Number(localStorage.getItem('EmployeeId'));
    }
  
    this.employeeService.getAllEmpNotesDetils(this.getNotesForEmpId).subscribe(
      (data) => {

        this.empNotesData = data;

      });
  }

  ShoweditEmployeeNotesModal(note:any){
    this._showAddEmployeeNotesModal = 'block'
    this.isEmployeeNotesedit = true;
    this.employeeNotesForm.get('Notes').setValue(note.notes);

  }

  updateEmployeeNotes(){
    this.isEmployeeNotesedit = true;
    this.employeeNotes = new EmployeeNotes();
    this.employeeNotes.EmployeeId = Number(localStorage.getItem('EmployeeId'));
      this.employeeNotes.Notes = this.employeeNotesForm.controls['Notes'].value
    this.employeeService.updateEmployeeNotes(this.employeeNotes).subscribe(
      (data) => {
        if(data.errors != null){
          this.toastrService.error(data.errors.Es201[0]);
        }
        if (data != null) {
          this.toastrService.success('EmployeeNotes Added Successfully');
          this.AllempNotes = data.result;
          this.clearEmployeeNotesData();
          this.CloseEmployeeNotesModal();
          this.getEmployeeNotesData();
        }
      });
  }

  removeMember(Id: number) {
    let index = this.employees.indexOf(Id);

    this.employeeService.deleteMember(Id).subscribe(data => {
      this.employees = this.employees.filter(() => Id !== Id);
      this.getData();
    })
  }


  clearEmployeeProjectData() {
    this.employeeprojectDetailsForm.reset();
  }

  clearProjectPayData() {
    this.employeeprojectPaymentDetailsForm.reset();
  }
  clearEmployeeData() {
    this.employeeForm.reset();
  }
  clearEmployeeNotesData() {
    this.employeeNotesForm.reset();
  }

}
