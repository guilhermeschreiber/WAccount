import { Pipe, PipeTransform } from '@angular/core';
import { TransactionResult } from 'src/app/transactions/transaction/transaction.result';

@Pipe({
  name: 'resultAsString'
})

export class ResultAsString implements PipeTransform
{
    transform(value: TransactionResult) : string 
    {
      return TransactionResult[value];
    }
}