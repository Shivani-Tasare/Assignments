import { Component, OnInit } from '@angular/core';
import { ClientService } from '../client.service';
import { IClients } from '../models/Clients';

@Component({
  selector: 'app-search-body',
  templateUrl: './search-body.component.html',
  styleUrls: ['./search-body.component.scss']
})
export class SearchBodyComponent implements OnInit {

  clients = new IClients();
  SearchResults=[];

  constructor(private _clientService : ClientService) { }

  ngOnInit() {
    
  }
onSearch( ) {
    this._clientService.onSearch(this.clients)
    .subscribe( response => {
      this.SearchResults = response;
    })
  }
}
