import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router'; // Importe o Router

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  usuario: string = '';
  senha: string = '';

  constructor(private router: Router, private http: HttpClient) {} // Injete o Router

  logar() {
    if (this.usuario === 'admin' && this.senha === 'admin') {
      this.setup();
      this.router.navigate(['/cadastro/produto']);
    }
  }

  setup() {
    this.http.get('https://localhost:7042/api/configuracao/setup').subscribe();
  }
}
