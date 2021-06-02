import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from '@environments/environment';
import { Account } from '@app/_models/account';

const baseUrl = `https://localhost:5001/login`;

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    public currentAccount: Observable<Account>;

    constructor(private http: HttpClient) {
    }

    login(username: string, password:string) {
        // return this.http.post(baseUrl, {username,password});
        return this.http.post<any>(baseUrl, { username, password });
    }

}