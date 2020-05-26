import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
//import { InterceptorModule } from 'src/app/core/interceptor/interceptor.module';

@NgModule({
    imports: [
        CommonModule,
        HttpClientModule,
        //InterceptorModule
    ]
})
export class TransactionModule { }