import { TransactionType } from './transaction.type';
import { TransactionResult } from './transaction.result';

export interface Transaction {
    userId: number;
    user: null;
    type: TransactionType;
    amount: number;
    scheduling: Date;
    result: TransactionResult;
    id: number;
    updatedAt: Date;  
}