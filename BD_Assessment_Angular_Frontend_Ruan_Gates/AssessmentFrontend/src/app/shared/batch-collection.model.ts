import { Batch } from './batch.model';
import { BatchAndNumberInput } from './batch-and-number-input.model';


export class BatchCollection {
    RequestId :number;
    GrandTotal: string;
    BatchAndNumberInput: BatchAndNumberInput;
    BatchElements: Batch[];
}

