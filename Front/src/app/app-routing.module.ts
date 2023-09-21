import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NovoPedidoComponent } from './pedido/novo-pedido/novo-pedido.component';

const routes: Routes = [
  { path: 'pedido/novo', component: NovoPedidoComponent },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
