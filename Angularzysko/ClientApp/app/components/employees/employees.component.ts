import { Component } from '@angular/core';
import { EmployeeService } from './Services/employee.service'

@Component({
    selector: 'employees',
    template: require('./employees.component.html'),
    providers: [EmployeeService]
})
export class EmployeesComponent {

    constructor(private employeeService: EmployeeService) { }


}