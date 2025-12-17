import { Routes } from '@angular/router';
import { MyPageComponent } from './pages/my-page/my-page.component';

export const routes: Routes = [
  // Make the new page the root route so http://localhost/ goes there
  { path: '', component: MyPageComponent },
  // also keep a named path in case you want to navigate explicitly
  { path: 'my-page', component: MyPageComponent },
];
