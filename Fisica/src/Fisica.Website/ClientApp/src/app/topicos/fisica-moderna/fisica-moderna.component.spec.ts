import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FisicaModernaComponent } from './fisica-moderna.component';

describe('FisicaModernaComponent', () => {
  let component: FisicaModernaComponent;
  let fixture: ComponentFixture<FisicaModernaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FisicaModernaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FisicaModernaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
