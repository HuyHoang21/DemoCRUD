import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login';
import { RegisterComponent } from './register';
import { HomeComponent } from './home';
import { AuthGuard } from './_helpers';

const usersModule = () => import('./users/users.module').then(x => x.UsersModule);

const routes: Routes = [
    { path: '', component: HomeComponent},
    { path: 'users', loadChildren: usersModule },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    // otherwise redirect to home
    { path: '**', redirectTo: 'users' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }