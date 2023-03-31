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
    displayedColumns: string[] = ['id']

    constructor(private router: Router, private agencyService: AgencyService) { }

    ngOnInit(): void {
        this.agencyService.getAllAgencies().subscribe((agencies) => {
            this.agencies = agencies;
        })

    }

    handleAddButtonClick() {
        this.router.navigate(['/agencies/0']);
    }

}
