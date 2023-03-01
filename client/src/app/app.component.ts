import { DOCUMENT } from '@angular/common';
import { Component, HostBinding, Inject, OnInit, Renderer2 } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { TranslateService } from '@ngx-translate/core';
import { AuthenticationService } from './shared/auth/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Settler';

  private currentTheme = 'theme-light';

  get isDarkMode(): boolean {
    return this.currentTheme === 'theme-dark';
  }

  constructor(
    @Inject(DOCUMENT) private document: Document,
    private renderer: Renderer2,
    private titleService: Title,
    private authService: AuthenticationService,
    private translate: TranslateService
  ) {
    translate.setDefaultLang('en');

    // the lang to use, if the lang isn't available, it will use the current loader to get them
    translate.use('fr');

  }

  ngOnInit(): void {
    this.titleService.setTitle(this.title);
    this.currentTheme = localStorage.getItem('activeTheme') || 'theme-light';
    this.renderer.setAttribute(this.document.body, 'class', this.currentTheme);
  }

  darkModeChanged(isDarkMode: boolean) {
    this.currentTheme = isDarkMode ? 'theme-dark' : 'theme-light';
    this.renderer.setAttribute(this.document.body, 'class', this.currentTheme);
    localStorage.setItem('activeTheme', this.currentTheme);
  }
}
