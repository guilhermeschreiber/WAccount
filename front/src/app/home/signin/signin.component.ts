import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../../core/auth/auth.service';
import { Router } from '@angular/router';
import { PlatformDetectorService } from '../../core/plataform-detector/platform-detector.service';

@Component({
    templateUrl: './signin.component.html'
})
export class SignInComponent implements OnInit {
    
    loginForm: FormGroup;
    @ViewChild('userEmailInput') userEmailInput: ElementRef<HTMLInputElement>;
    
    constructor(
        private formBuilder: FormBuilder,
        private authService: AuthService,
        private router: Router,
        private platformDetectorService: PlatformDetectorService) { }

    ngOnInit(): void
    {
        this.loginForm = this.formBuilder.group({
            userEmail: ['', Validators.required],
            password: ['', Validators.required]
        });
    } 

    login() {
        const userEmail = this.loginForm.get('userEmail').value;
        const password = this.loginForm.get('password').value;

        this.authService
            .authenticate(userEmail, password)
            .subscribe(
                () => this.router.navigate(['transactions']),
                err => this.loginError(err));
    }
    
    loginError (error: string)
    {
        console.log(error);
        this.loginForm.reset();
        this.platformDetectorService.isPlatformBrowser() && 
            this.userEmailInput.nativeElement.focus();
        alert('Invalid user name or password');
    }
}