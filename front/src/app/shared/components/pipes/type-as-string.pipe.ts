import { Pipe, PipeTransform } from '@angular/core';
import { TransactionType } from 'src/app/transactions/transaction/transaction.type';

@Pipe({
  name: 'typeAsString'
})

export class TypeAsString implements PipeTransform
{
    transform(value: TransactionType) : string 
    {
      return TransactionType[value];
    }
}