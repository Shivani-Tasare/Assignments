import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IClients } from './models/Clients';

const httpheader = 
{
  headers:new HttpHeaders({'Content-Type':"application/json"})
}

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  private hosturl = "https://localhost:44380/"; 
  constructor(private http : HttpClient) { }

  onSearch(clients:IClients): Observable<IClients[]>
  {
    let url = `${this.hosturl}enterName/`;
  
    if(clients.first_name != undefined){
      url = `${url}${clients.first_name}/`;
    }
    if(clients.last_name != undefined){

      url = `${url}${clients.last_name}`;
    }
    console.log(url);
    return this.http.get<IClients[]>(url,httpheader);
  }
}
 