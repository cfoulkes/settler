export class Client {
  id: number;
  firstName: string;
  lastName: string;
  rowVer: number;

  constructor(
    id: number,
    firstName: string,
    lastName: string,
    rowVer: number,
  ) {
    this.id = id;
    this.firstName = firstName;
    this.lastName = lastName;
    this.rowVer = rowVer;
  }
}
