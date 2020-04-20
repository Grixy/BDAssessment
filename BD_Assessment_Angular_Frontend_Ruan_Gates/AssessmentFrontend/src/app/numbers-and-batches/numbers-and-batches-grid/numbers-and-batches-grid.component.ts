import { NumbersAndBatchesService } from './../../shared/numbers-and-batches.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-numbers-and-batches-grid',
  templateUrl: './numbers-and-batches-grid.component.html',
  styles: [
  ]
})
export class NumbersAndBatchesGridComponent implements OnInit {

  constructor(public service: NumbersAndBatchesService) { }

  ngOnInit() {
  }

  populateForm(selectedRecord) {
    this.service.formData = Object.assign({}, selectedRecord);
  }
  
  onDelete(PMId) {
    if (confirm('Are you sure to delete this record ?')) {
      this.service.deleteNumbersAndBatches(PMId)
        .subscribe(res => {
          this.service.refreshList();
        },
        err => { console.log(err); })
    }
  }
}
