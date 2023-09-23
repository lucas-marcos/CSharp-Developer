import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NovoPedidoComponent } from './pedido/novo-pedido/novo-pedido.component';
import { ConsultarPedidoComponent } from './pedido/consultar-pedido/consultar-pedido.component';

const routes: Routes = [
  { path: 'pedido/novo', component: NovoPedidoComponent },
  { path: 'pedido/consulta', component: ConsultarPedidoComponent },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
