import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TransactionListComponent } from './transaction-list.component';
import { TransactionModule } from '../transaction/transaction.module';
import { TypeAsString } from 'src/app/shared/components/pipes/type-as-string.pipe';
import { ResultAsString } from 'src/app/shared/components/pipes/result-as-string.pipe';

@NgModule({
    declarations: [
        TransactionListComponent,
        TypeAsString,
        ResultAsString
    ],
    imports: [ 
        CommonModule,
        TransactionModule
    ]
})
export class TransactionListModule {}