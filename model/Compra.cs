namespace ProjetoSOLID.model;

public class Compra
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public List<CompraProduto> Produtos { get; set; } = new();

    public decimal Total => Produtos.Sum(item => item.Subtotal);

    public Compra(int id, DateTime data)
    {
        Id = id;
        Data = data;
    }
}
