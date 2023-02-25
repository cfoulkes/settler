import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-image-or-text',
  templateUrl: './image-or-text.component.html',
  styleUrls: ['./image-or-text.component.scss']
})
export class ImageOrTextComponent {

  @Input()
  imageUrl?: string;

  @Input()
  text?: string;
  ;

  @Input()
  backgroundColour?: string;

  @Input()
  width: number = 0;

  constructor() { }

  imageLoadError() {
    this.imageUrl = undefined;
  }
}
