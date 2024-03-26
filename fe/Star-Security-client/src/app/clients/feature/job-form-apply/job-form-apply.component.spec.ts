import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JobFormApplyComponent } from './job-form-apply.component';

describe('JobFormApplyComponent', () => {
  let component: JobFormApplyComponent;
  let fixture: ComponentFixture<JobFormApplyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [JobFormApplyComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(JobFormApplyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
