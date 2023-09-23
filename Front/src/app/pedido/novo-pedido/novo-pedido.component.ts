import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Cliente } from 'src/models/cliente';
import { Produto } from 'src/models/produto';

@Component({
  selector: 'app-novo-pedido',
  templateUrl: './novo-pedido.component.html',
  styleUrls: ['./novo-pedido.component.scss'],
})
export class NovoPedidoComponent implements OnInit {
  clientes: Cliente[] = [];
  clienteSelecionado: Cliente = {};
  produtos: Produto[] = [];
  produtoSelecionado: Produto = {};

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.obterClientes();
    this.obterProdutos();
  }

  obterClientes() {
    const url = 'https://localhost:7042/api/cliente';

    this.http.get<any[]>(url).subscribe(
      (response) => {
        this.clientes = response;
      },
      (error) => {
        console.error('Erro ao obter a lista de clientes:', error);
      }
    );
  }

  obterProdutos() {
    const url = 'https://localhost:7042/api/produto';

    this.http.get<any[]>(url).subscribe(
      (response) => {
        this.produtos = response;
      },
      (error) => {
        console.error('Erro ao obter a lista de produtos:', error);
      }
    );
  }
}
