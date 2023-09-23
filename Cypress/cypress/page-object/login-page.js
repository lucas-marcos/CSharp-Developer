const url = "/login";

const inputLogin = "#usuario";
const inputSenha = "#senha";
const buttonEntrar = ".btn";

export default class LoginPage {
  irParaUrl() {
    cy.visit(url);
  }

  digitarLogin(login) {
    cy.get(inputLogin).type(login);
  }

  digitarSenha(senha) {
    cy.get(inputSenha).type(senha);
  }

  clicarEntrar() {
    cy.get(buttonEntrar).click();
  }
}
