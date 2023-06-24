import { Component, OnInit } from '@angular/core';
import { ApiserviceService } from '../apiservice.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  constructor(private service: ApiserviceService){}


  EmployeesList: any = [];
  ModalTitle = "";
  AddEditEmployeeComp: boolean = false;
  emp: any;

  refreshEmployeesList(){
    this.service.getEmployeeList().subscribe(data => { this.EmployeesList = data })
  }



  ngOnInit(): void {
    this.refreshEmployeesList();
  }

  AddClick(){
    this.emp = {
      EmployeeId: "0",
      EmployeeDepartment: "",
      EmployeeName: "",
      EmployeeStatus: "",
      EmployeeDateOfBirth: "",
      EmployeeEmploymentDate: "",
      EmployeeSalary: ""
    }

    this.ModalTitle = "Add employee";
    this.AddEditEmployeeComp = true;
  }

  EditClick(item: any){
    this.emp = item;
    this.ModalTitle = "Edit employee";
    this.AddEditEmployeeComp = true;
  }

  CloseClick(){
    this.AddEditEmployeeComp = false;
    this.refreshEmployeesList();
  }

  DeleteClick(id: number){
    console.log(id);
    if (confirm("Are you sure?")) { 
      this.service.deleteEmployee(id).subscribe(data => {
        alert(data.toString())
        this.refreshEmployeesList();
      })
    }

  }
}
