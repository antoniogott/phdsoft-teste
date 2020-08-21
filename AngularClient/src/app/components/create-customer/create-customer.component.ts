import { Component } from '@angular/core';
import { CustomerService } from 'src/app/services/customer.service';
import { Customer, Dependent } from 'src/app/typings/models';

@Component({
    selector: 'app-create-customer',
    templateUrl: './create-customer.component.html',
    styleUrls: ['./create-customer.component.css']
})
export class CreateCustomerComponent {

    constructor(private customerService: CustomerService) { }

    customer: Customer = {
        id: 0,
        cpf: '',
        name: '',
        age: 0,
        email: '',
        phone: '',
        address: '',
        dependents: []
    };

    onSubmit() {
        this.customerService.create(this.customer).subscribe(
            data => {
                alert(`Customer ${data.name} created successfully!`);
                window.location.href= "/";
            },
            error => {
                console.error(error);
                alert(error);
            });
    }

    addDependent() {
        this.customer.dependents.push({
            id: 0,
            name: '',
            cpf: '',
            age: 0,
            relationship: ''
        });
    }

    deleteDependent(dependent: Dependent) {
        const index = this.customer.dependents.indexOf(dependent);
        this.customer.dependents.splice(index, 1);
    }
}
