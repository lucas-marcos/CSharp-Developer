const url = "cadastro/produto";
const table = "table";

export default class ListaProdutoPage {
  irParaUrl() {
    cy.visit(url);
  }

  getTable() {
    return cy.get(table);
  }
}
