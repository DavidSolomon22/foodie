import { DietDialogComponent } from './diet/diet/diet-dialog/diet-dialog.component';
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
import { RegisterComponent } from './register/register.component';
import { ReactiveFormsModule } from '@angular/forms';
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
import { MatRadioModule } from '@angular/material/radio';
import { MatTooltipModule } from '@angular/material/tooltip';

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
    DietDialogComponent,
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
    MatRadioModule,
    MatTooltipModule,
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
