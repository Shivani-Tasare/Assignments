import { Component, OnInit, Input } from '@angular/core';
import {ClientService} from './../client.service';
@Component({
  selector: 'app-results-body',
  templateUrl: './results-body.component.html',
  styleUrls: ['./results-body.component.scss']
})
export class ResultsBodyComponent implements OnInit {
 
  constructor(private _clientService :ClientService) { }

  @Input() SearchResults;
  ngOnInit() {
 
  }

}
