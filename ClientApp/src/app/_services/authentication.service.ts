import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from '@environments/environment';
import { Account } from '@app/_models/account';

const baseUrl = `https://localhost:5001/login`;

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    private currentAccountSubject: BehaviorSubject<Account>;
    public currentAccount: Observable<Account>;

    constructor(private http: HttpClient) {
        this.currentAccountSubject = new BehaviorSubject<Account>(JSON.parse(localStorage.getItem('currentAccount')));
        this.currentAccount = this.currentAccountSubject.asObservable();
    }

    public get currentAccountValue(): Account {
        return this.currentAccountSubject.value;
    }

    login(accountname: string, password:string) {
        return this.http.post<any>(`${baseUrl}`, { accountname, password })
            .pipe(map(Account => {
                // store Account details and jwt token in local storage to keep Account logged in between page refreshes
                localStorage.setItem('currentAccount', JSON.stringify(Account));
                this.currentAccountSubject.next(Account);
                return Account;
            }));
    }

    logout() {
        // remove Account from local storage and set current Account to null
        localStorage.removeItem('currentAccount');
        this.currentAccountSubject.next(null);
    }
}