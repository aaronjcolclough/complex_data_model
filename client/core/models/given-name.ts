import { LookupEntity } from "./lookup-table-model";

export interface GivenName extends LookupEntity { }

export const Name1: GivenName = {
  id: 14,
  value: 'Thomas'
}
