import { Component, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';

import {
  FormGroup,
  ValidationErrors,
  FormBuilder,
} from '@angular/forms';
import { Global } from '../Global';

export function atLeastOne(fields: string[]) {
  return (fg: FormGroup): ValidationErrors | null => {
    return fields.some(fieldName => {
      const field = fg.get(fieldName).value;
      if (typeof field === 'number') return field && field >= 0 ? true : false;
      if (typeof field === 'string') return field && field.length > 0 ? true : false;
    })
      ? null
      : ({ atLeastOne: 'At least one field has to be provided.' } as ValidationErrors);
  };
}

@Component({
  selector: 'app-quote',
  templateUrl: './quote.component.html'
})
export class QuoteComponent {
  public quote: QuoteModel;
  public persons: PersonModel[];
  public searchForm: FormGroup
  public showErrorMsg: string = '';
  public insPersons: InsPersonModel[];

  constructor(private http: HttpClient, private route: ActivatedRoute,
    private formBuilder: FormBuilder) {
    this.searchForm = this.formBuilder.group({
      firstName: [''],
      lastName: [''],
    },
      { validator: atLeastOne(['firstName', 'lastName']) },
    );

    http.get<QuoteModel>(Global.baseUrl + 'api/quote/' + this.route.snapshot.params.quno).subscribe(result => {
      this.quote = result;
      this.getInsPerson();
    }, error => console.error(error));
  }

  


  searchPerson() {
    this.showErrorMsg = '';
    if (this.searchForm.controls.firstName.value !== '' || this.searchForm.controls.lastName.value !== '') {
      this.http.get<PersonModel[]>(Global.baseUrl + 'api/person/' + (this.searchForm.controls.firstName.value !=='' ? this.searchForm.controls.firstName.value:' ') + '/' + this.searchForm.controls.lastName.value).subscribe(result => {
        this.persons = result;
        if (this.persons.length === 0) {
          this.showErrorMsg = "Results not found!!!";
        } else {
          this.removeExistsPersons();
          if (this.persons.length === 0) {
            this.showErrorMsg = "Results not found!!!";
          }
        }
      }, error => console.error(error));
    }
    else {
      this.showErrorMsg = "Enter First Name Or Last Name for search";
    }
   
  }

  addInsPerson(psId) {
    this.http.post(Global.baseUrl + 'api/InsPerson', { "quoteNo": this.quote.quoteNumber, "personId": psId }).subscribe(result => {
      console.log(result);
      this.getInsPerson();
    }, error => console.error(error));
  }

  getInsPerson() {
    this.http.get<InsPersonModel[]>(Global.baseUrl + 'api/InsPerson/' + this.quote.quoteNumber).subscribe(data => {
      this.insPersons = data;
      console.log(this.insPersons);
      this.removeExistsPersons();
    }, error => console.error(error));
  }

  removeExistsPersons() {

    var idsToDelete = this.insPersons.map(function (elt) { return elt.person.personId; });
    var result = this.persons.filter(function (elt) { return idsToDelete.indexOf(elt.personId) === -1; });
    console.log(result);

    this.persons = result;
  }

  deleteInsPerson(insPsnId) {
    this.http.delete(Global.baseUrl + 'api/InsPerson/' + insPsnId).subscribe(data => {
      console.log(data);
      this.getInsPerson();
    }, error => console.error(error));
  }

}

