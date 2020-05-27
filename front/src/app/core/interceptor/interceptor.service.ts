import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { TokenService } from '../token/token.service';
import { catchError } from 'rxjs/operators';
import { UserService } from '../user/user.service';
import { Router } from '@angular/router';

@Injectable()
export class InterceptorService implements HttpInterceptor {

    constructor(
        private tokenService: TokenService,
        private userService: UserService,
        private router: Router) { }

    private setHeaders(request: HttpRequest<any>) {
        if (this.tokenService.hasToken())
        {
            request = request.clone({
                setHeaders: {
                    'content-type': 'application/json', 
                     Authorization: 'Bearer ' + this.tokenService.getToken()
                }
             });
        }
        return request;
    }

    private onError(response: HttpErrorResponse): void
    {
        const status: number = response.status;
    
        switch(status)
        {
            case 400:
                console.log("Bad request");
        
            case 401:
                alert('Your session token has expired. Please, login');
                this.userService.logout();
                this.router.navigate(['']);

            case 404:
                console.log("Not found");
        }
    }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>>
    {
        request = this.setHeaders(request);
        return next
            .handle(request)
            .pipe(catchError(err => 
                {
                    if (err instanceof HttpErrorResponse)
                    {
                        this.onError(err);
                    }
                    return throwError(err);
                }
            ));

    }
}