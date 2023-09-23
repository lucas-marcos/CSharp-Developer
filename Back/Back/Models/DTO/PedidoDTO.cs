using System.ComponentModel.DataAnnotations;

namespace Back.Models.DTO;

public class PedidoDTO
{
    [Required(ErrorMessage = "Informe um cliente")]
    [Range(1, int.MaxValue, ErrorMessage = "Informe um cliente")]
    public int ClienteId { get; set; }

    [Required(ErrorMessage = "Adicione um item no carrinho")]
    [MinLength(1, ErrorMessage = "Adicione um item no carrinho")]
    public List<ProdutosDoCarrinhoDTO> ProdutosDoCarrinho { get; set; }

    [Required(ErrorMessage = "O ValorFrete é obrigatório.")]
    [Range(0, double.MaxValue, ErrorMessage = "O ValorFrete não pode ser negativo.")]
    public decimal ValorFrete { get; set; }
}