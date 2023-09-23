const { NovoPedidoPage, ConsultaPedidoPage } = require("../page-object");

const novoPedidoPage = new NovoPedidoPage();
const consultaPedidoPage = new ConsultaPedidoPage();

before(() => {
  cy.login("admin", "admin");
  novoPedidoPage.irParaUrl();
});

describe("Testar cadastrar pedido", () => {
  it("Adicionar Novo Pedido", () => {
    novoPedidoPage.selecionarCliente("Kegyu Guida");
    novoPedidoPage.selecionarProduto("1: Object");
    novoPedidoPage.preencherQuantidade("10");

    novoPedidoPage.getValorTotalPorProduto().should("contain", "R$516,890.00");
    novoPedidoPage
      .getPrecoUnitarioPorProduto()
      .should("contain", "X R$4,699.00");

    novoPedidoPage.selecionarProduto("5: Object");
    novoPedidoPage.preencherQuantidade("20");
    novoPedidoPage.getValorTotalPorProduto().should("contain", "R$723,492.00");
    novoPedidoPage
      .getPrecoUnitarioPorProduto()
      .should("contain", "X R$6,029.10");

    novoPedidoPage.getPrecoItensTotal().should("contain", "R$1,240,382.00");

    novoPedidoPage.clicarFinalizarPedido();
  });

  it("Verificar se o pedido foi cadastrado", () => {
    consultaPedidoPage.irParaUrl();
    consultaPedidoPage.getTabela().should("contain", "R$1,240,382.00");
    consultaPedidoPage.getTabela().should("contain", "230");
  });
});
