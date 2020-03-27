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

@NgModule({
   declarations: [
      AppComponent,
      HomePaageComponent,
      RegisterComponent
   ],
   imports: [
      BrowserModule,
      BrowserAnimationsModule,
      AppRoutingModule,
      MatCardModule,
      MatFormFieldModule,
      MatInputModule,
      MatIconModule,
      MatButtonModule
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule {}
