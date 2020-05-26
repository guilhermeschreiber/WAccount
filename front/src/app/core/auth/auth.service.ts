import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { tap } from 'rxjs/operators';
import { UserService } from '../user/user.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private http: HttpClient,
    private userService: UserService,
    @Inject('BASE_URL') private baseUrl: string
  ) { }

  authenticate(email: string, password: string) {

    return this.http
      .get<number>(
        this.baseUrl + 'login?email=' + email + '&password='+password,
        { observe: 'response'}
      )
      .pipe(tap(res => {
        const authToken = res.headers.get('x-access-token');
        this.userService.setToken(authToken);
      }));
  }
}
