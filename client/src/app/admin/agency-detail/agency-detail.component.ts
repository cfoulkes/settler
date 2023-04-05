import { Agency } from './../../clients/models/agency';
import { AgencyService } from './../../clients/services/agency.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { LookupService } from 'src/app/clients/services/lookup.service';
import { Lookup } from 'src/app/clients/models/lookup';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-agency-detail',
    templateUrl: './agency-detail.component.html',
    styleUrls: ['./agency-detail.component.scss'],
})
export class AgencyDetailComponent implements OnInit {

    agencyId?: number;
    agency: Agency = new Agency({ agencyStatus: 1 });

    theForm = new FormGroup({
        name: new FormControl(''),
    });

    agencyStatuses: Lookup[] = [];

    constructor(private route: ActivatedRoute, private agencyService: AgencyService, private lookupService: LookupService) { }

    ngOnInit() {
        this.lookupService.getLookups('AgencyStatus').subscribe((lookups) => {
            this.agencyStatuses = lookups;
        })

        this.agencyId = this.route.snapshot.params['id'];
        if (this.agencyId) {
            this.loadData();
        }
        console.log(`id ${this.agencyId}`)
    }

    loadData() {
        this.agencyService.getAgency(this.agencyId!).subscribe(res => {

        });

    }

    saveClicked() {
        console.log(this.theForm.value)
        const agency = new Agency(this.theForm.value);
        agency.agencyStatusId = 1; //TODO for now
        this.agencyService.addAgency(agency).subscribe(() => {
            console.log(`saved`)
        })
    }

}
