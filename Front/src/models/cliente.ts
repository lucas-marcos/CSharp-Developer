export class Cliente {
  id?: number;
  codigo?: string;
  nome?: string;

  constructor(id?: number, codigo?: string, nome?: string) {
    this.id = id;
    this.codigo = codigo;
    this.nome = nome;
  }
}
