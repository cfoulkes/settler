import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
    selector: 'app-agency-detail',
    templateUrl: './agency-detail.component.html',
    styleUrls: ['./agency-detail.component.scss'],
})
export class AgencyDetailComponent {

    theForm = new FormGroup({
        name: new FormControl(''),
    });

    saveClicked() {

    }

}
