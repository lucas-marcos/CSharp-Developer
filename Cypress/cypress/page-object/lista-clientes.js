const url = "cadastro/cliente";
const table = "table";

export default class ListaClientePage {
  irParaUrl() {
    cy.visit(url);
  }

  getTable() {
    return cy.get(table);
  }
}
