import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PropertyComponent} from './property/property.component';
import { PropertyDbComponent } from './property-db/property-db.component';

const routes: Routes = [
  { path: 'property', component:PropertyComponent},
  { path: 'property-db', component:PropertyDbComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
