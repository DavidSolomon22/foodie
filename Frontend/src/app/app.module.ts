import { UserProfileComponent } from './user-profile/user-profile.component';
import { AddRecipieComponent } from './repicies/recipies-page/addRecipie/addRecipie.component';
import { RecipiesPageComponent } from './repicies/recipies-page/recipies-page.component';
import { HomePaageComponent } from './home-page/home-paage/home-paage.component';
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
import { RegisterComponent } from './register/register.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';
import { AuthInterceptor } from './shared/authconfig.interceptor';
import { MatToolbarModule } from '@angular/material/toolbar';

export function tokenGetter() {
  return localStorage.getItem('access_token');
}
@NgModule({
  declarations: [
    AppComponent,
    HomePaageComponent,
    RegisterComponent,
    RecipiesPageComponent,
    UserProfileComponent
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
    ReactiveFormsModule,
    HttpClientModule,
    MatToolbarModule,
    JwtModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
