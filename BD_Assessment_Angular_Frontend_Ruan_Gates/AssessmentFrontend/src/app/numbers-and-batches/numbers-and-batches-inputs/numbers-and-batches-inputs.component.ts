import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { NumbersAndBatchesService } from './../../shared/numbers-and-batches.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-numbers-and-batches-inputs',
  templateUrl: './numbers-and-batches-inputs.component.html',
  styles: [
  ]
})
export class NumbersAndBatchesInputsComponent implements OnInit {

  constructor(public service: NumbersAndBatchesService,private toastr: ToastrService) { }

  ngOnInit(): void {
    // alert("initinputs");
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.form.reset();
    this.service.formData = {
      RequestId: 0,
      Batches: '',
      Numbers: '',
      
    }
  }  

  onSubmit(form: NgForm) {
    // console.log(form);

    if (this.service.formData.RequestId == 0)
      this.insertRecord(form);

    // else
    //   this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.postNumbersAndBatches().subscribe(
      res => {
        debugger;
        this.resetForm(form);
        this.toastr.success('Submitted successfully', 'Numbers and Batches Submission');
        this.service.refreshList();
      },
      err => {
        debugger;
        console.log(err);
      }
    )
  }
  
  // updateRecord(form: NgForm) {
  //   this.service.putNumbersAndBatches().subscribe(
  //     res => {
  //       this.resetForm(form);
  //       this.toastr.info('Submitted successfully', 'Numbers and Batches Submission');
  //       this.service.refreshList();
  //     },
  //     err => {
  //       console.log(err);
  //     }
  //   )
  // }

}