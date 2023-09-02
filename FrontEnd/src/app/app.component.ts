import { Component } from '@angular/core';
import {HttpRequestService} from "./services/http-request.service";
import {IHttpResponseBody} from "./services/IHttpResponseBody";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  response:IHttpResponseBody = {age:''};
  name:string = ''
  isMadeRequest:boolean = false

  constructor(private makeHttpReq:HttpRequestService) {
  }
  getResponse():void{
    this.makeHttpReq.getResponse(this.name).subscribe(response=>{
      this.response = response;
      this.isMadeRequest =!this.isMadeRequest;
    })
  }
}
