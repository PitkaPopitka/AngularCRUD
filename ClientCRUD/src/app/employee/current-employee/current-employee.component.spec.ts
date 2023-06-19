import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CurrentEmployeeComponent } from './current-employee.component';

describe('CurrentEmployeeComponent', () => {
  let component: CurrentEmployeeComponent;
  let fixture: ComponentFixture<CurrentEmployeeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CurrentEmployeeComponent]
    });
    fixture = TestBed.createComponent(CurrentEmployeeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
