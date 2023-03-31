export class Client {
    id: number;
    firstName: string;
    lastName: string;
    rowVer: number;

    constructor(
        obj?: any
    ) {
        this.id = obj.id;
        this.firstName = obj.firstName;
        this.lastName = obj.lastName;
        this.rowVer = obj.rowVer;
    }
}
