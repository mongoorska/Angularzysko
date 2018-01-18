import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../Services/employee.service'
import { Employee } from '../Models/employee.model'

@Component({
    selector: 'employee-list',
    template: require('./employee-list.component.html')
})
export class EmployeeListComponent implements OnInit{

    constructor(private employeeService: EmployeeService) { }

    ngOnInit() {
        this.employeeService.getEmployeeList();
    }

    showForEdit(ename: string, esurname:string, etelephone:string, eaddress:string, eid:any) {
        this.employeeService.selectedEmployee.Name = ename;
        this.employeeService.selectedEmployee.Surname = esurname;
        this.employeeService.selectedEmployee.Telephone = etelephone;
        this.employeeService.selectedEmployee.Address = eaddress;
        this.employeeService.selectedEmployee.ID = eid;

    }

    onDelete(id: any) { 
        if (confirm('Are you sure?') == true) {
            this.employeeService.deleteEmployee(id)
                .subscribe(x => {
                    this.employeeService.getEmployeeList();

                })
        }
    }

}