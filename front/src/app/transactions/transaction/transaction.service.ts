import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';

import { Transaction } from "./transaction";
import { TokenService } from 'src/app/core/token/token.service';

@Injectable({ providedIn: 'root' })
export class TransactionService {

    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') private baseUrl: string,
        private tokenService: TokenService
        ) {}

    listFromId(id: string) {
        return this.http
            .get<Transaction[]>(
                this.baseUrl + 'transaction/' + id,
                { headers: new HttpHeaders().set('Authorization', 'Bearer ' + this.tokenService.getToken())});
    }

    addTransaction(transaction: Transaction) {
        console.log(transaction);
        return this.http
            .post(
                this.baseUrl + 'transaction/',
                transaction,
                { headers: new HttpHeaders().set('Authorization', 'Bearer ' + this.tokenService.getToken())});
    }
}
