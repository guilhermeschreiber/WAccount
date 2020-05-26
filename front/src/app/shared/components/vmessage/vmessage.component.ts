import { Component, Input } from '@angular/core';

@Component({
    selector: 'wa-vmessage',
    templateUrl: './vmessage.component.html'
})
export class VMessageComponent {

    @Input() text = '';
 }