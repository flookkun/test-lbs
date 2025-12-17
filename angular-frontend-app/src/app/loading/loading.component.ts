import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AsyncPipe } from '@angular/common';
import { LoadingService } from './loading.service';

@Component({
  selector: 'app-loading',
  standalone: true,
  imports: [CommonModule, AsyncPipe],
  template: `
    <div
      class="global-backdrop"
      *ngIf="loading.isLoading$ | async"
      role="status"
      aria-live="polite"
    >
      <div class="loading">
        <div class="spinner" aria-hidden="true"></div>
        <div class="loading-text">Loading...</div>
      </div>
    </div>
  `,
  styles: [
    `
      .global-backdrop {
        position: fixed;
        inset: 0;
        display: flex;
        align-items: center;
        justify-content: center;
        background: rgba(0, 0, 0, 0.45);
        z-index: 9999;
      }

      .loading {
        display: flex;
        flex-direction: column;
        align-items: center;
        gap: 0.5rem;
        color: #fff;
      }

      .spinner {
        width: 48px;
        height: 48px;
        border-radius: 50%;
        border: 5px solid rgba(255, 255, 255, 0.25);
        border-top-color: #fff;
        animation: spin 0.9s linear infinite;
      }

      .loading-text {
        font-size: 0.95rem;
      }

      @keyframes spin {
        to {
          transform: rotate(360deg);
        }
      }
    `,
  ],
})
export class LoadingComponent {
  constructor(public loading: LoadingService) {}
  ngOnInit() {}
}
