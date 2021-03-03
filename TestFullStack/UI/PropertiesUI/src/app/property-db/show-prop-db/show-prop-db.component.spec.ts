import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowPropDbComponent } from './show-prop-db.component';

describe('ShowPropDbComponent', () => {
  let component: ShowPropDbComponent;
  let fixture: ComponentFixture<ShowPropDbComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowPropDbComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowPropDbComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
