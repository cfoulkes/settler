import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class LookupService {

  constructor(private httpClient: HttpClient) { }

  getLookups(table: string): Observable<any[]> {
    const url = `api/lookup`;

    return this.httpClient.get<any[]>(`${url}/${table}/en`)
      .pipe(
        map(res => {
          console.log(res)
          return this.processGetLookups(res);
        })
      );
  }

  processGetLookups(res: any): any[] {
    console.log(`processGetLookups ${JSON.stringify(res)}`);
    return res;
  }


}
