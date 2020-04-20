import { NumbersAndBatches } from './numbers-and-batches.model';
import { Numbers } from './number.model';
import { Batch } from './batch.model';
import { BatchCollection } from './batch-collection.model';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class NumbersAndBatchesService {

  formData: NumbersAndBatches;
  readonly rootURL = 'http://localhost:56493/api';
  numberslist: BatchCollection[];

  constructor(private http: HttpClient) { }

  postNumbersAndBatches() {
    // alert("POST");
    return this.http.post(this.rootURL + '/BatchAndNumberInputs', this.formData);
    
  }

  // putNumbersAndBatches() {
  //   return this.http.put(this.rootURL + '/NumbersAndBatches/'+ this.formData.PMId, this.formData);
  // }
  deleteNumbersAndBatches(id) {
    return this.http.delete(this.rootURL + '/NumbersAndBatches/'+ id);
  }

  refreshList(){
    // this.http.get(this.rootURL + '/NumberInBatches')
    // .toPromise()
    // .then(res => this.numberslist = res as Numbers[]);
    var elementsList: Batch[];
    
    this.http.get(this.rootURL + '/Batches/' + 2)
    .toPromise()
    .then(res => this.numberslist = res as BatchCollection[]);


console.log(this.numberslist);
    // this.http.get(this.rootURL + '/NumberInBatches')
    // .toPromise()
    // .then(res => this.numberslist = res as Numbers[]);
  }

  
}
