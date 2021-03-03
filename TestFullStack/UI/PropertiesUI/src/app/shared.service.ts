import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl ="https://localhost:5001";
  
  constructor(private http:HttpClient) { }

  getPropertyList():Observable<any[]> {
    return this.http.get<any>(this.APIUrl + "/property");
  }

  getPropertyListDB():Observable<any[]> {
    return this.http.get<any>(this.APIUrl + "/propertyDB");
  }

  addProperty(val:any) {
    return this.http.post(this.APIUrl + "/propertyDB", val);
  }

  deleteProperty(val:any) {
    return this.http.delete(this.APIUrl + "/propertyDB/" + val);
  }
}
