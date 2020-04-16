import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NumbersAndBatchesComponent } from './numbers-and-batches/numbers-and-batches.component';
import { NumbersAndBatchesGridComponent } from './numbers-and-batches/numbers-and-batches-grid/numbers-and-batches-grid.component';
import { NumbersAndBatchesInputsComponent } from './numbers-and-batches/numbers-and-batches-inputs/numbers-and-batches-inputs.component';
import { ToastrModule } from 'ngx-toastr';
import { HttpClientModule } from '@angular/common/http';
import { NumbersAndBatchesService } from './shared/numbers-and-batches.service';

@NgModule({
  declarations: [
    AppComponent,
    NumbersAndBatchesComponent,
    NumbersAndBatchesGridComponent,
    NumbersAndBatchesInputsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ToastrModule.forRoot()
  ],
  providers: [NumbersAndBatchesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
