const url = "pedido/novo";

const selectCliente = ":nth-child(2) > .mt-4 > .form-select";
const selectProduto = ":nth-child(3) > .mt-4 > .form-select";
const inputQuantidade = " #quantidade";
const precoUnitarioPorProduto = " #precoUnitarioPorProduto";
const precoFinalPorProduto = " #precoFinalPorProduto";
const precoItensTotal = ':nth-child(1) > .ml-auto';

const finalizarPedidoButton = '.btn-success';

export default class NovoPedidoPage {
  irParaUrl() {
    cy.visit(url);
  }

  selecionarCliente(cliente) {
    cy.get(selectCliente).select(cliente);
  }

  selecionarProduto(produto) {
    cy.get(selectProduto).select(produto);
  }

  preencherQuantidade(quantidade) {
    cy.get(inputQuantidade).last().type(quantidade);
  }

  getValorTotalPorProduto() {
    return cy.get(precoFinalPorProduto).last().invoke("text");
  }

  getPrecoUnitarioPorProduto(){
    return cy.get(precoUnitarioPorProduto).last().invoke("text");
  }

  getPrecoItensTotal(){
    return cy.get(precoItensTotal).invoke("text");
  }

  clicarFinalizarPedido(){
    cy.get(finalizarPedidoButton).click();
  }
}
