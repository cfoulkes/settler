import { LookupService } from '../../clients/services/lookup.service';
import { AgencyService } from './../../clients/services/agency.service';
import { Component, OnInit } from '@angular/core';
import { Agency } from 'src/app/clients/models/agency';
import { Router } from '@angular/router';

@Component({
    selector: 'app-agency-list',
    templateUrl: './agency-list.component.html',
    styleUrls: ['./agency-list.component.scss'],
})
export class AgencyListComponent implements OnInit {

    agencies: Agency[] = [];
    agencyStatuses: any[] = [];
    displayedColumns: string[] = ['id']

    constructor(private router: Router, private agencyService: AgencyService, private lookupService: LookupService) { }

    ngOnInit(): void {
        this.agencyService.getAllAgencies().subscribe((agencies) => {
            this.agencies = agencies;
        })

        this.lookupService.getLookups('AgencyStatus').subscribe((lookups) => {
            this.agencyStatuses = lookups;
        })

    }

    handleAddButtonClick() {
        this.router.navigate(['/agencies/0']);
    }

}
