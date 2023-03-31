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
                    console.log(res)
                    return this.processGetAgenciesResult(res);
                })
            );
    }

    processGetAgenciesResult(res: any): Agency[] {
        console.log(`processGetAgenciesResult ${JSON.stringify(res)}`);
        const clients = [];

        for (const item of res) {
            const client = new Agency(item);
            clients.push(client);
        }

        return clients;
    }
}
