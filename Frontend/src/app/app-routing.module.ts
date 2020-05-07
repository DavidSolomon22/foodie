import { RecipesPageComponent } from './recipes/Recipes-page/recipes-page.component';
import { RegisterComponent } from './register/register.component';
import { HomePageComponent } from './home-page/home-page.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { RecipeAddComponent } from './recipes/recipe-add/recipe-add.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { AuthGuard } from './shared/guard';
import { UserRecipesComponent } from './recipes/user-recipes/user-recipes.component';
import { RecipeEditComponent } from './recipes/recipe-edit/recipe-edit.component';
import { RecipePageComponent } from './recipes/recipe-page/recipe-page.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/home',
    pathMatch: 'full'
  },
  {
    path: 'home',
    component: HomePageComponent
  },
  {
    path: 'register',
    component: RegisterComponent
  },
  {
    path: 'recipes',
    component: RecipesPageComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'addRecipe',
    component: RecipeAddComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'myRecipes',
    component: UserRecipesComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'editRecipe/:id',
    component: RecipeEditComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'recipe/:id',
    component: RecipePageComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'userProfile',
    component: UserProfileComponent,
    canActivate: [AuthGuard]
  },
  {
    path: '**',
    component: HomePageComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
