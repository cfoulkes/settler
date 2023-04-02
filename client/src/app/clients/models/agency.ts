export class Agency {
  id: number;
  name: string;
  description: string;
  numberOfLicences: number;
  agencyStatusId: number;
  rowVer: number;

  constructor(
    obj?: any
  ) {
    this.id = obj.id;
    this.name = obj.name;
    this.description = obj.description;
    this.numberOfLicences = obj.numberOfLicences;
    this.agencyStatusId = obj.agencyStatusId;
    this.rowVer = obj.rowVer;
  }
}
