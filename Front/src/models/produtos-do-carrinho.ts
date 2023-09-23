import { Produto } from "./produto";

export class ProdutosDoCarrinho {
  produto: Produto = {};
  quantidade: number = 1;

  constructor(produto: Produto, quantidade: number) {
    this.produto = produto;
    this.quantidade = quantidade;
  }
}
