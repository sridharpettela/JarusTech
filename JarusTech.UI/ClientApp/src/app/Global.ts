import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class Global {
  static baseUrl: string = 'http://localhost:8811/';
}
