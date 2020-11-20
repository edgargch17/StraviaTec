import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReporteParticipantesCarreraComponent } from './reporte-participantes-carrera.component';

describe('ReporteParticipantesCarreraComponent', () => {
  let component: ReporteParticipantesCarreraComponent;
  let fixture: ComponentFixture<ReporteParticipantesCarreraComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReporteParticipantesCarreraComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReporteParticipantesCarreraComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
