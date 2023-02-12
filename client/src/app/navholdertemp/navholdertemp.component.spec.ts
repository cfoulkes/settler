import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavholdertempComponent } from './navholdertemp.component';

describe('NavholdertempComponent', () => {
  let component: NavholdertempComponent;
  let fixture: ComponentFixture<NavholdertempComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NavholdertempComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NavholdertempComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
