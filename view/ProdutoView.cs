using ProjetoSOLID.model;

namespace ProjetoSOLID.view;

public class ProdutoView : IProdutoView
{
    public void MostrarProduto(Produto produto)
    {
        if (produto == null)
        {
            Console.WriteLine("Produto não encontrado.");
            return;
        }
        Console.WriteLine(produto);
    }
}
