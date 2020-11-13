import { TestBed } from '@angular/core/testing';

import { CrearCuentaFormService } from './crear-cuenta-form.service';

describe('CrearCuentaFormService', () => {
  let service: CrearCuentaFormService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CrearCuentaFormService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
