import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

const baseUrl = 'http://localhost:5000/api/customer';


@Injectable({
    providedIn: 'root'
})

export class CustomerService {
    constructor(private http: HttpClient) { }

    getList(): Observable<any> {
        return this.http.get(baseUrl);
    }

    get(id): Observable<any> {
        return this.http.get(`${baseUrl}/${id}`);
    }

    create(data): Observable<any> {
        return this.http.post(baseUrl, data);
    }

    update(id, data): Observable<any> {
        return this.http.put(`${baseUrl}/${id}`, data);
    }

    delete(id): Observable<any> {
        return this.http.delete(`${baseUrl}/${id}`);
    }
}
