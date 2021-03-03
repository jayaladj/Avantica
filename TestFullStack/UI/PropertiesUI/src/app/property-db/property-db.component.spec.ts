import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PropertyDbComponent } from './property-db.component';

describe('PropertyDbComponent', () => {
  let component: PropertyDbComponent;
  let fixture: ComponentFixture<PropertyDbComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PropertyDbComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PropertyDbComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
