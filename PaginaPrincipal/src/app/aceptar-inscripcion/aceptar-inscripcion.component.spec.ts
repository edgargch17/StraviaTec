import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AceptarInscripcionComponent } from './aceptar-inscripcion.component';

describe('AceptarInscripcionComponent', () => {
  let component: AceptarInscripcionComponent;
  let fixture: ComponentFixture<AceptarInscripcionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AceptarInscripcionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AceptarInscripcionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
