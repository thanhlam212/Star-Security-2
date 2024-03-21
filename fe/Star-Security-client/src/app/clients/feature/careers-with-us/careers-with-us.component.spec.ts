import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CareersWithUsComponent } from './careers-with-us.component';

describe('CareersWithUsComponent', () => {
  let component: CareersWithUsComponent;
  let fixture: ComponentFixture<CareersWithUsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CareersWithUsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CareersWithUsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
