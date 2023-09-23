import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Cliente } from 'src/models/cliente';
import { Produto } from 'src/models/produto';
import { ProdutosDoCarrinho } from 'src/models/produtos-do-carrinho';

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

  produtosDoCarrinho: ProdutosDoCarrinho[] = [];

  valorFrete: number = 0;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.obterClientes();
    this.obterProdutos();
  }

  adicionarProdutoAoCarrinho() {
    this.produtosDoCarrinho.push(
      new ProdutosDoCarrinho(this.produtoSelecionado, 1)
    );

    this.obterPrecoFrete();
  }

  getValorTotalDoCarrinho(): number {
    let valorTotal = 0;

    this.produtosDoCarrinho.forEach((produto) => {
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

  obterPrecoFrete() {
    var qtdItens = 0;

    this.produtosDoCarrinho.forEach(produto => {
      qtdItens += produto.quantidade;
    });

    const url = `https://localhost:7128/api/frete/calcular/qtd-itens/${qtdItens}`;

    this.http.get<number>(url).subscribe(
      (response) => {
        this.valorFrete = response;
      },
      (error) => {
        console.error('Erro ao obter o valor do frete:', error);
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
