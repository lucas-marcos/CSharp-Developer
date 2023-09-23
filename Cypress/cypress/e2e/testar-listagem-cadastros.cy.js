const { ListaClientePage, ListaProdutoPage } = require("../page-object");

const clientes = require("../fixtures/clientes.json");
const produtos = require("../fixtures/produtos.json");

let listageClientes = new ListaClientePage();
let listaProdutoPage = new ListaProdutoPage();

before(() => {
  cy.login("admin", "admin");
  listageClientes.irParaUrl();
});

describe("Testar listagem de clientes", () => {

    clientes.forEach(cliente => {
        it(`Verificar se o cliente ${cliente.nome} está cadastrado`, () => {
            listageClientes.getTable().should("contain", cliente.nome);
        });
    });
});

describe("Testar listagem de produtos", () => {
    before(() => {
        listaProdutoPage.irParaUrl();
    });
    
    produtos.forEach(produto => {
        it(`Verificar se o produto ${produto.nome} está cadastrado`, () => {
            listageClientes.getTable().should("contain", produto.nome);
        });
    });
});
