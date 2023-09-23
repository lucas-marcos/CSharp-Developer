import { LoginPage } from "../page-object";

Cypress.Commands.add("login", (email, password) => {
  let loginPage = new LoginPage();
  
  loginPage.irParaUrl();
  loginPage.digitarLogin(email);
  loginPage.digitarSenha(password);
  loginPage.clicarEntrar();
});
