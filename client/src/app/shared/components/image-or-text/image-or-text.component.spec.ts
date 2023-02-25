import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImageOrTextComponent } from './image-or-text.component';

describe('ImageOrTextComponent', () => {
  let component: ImageOrTextComponent;
  let fixture: ComponentFixture<ImageOrTextComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ImageOrTextComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ImageOrTextComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
