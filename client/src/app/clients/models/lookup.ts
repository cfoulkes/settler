export class Lookup {
	id: number;
	description: string;

	constructor(
		obj?: any
	) {
		this.id = obj.id;
		this.description = obj.firstName;
	}
}
