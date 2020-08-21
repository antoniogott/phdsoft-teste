import { Component, OnInit } from '@angular/core';
import { CustomerService } from 'src/app/services/customer.service';
// import { DependentService } from '../../services/dependent.service';
import { DependentService } from 'src/app/services/dependent.service';
import { Customer, Dependent } from 'src/app/typings/models';

@Component({
    selector: 'app-customer-list',
    templateUrl: './customer-list.component.html',
    styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {
    customers: Customer[] = [];
    currentIndex = -1;

    constructor(private customerService: CustomerService, private dependentService: DependentService) { }

    ngOnInit() {
        this.getCustomers();
    }

    getCustomers() {
        this.customerService.getList()
            .subscribe(
                data => {
                    this.customers = data;
                },
                error => {
                    console.error(error);
                    alert(error);
                });
    }

    expandCustomer(customer: Customer, index:number) {
        this.currentIndex = (this.currentIndex == index) ? -1 : index;
    }

    deleteCustomer(customer: Customer) {
        this.customerService.delete(customer.id).subscribe(
            data => {
                const divDep = document.getElementById(`customer_${customer.id}`);
                divDep.parentNode.removeChild(divDep);
            },
            error => {
                console.error(error);
                alert(error);
            }
        );
    }

    editCustomer(customer: Customer) {

    }

    deleteDependent(dependent: Dependent) {
        this.dependentService.delete(dependent.id).subscribe(
            data => {
                const divDep = document.getElementById(`dep_${dependent.id}`);
                divDep.parentNode.removeChild(divDep);
            },
            error => {
                console.error(error);
                alert(error);
            }
        );
    }
}
