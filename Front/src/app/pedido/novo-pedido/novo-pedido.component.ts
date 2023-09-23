import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Cliente } from 'src/models/cliente';
import { Produto } from 'src/models/produto';
import { ProdutosDoCarrinho } from 'src/models/produtos-do-carrinho';
import { NovoPedido } from 'src/models/novo-pedido';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-novo-pedido',
  templateUrl: './novo-pedido.component.html',
  styleUrls: ['./novo-pedido.component.scss'],
})
export class NovoPedidoComponent implements OnInit {
  clientes: Cliente[] = [];
  produtos: Produto[] = [];
  produtoSelecionado: Produto = {};

  pedido: NovoPedido = {
    produtosDoCarrinho: [],
  };

  constructor(private http: HttpClient, private toastr: ToastrService) {}

  ngOnInit(): void {
    this.obterClientes();
    this.obterProdutos();
  }

  adicionarProdutoAoCarrinho() {
    this.pedido.produtosDoCarrinho.push(
      new ProdutosDoCarrinho(this.produtoSelecionado, 1)
    );

    this.obterPrecoFrete();
  }

  getValorTotalDoCarrinho(): number {
    let valorTotal = 0;

    this.pedido.produtosDoCarrinho.forEach((produto) => {
      valorTotal += this.calcularValorTotal(produto);
    });

    return valorTotal;
  }

  calcularValorTotal(produtosDoCarrinho: ProdutosDoCarrinho): number {
    const precoUnitario = produtosDoCarrinho?.produto?.precoUnitario;
    const quantidade = produtosDoCarrinho?.quantidade;

    if (precoUnitario !== undefined && quantidade !== undefined) {
      return precoUnitario * quantidade;
    }

    return 0;
  }

  finalizarPedido() {
    const url = 'https://localhost:7042/api/pedido';

    this.http.post<any[]>(url, this.pedido).subscribe(
      (response) => {
        this.toastr.success('Pedido finalizado com sucesso!');
      },
      (error) => {
        this.toastr.error(error.error, 'Pedido');
      }
    );
  }

  limparCarrinho() {
    this.pedido.produtosDoCarrinho = [];
    this.pedido.valorFrete = 0;
  }

  obterPrecoFrete() {
    var qtdItens = 0;

    this.pedido.produtosDoCarrinho.forEach((produto) => {
      qtdItens += produto.quantidade;
    });

    const url = `https://localhost:7128/api/frete/calcular/qtd-itens/${qtdItens}`;

    this.http.get<number>(url).subscribe(
      (response) => {
        this.pedido.valorFrete = response;
      },
      (error) => {
        this.toastr.error(error.error, 'Frete');
      }
    );
  }

  obterClientes() {
    const url = 'https://localhost:7042/api/cliente';

    this.http.get<any[]>(url).subscribe(
      (response) => {
        this.clientes = response;
      },
      (error) => {
        this.toastr.error(error.error, 'Cliente');
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
        this.toastr.error(error.error, 'Produto');
      }
    );
  }
}
