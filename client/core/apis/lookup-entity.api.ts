import {
  Injectable,
  Optional
} from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import { SnackerService } from '../services';
import { ServerConfig } from '../config';
import { LookupEntity } from '../models/lookup-table-model';

@Injectable()
export class LookupEntityService<T extends LookupEntity> {
  private controller: string;
  private entityType: string;

  private entitys = new BehaviorSubject<T[]>(null);
  entitys$ = this.entitys.asObservable();
  private entity = new BehaviorSubject<T>(null);
  entity$ = this.entity.asObservable();

  constructor(
    private http: HttpClient,
    private snacker: SnackerService,
    @Optional() private config: ServerConfig
  ) { }

  setController = (ctl: string) => this.controller = ctl;
  setEntityType = (et: string) => this.entityType = et;

  getMany = (ctl: string, endpoint: string) =>
    this.http.get<T[]>(`${this.config.api}${this.controller}/get${this.entityType}s`)
      .subscribe({
        next: data => this.entitys.next(data),
        error: err => this.snacker.sendErrorMessage(err.error)
      })

  get = (id: number) =>
    this.http.get<T>(`${this.config.api}${this.controller}/get${this.entityType}/${id}`)
      .subscribe({
        next: data => this.entity.next(data),
        error: err => this.snacker.sendErrorMessage(err.error)
      });


  save = (entity: T): Promise<boolean> => new Promise((resolve) => {
    this.http.post(`${this.config.api}${this.controller}/save${this.entityType}`, entity)
      .subscribe({
        next: () => {
          this.snacker.sendSuccessMessage(`${entity.value} successfully created`);
          resolve(true);
        },
        error: err => {
          this.snacker.sendErrorMessage(err.error);
          resolve(false);
        }
      });
  })

  remove = (entity: T): Promise<boolean> => new Promise((resolve) => {
    this.http.post(`${this.config.api}${this.controller}/remove${this.entityType}`, entity)
      .subscribe({
        next: () => {
          this.snacker.sendSuccessMessage(`${entity.value} successfully removed`);
          resolve(true);
        },
        error: err => {
          this.snacker.sendErrorMessage(err.error);
          resolve(false);
        }
      });
  })
}
