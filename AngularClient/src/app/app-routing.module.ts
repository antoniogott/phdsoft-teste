import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomerListComponent } from 'src/app/components/customer-list/customer-list.component';
import { CreateCustomerComponent } from 'src/app/components/create-customer/create-customer.component';

const routes: Routes = [
    { path: '', component: CustomerListComponent },
    { path: 'new', component: CreateCustomerComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
