import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MenuItem } from '../menu-item';

@Component({
    selector: 'app-menu-item',
    templateUrl: './menu-item.component.html',
    styleUrls: ['./menu-item.component.scss']
})
export class MenuItemComponent {

    @Input()
    menuItem!: MenuItem;

    @Output()
    click: EventEmitter<any> = new EventEmitter<any>();


    onClicked() {
        this.click.emit();
    }

}
