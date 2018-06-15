import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GreenFieldsComponent } from './green-fields.component';

describe('GreenFieldsComponent', () => {
  let component: GreenFieldsComponent;
  let fixture: ComponentFixture<GreenFieldsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GreenFieldsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GreenFieldsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
