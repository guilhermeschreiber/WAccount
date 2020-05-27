import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { UserService } from 'src/app/core/user/user.service';
import { TransactionService } from '../transaction/transaction.service';
import { Transaction } from '../transaction/transaction';

@Component({
  templateUrl: './transaction-add.component.html'
})
export class TransactionAddComponent implements OnInit
{
  transactionForm: FormGroup;
  transaction: Transaction = {} as Transaction;
    
    constructor(
        private formBuilder: FormBuilder,
        private transactionService: TransactionService,
        private userService: UserService,
        private router: Router
        ) { }

    ngOnInit(): void
    {
        this.transactionForm = this.formBuilder.group
        ({
          type: ['Credit', Validators.required],
          amount: ['', Validators.required],
          scheduling: ['', Validators.required]
        });
    } 

    add()
    {
      if (this.userService.isLogged())
      {
        this.transaction.userId = Number(this.userService.getUserId());
        this.transaction.type = Number(this.transactionForm.get('type').value == "Debit");
        this.transaction.amount = Number(this.transactionForm.get('amount').value);
        this.transaction.scheduling = this.transactionForm.get('scheduling').value;

        this.transactionService
          .addTransaction(this.transaction)
          .subscribe(
              () => 
              {
                alert('Sucess');
                this.router.navigate(['transactions']);
              },
              err => 
              {
                console.log(err);
                alert('Error in submitting');
                this.transactionForm.reset();
              });
        }
        else
        {
          this.router.navigate(['']);
        }
    }
}
