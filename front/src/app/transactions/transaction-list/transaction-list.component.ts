import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

import { Transaction } from '../transaction/transaction';
import { TransactionService } from '../transaction/transaction.service';
import { UserService } from 'src/app/core/user/user.service';
import { Account } from 'src/app/account/account';
import { AccountService } from 'src/app/account/account.service';

@Component({
  selector: 'wa-transaction-list',
  templateUrl: './transaction-list.component.html',
  styleUrls: ['./transaction-list.component.css']
})
export class TransactionListComponent
{
  transactions$: Observable<Transaction[]>;
  account$: Observable<Account>;

  constructor(
    private router: Router,
    private userService: UserService,
    private accountService : AccountService,
    private transactionService: TransactionService)
    { 
      if (userService.isLogged())
      {
        this.transactions$ = this.transactionService.listFromId(userService.getUserId());
        this.account$ = this.accountService.accountFromId(userService.getUserId());
      }
      else
      {
        this.router.navigate(['']);
      }
    }
}
