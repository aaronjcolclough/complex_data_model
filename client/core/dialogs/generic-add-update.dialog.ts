import {
  MatDialogRef,
  MAT_DIALOG_DATA
} from '@angular/material/dialog';

import {
  Component,
  Inject
} from '@angular/core';
import { LookupEntity } from '../models/lookup-table-model';
import { LookupEntityService } from '../apis';

@Component({
  selector: 'generic-add-update-dialog',
  templateUrl: 'generic-add-update.dialog.html'
})
export class GenericAddUpdateDialog<T extends LookupEntity> {
  constructor(
    private dialogRef: MatDialogRef<GenericAddUpdateDialog<T>>,
    @Inject(MAT_DIALOG_DATA) public data: {
      entity: { name: string, self: T },
      api: LookupEntityService<T>
    }
  ){}

  save = async () => {
    console.log(this.data.entity.self)
    const res = await this.data.api.save(this.data.entity.self);
      res && this.dialogRef.close();
  }
}
