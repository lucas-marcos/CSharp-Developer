import { ProdutosDoCarrinho } from "./produtos-do-carrinho";

export class NovoPedido {
  clienteId?: number;
  produtosDoCarrinho: ProdutosDoCarrinho[] = [];
  valorFrete?: number = 0;

  constructor() {
  this.produtosDoCarrinho = [];
  }
}
