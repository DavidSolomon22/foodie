import { Component, OnInit } from '@angular/core';
import { RegisterService } from '../services/register.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header-toolbar',
  templateUrl: './header-toolbar.component.html',
  styleUrls: ['./header-toolbar.component.scss']
})
export class HeaderToolbarComponent implements OnInit {

  constructor(private router: Router, private registerService: RegisterService) { }

  ngOnInit(): void {
  }

  logOut() {
    this.registerService.logOut();
    this.router.navigateByUrl('home');
  }

  get currentView() {
    return this.router.url;
  }
}
