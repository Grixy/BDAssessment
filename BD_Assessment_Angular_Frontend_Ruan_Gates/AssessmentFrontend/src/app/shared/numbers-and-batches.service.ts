import { NumbersAndBatches } from './numbers-and-batches.model';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class NumbersAndBatchesService {

  formData: NumbersAndBatches;
  readonly rootURL = 'http://localhost:56493/api';
  list : NumbersAndBatches[];

  constructor(private http: HttpClient) { }

  postNumbersAndBatches() {
    // alert("POST");
    return this.http.post(this.rootURL + '/BatchAndNumberInputs', this.formData);
  }

  // putNumbersAndBatches() {
  //   return this.http.put(this.rootURL + '/NumbersAndBatches/'+ this.formData.PMId, this.formData);
  // }
  // deleteNumbersAndBatches(id) {
  //   return this.http.delete(this.rootURL + '/NumbersAndBatches/'+ id);
  // }

  refreshList(){
    this.http.get(this.rootURL + '/BatchAndNumberInputs')
    .toPromise()
    .then(res => this.list = res as NumbersAndBatches[]);
  }
}
