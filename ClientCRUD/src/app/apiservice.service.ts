import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class ApiserviceService {
  readonly apiUrl = 'https://localhost:7051/api/';

  constructor(private http: HttpClient) { }

  getEmployeeList(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl + 'Employees/EmployeesList');
  }

  addEmployee(employee: any): Observable<any>{
    const httpOptions = { headers: new HttpHeaders({ 'Content-type': 'application/json' }) };

    return this.http.post<any>(this.apiUrl + 'Employees/AddEmployee', employee, httpOptions);
  }

  updateEmployee(employee: any): Observable<any>{
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };

    return this.http.put<any>(this.apiUrl + 'Employees/UpdateEmployee', employee, httpOptions);
  }

  deleteEmployee(employeeId: number): Observable<number>{
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };

    return this.http.delete<number>(this.apiUrl + 'Employees/DeleteEmployee/' + employeeId, httpOptions);
  }
}
