import { NgModule } from '@angular/core';
import { TransactionModule } from './transaction/transaction.module';
import { TransactionListModule } from './transaction-list/transaction-list.module';
import { ReactiveFormsModule } from '@angular/forms';
import { TransactionAddComponent } from './transaction-add/transaction-add.component';

@NgModule({
    declarations: [TransactionAddComponent],
    imports: [ 
        TransactionModule,
        TransactionListModule,
        ReactiveFormsModule
    ]
})
export class TransactionsModule {}