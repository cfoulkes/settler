import { Component, EventEmitter, Output, OnInit } from '@angular/core';

@Component({
	selector: 'app-add-button',
	templateUrl: './add-button.component.html',
	styleUrls: ['./add-button.component.css'],
})
export class AddButtonComponent implements OnInit {

	@Output() clicked: EventEmitter<any> = new EventEmitter<any>();

	constructor(
	) { }

	ngOnInit() {
	}

	onClicked() {
		this.clicked.emit();
	}
}
