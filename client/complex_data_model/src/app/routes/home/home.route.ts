import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { GivenName, LookupEntityService } from 'core';
import { GenericAddUpdateDialog } from 'core';
import { Name1 } from 'client/core/models/given-name';

@Component({
  selector: 'home-route',
  templateUrl: 'home.route.html',
  providers: [LookupEntityService]
})
export class HomeRoute {
  constructor(
    private dialog: MatDialog,
    private entityApi: LookupEntityService<GivenName>
  ) {
    this.entityApi.setController('name');
    this.entityApi.setEntityType('GivenName');
   }

  open = () => this.dialog.open(GenericAddUpdateDialog, {
    data: {
      entity: {
        name: 'Given Name',
        self: Name1
      },
      api: this.entityApi
    },
    disableClose: true,
    autoFocus: false,
    width: '400px'
  })
}
