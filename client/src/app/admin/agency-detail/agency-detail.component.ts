import { Agency } from './../../clients/models/agency';
import { AgencyService } from './../../clients/services/agency.service';
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

    constructor(private agencyService: AgencyService) { }

    saveClicked() {
        console.log(this.theForm.value)
        const agency = new Agency(this.theForm.value);
        agency.agencyStatusId = 1; //TODO for now
        this.agencyService.addAgency(agency).subscribe(() => {
            console.log(`saved`)
        })
    }

}
