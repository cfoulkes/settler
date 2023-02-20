import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Client } from '../models/client';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  constructor(private httpClient: HttpClient) { }

  getAllClients(): Observable<Client[]> {
    const url = `api/clients`;

    return this.httpClient.get<Client[]>(url)
      .pipe(
        map(res => {
          return this.processGetClientsResult(res);
        })
      );
  }

  processGetClientsResult(res: any): Client[] {
    console.log(`processGetClientsResult ${JSON.stringify(res)}`);
    const clients = [];

    for (const item of res) {
      const client = new Client(item);
      clients.push(client);
    }

    return clients;
  }
}
