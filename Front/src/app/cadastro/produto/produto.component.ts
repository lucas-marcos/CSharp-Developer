import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Produto } from 'src/models/produto';

@Component({
  selector: 'app-produto',
  templateUrl: './produto.component.html',
  styleUrls: ['./produto.component.scss'],
})
export class ProdutoComponent implements OnInit {
  produtos: Produto[] = [];

  constructor(private http: HttpClient, private toastr: ToastrService) {}

  ngOnInit() {
    this.buscarProdutos();
  }

  buscarProdutos() {
    this.http
      .get<any[]>('https://localhost:7042/api/produto')
      .subscribe((response) => {
        this.produtos = response;
      },
      error => this.toastr.error(error.error, 'Listar Produtos'));
  }
}
