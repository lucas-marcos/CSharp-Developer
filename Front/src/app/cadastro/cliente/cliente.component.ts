import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Cliente } from 'src/models/cliente';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.scss']
})
export class ClienteComponent implements OnInit {

  clientes: Cliente[] = [];

  constructor(private http: HttpClient, private toastr: ToastrService) {}

  ngOnInit(){
    this.buscarClientes();
  }

  buscarClientes(){
    const url = 'https://localhost:7042/api/cliente';
    this.http.get<any[]>(url).subscribe((response) => {
      this.clientes = response;
    },
    error => this.toastr.error(error.error, 'Listar Clientes'));
  }
}
