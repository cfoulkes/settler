import { ClientService } from './../services/client.service';
import { Component, OnInit } from '@angular/core';
import { Client } from '../models/client';
import { Router } from '@angular/router';

@Component({
  selector: 'app-client-list',
  templateUrl: './client-list.component.html',
  styleUrls: ['./client-list.component.scss']
})
export class ClientListComponent implements OnInit {

  clients: Client[] = [];
  displayedColumns: string[] = ['id']

  constructor(private router: Router, private clientService: ClientService) { }



  ngOnInit(): void {
    this.clientService.getAllClients().subscribe((clients) => {
      this.clients = clients;
    })
  }

  handleAddButtonClick() {
    this.router.navigate(['/clients/0']);
  }
}
