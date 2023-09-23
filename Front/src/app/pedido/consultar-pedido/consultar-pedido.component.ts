import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { NovoPedido } from 'src/models/novo-pedido';

@Component({
  selector: 'app-consultar-pedido',
  templateUrl: './consultar-pedido.component.html',
  styleUrls: ['./consultar-pedido.component.scss']
})
export class ConsultarPedidoComponent implements OnInit {
    pedidos: NovoPedido[] = [];


  constructor(private http: HttpClient, private toastr: ToastrService) {}

  ngOnInit(){
    this.consultarPedido();
  }

  consultarPedido() {
    const url = 'https://localhost:7042/api/pedido';
    this.http.get<any[]>(url).subscribe((response) => {
      this.pedidos = response;
    },
    error => this.toastr.error(error.error, 'Listar Pedidos'));
  }
}
