import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EletromagnetismoComponent } from './eletromagnetismo.component';

describe('EletromagnetismoComponent', () => {
  let component: EletromagnetismoComponent;
  let fixture: ComponentFixture<EletromagnetismoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EletromagnetismoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EletromagnetismoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
