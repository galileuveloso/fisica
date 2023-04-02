import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OndulatoriaComponent } from './ondulatoria.component';

describe('OndulatoriaComponent', () => {
  let component: OndulatoriaComponent;
  let fixture: ComponentFixture<OndulatoriaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OndulatoriaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OndulatoriaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
