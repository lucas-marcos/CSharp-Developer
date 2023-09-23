import { Cliente } from './cliente';
import { ProdutosDoCarrinho } from "./produtos-do-carrinho";

export class NovoPedido {
  id?: number;
  clienteId?: number;
  cliente?: Cliente = {};
  produtosDoCarrinho: ProdutosDoCarrinho[] = [];
  valorFrete?: number = 0;
  valorTotal?: number = 0;
  qtdItens?: number = 0;

  constructor() {
  this.produtosDoCarrinho = [];
  }
}
