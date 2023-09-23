import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NovoPedidoComponent } from './pedido/novo-pedido/novo-pedido.component';
import { ConsultarPedidoComponent } from './pedido/consultar-pedido/consultar-pedido.component';
import { ClienteComponent } from './cadastro/cliente/cliente.component';

const routes: Routes = [
  { path: 'pedido/novo', component: NovoPedidoComponent },
  { path: 'pedido/consulta', component: ConsultarPedidoComponent },
  { path: 'cadastro/cliente', component: ClienteComponent },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
