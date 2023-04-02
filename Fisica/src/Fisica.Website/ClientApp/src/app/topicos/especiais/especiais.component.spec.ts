import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EspeciaisComponent } from './especiais.component';

describe('EspeciaisComponent', () => {
  let component: EspeciaisComponent;
  let fixture: ComponentFixture<EspeciaisComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EspeciaisComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EspeciaisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
