import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContributionMainComponent } from './contribution-main.component';

describe('ContributionMainComponent', () => {
  let component: ContributionMainComponent;
  let fixture: ComponentFixture<ContributionMainComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ContributionMainComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ContributionMainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
