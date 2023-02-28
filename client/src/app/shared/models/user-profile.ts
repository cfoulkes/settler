export class UserProfile {

  public id: number;
  public firstName: string;
  public lastName: string;
  public imageUrl: string;
  public language: string;
  public rowVer: number;

  constructor(obj?: any) {
    this.id = obj.id;
    this.firstName = obj.firstName;
    this.lastName = obj.lastName;
    this.imageUrl = obj.imageUrl;
    this.language = obj.language;
    this.rowVer = obj.rowVer;
  }

  get fullName() {
    return `${this.firstName} ${this.lastName}`;
  }
  get initials() {
    return `${this.firstName[0]}${this.lastName[0]}`;
  }

}
