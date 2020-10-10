import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Global } from '../Global';

@Component({
  selector: 'app-quote-data',
  templateUrl: './quote-data.component.html'
})
export class QuoteDataComponent {
  public quotes: QuoteModel[];

  constructor(http: HttpClient, private router: Router) {
    http.get<QuoteModel[]>(Global.baseUrl + 'api/quote').subscribe(result => {
      this.quotes = result;
    }, error => console.error(error));
  }

}


