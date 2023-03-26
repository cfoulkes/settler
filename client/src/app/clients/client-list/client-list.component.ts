import { ClientService } from './../services/client.service';
import { Component, OnInit } from '@angular/core';
import { Client } from '../models/client';

@Component({
  selector: 'app-client-list',
  templateUrl: './client-list.component.html',
  styleUrls: ['./client-list.component.scss']
})
export class ClientListComponent implements OnInit {

  clients: Client[] = [];
  displayedColumns: string[] = ['id']

  constructor(private clientService: ClientService) { }



  ngOnInit(): void {
    this.clientService.getAllClients().subscribe((clients) => {
      this.clients = clients;
    })
  }

}
