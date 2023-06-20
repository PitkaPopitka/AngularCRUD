import { Component, Input, OnInit } from '@angular/core';
import { ApiserviceService } from 'src/app/apiservice.service';

@Component({
  selector: 'app-add-edit-employee',
  templateUrl: './add-edit-employee.component.html',
  styleUrls: ['./add-edit-employee.component.css']
})
export class AddEditEmployeeComponent implements OnInit {
  constructor(private service: ApiserviceService) {}

  @Input() emp: any;
  EmployeeId = "";
  Department = "";
  EmployeeName = "";
  DateOfBirth = "";
  EmploymentDate = "";
  Salary = "";
  EmployeesList: any = [];
  DepartmentsList: any =[];

  LoadEmployees(){
      this.service.getEmployeeList().subscribe((data: any) => {
        this.EmployeesList = data;

        this.EmployeeId = this.emp.EmployeeId;
        this.Department = this.emp.Department;
        this.EmployeeName = this.emp.EmployeeName;
        this.DateOfBirth = this.emp.DateOfBirth;
        this.EmploymentDate = this.emp.EmploymentDate;
        this.Salary = this.emp.Salary;
      })
  }
  refreshDepsList(){
    this.service.departmentsList().subscribe(data => { this.DepartmentsList = data })
  }

  ngOnInit(): void {
    this.LoadEmployees();
    this.refreshDepsList();
  }

  addEmployee(){
    var val = {
      EmployeeId: this.EmployeeId,
      Department: this.Department,
      EmployeeName: this.EmployeeName,
      DateOfBirth: this.DateOfBirth,
      EmploymentDate: this.EmploymentDate,
      Salary: this.Salary
    };

    this.service.addEmployee(val).subscribe(res => {
      alert(res.toString());
    });
  }

  updateEmployee(){
    var val = {
      EmployeeId: this.EmployeeId,
      Department: this.Department,
      EmployeeName: this.EmployeeName,
      DateOfBirth: this.DateOfBirth,
      EmploymentDate: this.EmploymentDate,
      Salary: this.Salary
    };

    this.service.updateEmployee(val).subscribe(res => {
      alert(res.toString());
    });
  }
}
