import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GPSComponent } from './gps.component';

describe('GPSComponent', () => {
  let component: GPSComponent;
  let fixture: ComponentFixture<GPSComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GPSComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GPSComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
