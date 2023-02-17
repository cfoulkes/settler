import { BreakpointObserver } from '@angular/cdk/layout';
import { Component, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';

@Component({
    selector: 'app-shell',
    templateUrl: './shell.component.html',
    styleUrls: ['./shell.component.scss']
})
export class ShellComponent {

    @ViewChild(MatSidenav)
    sidenav!: MatSidenav;

    /**
     *
     */
    constructor(private observer: BreakpointObserver) { }

    ngAfterViewInit(): void {
        this.observer.observe(['(max-width: 800px)']).subscribe(res => {
            if (res.matches) {
                this.sidenav.mode = 'over';
                this.sidenav.close();
            } else {
                this.sidenav.mode = 'side';
                this.sidenav.open();
            }
        });
    }
}
