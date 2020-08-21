import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customer } from '../typings/models';

const baseUrl = 'http://localhost:5000/api/customer';


@Injectable({
    providedIn: 'root'
})

export class CustomerService {
    constructor(private http: HttpClient) { }

    getList(): Observable<any> {
        return this.http.get(baseUrl);
    }

    get(id: number): Observable<any> {
        return this.http.get(`${baseUrl}/${id}`);
    }

    create(customer: Customer): Observable<any> {
        return this.http.post(baseUrl, customer);
    }

    update(id: number, customer: Customer): Observable<any> {
        return this.http.put(`${baseUrl}/${id}`, customer);
    }

    delete(id: number): Observable<any> {
        return this.http.delete(`${baseUrl}/${id}`);
    }
}
