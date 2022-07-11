import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayerStatementComponent } from './player-statement.component';

describe('PlayerStatementComponent', () => {
  let component: PlayerStatementComponent;
  let fixture: ComponentFixture<PlayerStatementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PlayerStatementComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PlayerStatementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
