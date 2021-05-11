import { Component } from '@angular/core';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

@Injectable({
  providedIn: 'root'
})
export class AppComponent {
  title = 'Frontend';

  httpString: string = "http://kong-proxy/test/api/test"

  constructor(public http: HttpClient) {

    


  }


  TestHttpCall(httpString: string) { 
    return this.http.get<string[]>(httpString);
  }


  async MakeHTTPCall() {
    console.log("Make http call with: " + this.httpString);

    try {

      // Get the DNS servers per Eric Gagnon's suggestion.
      // const dns = require('dns');
      // console.log(dns.getServers());

      let promise = new Promise((resolve, reject) => {
        this.TestHttpCall(this.httpString).subscribe(data => resolve(data), error => reject(error))
      });
      let result = await promise;
      alert("Connection to http SUCCESFUL: " + result);
    }
    catch (error) {
      alert("Connection to http FAILED: " + error.message + ", Status: " + error.status + ",  OK: " + error.ok);
    }
    finally {}
  }
}
