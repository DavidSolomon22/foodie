import { DietCardComponent } from './diet/diet/diet-card/diet-card.component';
import { DietAddComponent } from './diet/diet/diet-add/diet-add.component';
import { DietComponent } from './diet/diet/diet.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { RecipeAddComponent } from './recipes/recipe-add/recipe-add.component';
import { RecipesPageComponent } from './recipes/Recipes-page/recipes-page.component';
import { HomePageComponent } from './home-page/home-page.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table'; 
import {MatDividerModule} from '@angular/material/divider';
import { RegisterComponent } from './register/register.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';
import { AuthInterceptor } from './shared/authconfig.interceptor';
import { RecipeCardComponent } from './recipes/recipe-card/recipe-card.component';
import { HeaderToolbarComponent } from './header-toolbar/header-toolbar.component';
import { WavesComponent } from './artistic/waves/waves.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatStepperModule } from '@angular/material/stepper';
import { MAT_STEPPER_GLOBAL_OPTIONS } from '@angular/cdk/stepper';
import { MatGridListModule } from '@angular/material/grid-list';
import { RecipePageComponent } from './recipes/recipe-page/recipe-page.component';
import { RecipeEditComponent } from './recipes/recipe-edit/recipe-edit.component';
import { UserRecipesComponent } from './recipes/user-recipes/user-recipes.component';
import { RecipeRateComponent } from './recipes/recipe-rate/recipe-rate.component';
import { RecipesSearchComponent } from './recipes/recipes-search/recipes-search.component';

export function tokenGetter() {
  return localStorage.getItem('access_token');
}
@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    RegisterComponent,
    RecipesPageComponent,
    UserProfileComponent,
    RecipeAddComponent,
    RecipeCardComponent,
    HeaderToolbarComponent,
    WavesComponent,
    DietComponent,
    DietAddComponent,
    DietCardComponent,
    RecipePageComponent,
    RecipeEditComponent,
    UserRecipesComponent,
    RecipeRateComponent,
    RecipesSearchComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatButtonModule,
    MatToolbarModule,
    MatSelectModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatToolbarModule,
    MatSnackBarModule,
    JwtModule,
    MatDialogModule,
    MatStepperModule,
    MatGridListModule,
    MatTableModule,
    JwtModule,
    MatDividerModule,
    FormsModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    },
    {
      provide: MAT_STEPPER_GLOBAL_OPTIONS,
      useValue: { displayDefaultIndicatorType: false },
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
