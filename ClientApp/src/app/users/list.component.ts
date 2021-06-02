import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { Router } from '@angular/router';
import { UserService } from '@app/_services';

@Component({ templateUrl: 'list.component.html' })
export class ListComponent implements OnInit {
    users = null;

    constructor(private userService: UserService,private router: Router) {}

    ngOnInit() {
        this.userService.getAll()
            .subscribe(user => this.users = user);
    }

    deleteUser(id: number) {
        const user = this.users.find(x => x.id === id);
        user.isDeleting = true;
        this.userService.delete(id)
            .subscribe(() => this.users = this.users.filter(x => x.id !== id));
    }
    logout() {
        this.router.navigate(['/login']);
    }
}