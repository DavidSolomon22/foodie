import { DietComponent } from './diet/diet/diet.component';
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
import { RecipesSearchComponent } from './recipes/recipes-search/recipes-search.component';
import { UserLikedRecipesComponent } from './recipes/user-liked-recipes/user-liked-recipes.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/home',
    pathMatch: 'full',
  },
  {
    path: 'home',
    component: HomePageComponent,
  },
  {
    path: 'register',
    component: RegisterComponent,
  },
  {
    path: 'recipes',
    component: RecipesPageComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'recipesSearch',
    component: RecipesSearchComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'addRecipe',
    component: RecipeAddComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'myRecipes',
    component: UserRecipesComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'favorite',
    component: UserLikedRecipesComponent,
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
    canActivate: [AuthGuard],
  },
  {
    path: 'diet',
    component: DietComponent,
    canActivate: [AuthGuard],
  },
  {
    path: '**',
    component: HomePageComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
