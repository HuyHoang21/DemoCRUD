import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '@environments/environment';
import { User } from '@app/_models';
import {Account} from '@app/_models/account'
import { Observable } from 'rxjs';

const baseUrl = `${environment.apiUrl}`;

@Injectable({ providedIn: 'root' })
export class UserService {
    constructor(private http: HttpClient) { }
  /** GET heroes from the server */

    getAll(){
       // console.log(baseUrl)
        return this.http.get<User[]>(baseUrl);
    }

    getById(id: number) {
        return this.http.get<User>(`${baseUrl}/${id}`);
    }

    create(params: any) {
        return this.http.post(baseUrl, params);
    }

    update(id: number, params: any) {
        return this.http.put(`${baseUrl}/${id}`, params);
    }

    delete(id: number) {
        return this.http.delete(`${baseUrl}/${id}`);
    }
    register(account: Account) {
        return this.http.post(`${baseUrl}/users/register`, account);
    }
}