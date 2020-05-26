import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TransactionListComponent } from './transactions/transaction-list/transaction-list.component';
import { TransactionAddComponent } from './transactions/transaction-add/transaction-add.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { SignInComponent } from './home/signin/signin.component';
import { AuthGuard } from './core/auth/auth.guard';

const routes: Routes = [
    { 
        path: '',
        component: SignInComponent,
        canActivate: [AuthGuard]
    },    
    { 
        path: 'transactions', 
        component: TransactionListComponent
    },
    { 
        path: 'add', 
        component: TransactionAddComponent
    },
    { 
        path: '**', 
        component: NotFoundComponent 
    }  
];

@NgModule({
    imports: [ 
        RouterModule.forRoot(routes) 
    ],
    exports: [ RouterModule ]
})
export class AppRoutingModule { }

