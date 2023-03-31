import { AgencyService } from './../../clients/services/agency.service';
import { Component, OnInit } from '@angular/core';
import { Agency } from 'src/app/clients/models/agency';

@Component({
    selector: 'app-agency-list',
    templateUrl: './agency-list.component.html',
    styleUrls: ['./agency-list.component.scss'],
})
export class AgencyListComponent implements OnInit {

    agencies: Agency[] = [];

    constructor(private agencyService: AgencyService) { }

    ngOnInit(): void {
        this.agencyService.getAllAgencies().subscribe((agencies) => {
            this.agencies = agencies;
        })

    }

}
