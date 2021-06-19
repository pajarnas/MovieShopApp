import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchasedMovieItemComponent } from './purchased-movie-item.component';

describe('PurchasedMovieItemComponent', () => {
  let component: PurchasedMovieItemComponent;
  let fixture: ComponentFixture<PurchasedMovieItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PurchasedMovieItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchasedMovieItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
