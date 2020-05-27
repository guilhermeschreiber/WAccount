import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';

import { Transaction } from "./transaction";

@Injectable({ providedIn: 'root' })
export class TransactionService {

    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') private baseUrl: string
        ) {}

    listFromId(id: string)
    {
        return this.http.get<Transaction[]>(this.baseUrl + 'transaction/' + id);
    }

    addTransaction(transaction: Transaction)
    {
        return this.http.post(this.baseUrl + 'transaction/',transaction);
    }
}
