export class Agency {
	id: number;
	name: string;
	rowVer: number;

	constructor(
		obj?: any
	) {
		this.id = obj.id;
		this.name = obj.name;
		this.rowVer = obj.rowVer;
	}
}
