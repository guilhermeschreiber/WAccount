import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';

import { Account } from './account'
import { TokenService } from 'src/app/core/token/token.service';

@Injectable({ providedIn: 'root' })
export class AccountService {

    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') private baseUrl: string,
        private tokenService: TokenService
        ) {}

    accountFromId(id: string) {
        return this.http
            .get<Account>(
                this.baseUrl + 'user/' + id,
                { headers: new HttpHeaders().set('Authorization', 'Bearer ' + this.tokenService.getToken())});
    }
}
