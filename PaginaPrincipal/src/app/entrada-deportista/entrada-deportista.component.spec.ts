import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EntradaDeportistaComponent } from './entrada-deportista.component';

describe('EntradaDeportistaComponent', () => {
  let component: EntradaDeportistaComponent;
  let fixture: ComponentFixture<EntradaDeportistaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EntradaDeportistaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EntradaDeportistaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
