import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Agency } from '../models/agency';

@Injectable({
    providedIn: 'root'
})
export class AgencyService {

    constructor(private httpClient: HttpClient) { }

    getAllAgencies(): Observable<Agency[]> {
        const url = `api/agency`;

        return this.httpClient.get<Agency[]>(url)
            .pipe(
                map(res => {
                    const clients = [];

                    for (const item of res) {
                        const client = new Agency(item);
                        clients.push(client);
                    }

                    return clients;
                })
            );
    }

    getAgency(id: number): Observable<Agency> {
        const url = `api/agency/${id}`;

        return this.httpClient.get<Agency>(url)
            .pipe(
                map(res => {
                    console.log(res)
                    return new Agency(res);
                })
            );
    }



    addAgency(agency: any) {
        let url = `/api/agency`;

        return this.httpClient.post(url, agency).pipe(
            map(res => {
                return this.processAddAgencyResult(res);
            })
        );
    }

    processAddAgencyResult(res: any) {

    }

}
