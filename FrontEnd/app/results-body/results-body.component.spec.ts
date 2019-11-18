import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ResultsBodyComponent } from './results-body.component';

describe('ResultsBodyComponent', () => {
  let component: ResultsBodyComponent;
  let fixture: ComponentFixture<ResultsBodyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ResultsBodyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ResultsBodyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
