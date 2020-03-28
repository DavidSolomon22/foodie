import { RecipiesPageComponent } from './repicies/recipies-page/recipies-page.component';
import { RegisterComponent } from './register/register.component';
import { HomePaageComponent } from './home-page/home-paage/home-paage.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { AddRecipieComponent } from './repicies/recipies-page/addRecipie/addRecipie.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { AuthGuard } from './shared/guard';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/home',
    pathMatch: 'full'
  },
  {
    path: 'home',
    component: HomePaageComponent
  },
  {
    path: 'register',
    component: RegisterComponent
  },
  {
    path: 'recipies',
    component: RecipiesPageComponent
  },
  {
    path: 'addRecipie',
    component: AddRecipieComponent
  },
  {
    path: 'userProfile',
    component: UserProfileComponent,
    canActivate: [AuthGuard]
  },
  {
    path: '**',
    component: HomePaageComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
