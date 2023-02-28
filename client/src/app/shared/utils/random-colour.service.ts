import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class RandomColourService {
  colours: string[] = [
    '#205d93',
    '#ffc0b2',
    '#7099de',
    '#ffc890',
    '#d1d4ff',
    '#4dc1ad',
    '#55c9ed',
    '#d065b1',
    '#2399b5',
    '#b685d4',
  ];

  getRandomColour(exclude: string[] = []) {
    let colour = this.randomColour;
    while (exclude.includes(colour)) {
      colour = this.randomColour;
    }
    return colour;
  }

  get randomColour() {
    return this.colours[Math.floor(Math.random() * 10)];
  }

  getColourForText(initials: string) {
    if (!initials) {
      return '';
    }
    var val = 0;
    for (var i = 0; i < initials.length; i++) {
      val += initials.charCodeAt(i);
    }
    return this.colours[val % 10];
  }
}
