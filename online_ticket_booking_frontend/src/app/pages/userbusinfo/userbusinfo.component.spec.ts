import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserbusinfoComponent } from './userbusinfo.component';

describe('UserbusinfoComponent', () => {
  let component: UserbusinfoComponent;
  let fixture: ComponentFixture<UserbusinfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UserbusinfoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UserbusinfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
