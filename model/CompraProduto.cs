namespace ProjetoSOLID.model;

// Entidade associativa que representa o relacionamento N:N.
public class CompraProduto
{
    public int CompraId { get; set; }
    public int ProdutoId { get; set; }
    public Produto Produto { get; set; }
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }

    public decimal Subtotal => Quantidade * PrecoUnitario;

    public CompraProduto(int compraId, Produto produto, int quantidade)
    {
        CompraId = compraId;
        Produto = produto;
        ProdutoId = produto.Id;
        Quantidade = quantidade;
        PrecoUnitario = produto.Preco;
    }
}
