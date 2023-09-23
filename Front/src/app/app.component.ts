import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'MaximaTech.Spa';

  exibirHeader: boolean = true;

  constructor(private router: Router) {
    this.router.events.subscribe(() => {
      this.exibirHeader = !this.router.url.includes('/login');
    });
  }
}
