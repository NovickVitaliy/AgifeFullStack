import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

interface IResponseBody {
  age?: string
}

@Injectable({
  providedIn: 'root'
})
export class HttpRequestService {

  constructor(private httpClient: HttpClient) {
  }

  getResponse(name: string): Observable<IResponseBody> {
  return  this.httpClient.get<IResponseBody>(`http://192.168.1.8:5000/Age/Index/${name}`,)
  }
}
