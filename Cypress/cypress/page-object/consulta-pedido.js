const url = "pedido/consulta";

const tabela = "table";

export default class ConsultaPedidoPage {
  irParaUrl() {
    cy.visit(url);
  }

  getTabela() {
    return cy.get(tabela);
  }
}
