import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../Services/employee.service'
import { NgForm } from '@angular/forms'

@Component({
    selector: 'employee',
    template: require('./employee.component.html')
})
export class EmployeeComponent implements OnInit{

    constructor(private employeeService: EmployeeService) { }

    ngOnInit() {
        this.resetForm();
    }

    resetForm(form?: NgForm) {
        if(form != null)
        form.reset();
        this.employeeService.selectedEmployee = {
            ID: null,
            Name : '',
            Surname : '',
            Address : '',
            Telephone : ''
        }
    }

    onSubmit(form: NgForm) {
        if (form.value.ID == null) {
            form.value.ID = 0;
            this.employeeService.postEmployee(form.value)
                .subscribe(data => {
                    this.resetForm(form);
                    this.employeeService.getEmployeeList();
                })
        }
        else {
            this.employeeService.putEmployee(form.value.ID, form.value)
                .subscribe(data => {
                    this.resetForm(form);
                    this.employeeService.getEmployeeList();
                });
            }
        
    }

    }
