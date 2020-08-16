import { Component, OnInit } from '@angular/core';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
    selector: 'app-customer-list',
    templateUrl: './customer-list.component.html',
    styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {
    customers = [];
    currentIndex = -1;

    constructor(private customerService: CustomerService) { }

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
                });
    }

    expandCustomer(customer, i) {
        this.currentIndex = (this.currentIndex == i) ? -1 : i;
    }

    deleteCustomer(customer) {
        
    }

    editCustomer(customer) {

    }
}
