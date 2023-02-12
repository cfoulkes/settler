import { DOCUMENT } from '@angular/common';
import { Component, Inject, Renderer2 } from '@angular/core';

@Component({
  selector: 'app-navholdertemp',
  templateUrl: './navholdertemp.component.html',
  styleUrls: ['./navholdertemp.component.scss']
})
export class NavholdertempComponent {
  private currentTheme = 'theme-light';

  get isDarkMode(): boolean {
    return this.currentTheme === 'theme-dark';
  }

  constructor(
    @Inject(DOCUMENT) private document: Document,
    private renderer: Renderer2
  ) { }

  ngOnInit(): void {
    this.currentTheme = localStorage.getItem('activeTheme') || 'theme-light';
    this.renderer.setAttribute(this.document.body, 'class', this.currentTheme);
  }

  darkModeChanged(isDarkMode: boolean) {
    this.currentTheme = isDarkMode ? 'theme-dark' : 'theme-light';
    this.renderer.setAttribute(this.document.body, 'class', this.currentTheme);
    localStorage.setItem('activeTheme', this.currentTheme);
  }
}
