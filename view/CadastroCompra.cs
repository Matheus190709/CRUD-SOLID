using ProjetoSOLID.model;
using ProjetoSOLID.dados;

namespace ProjetoSOLID.view;

public class CadastroCompra : ICadastroCompraView
{
    private IRepository<Produto> produtoRepository;

    public void DefinirRepositorioProdutos(IRepository<Produto> repository)
    {
        produtoRepository = repository;
    }

    public void ExibirMensagem(string mensagem) => Console.WriteLine(mensagem);

    public Compra ObterDados()
    {
        var compra = new Compra(0, DateTime.Now);

        if (produtoRepository == null)
        {
            ExibirMensagem("Repositório de produtos não configurado.");
            return compra;
        }

        var produtos = produtoRepository.ListarTodos();
        if (produtos.Count == 0)
        {
            ExibirMensagem("Cadastre produtos antes de registrar uma compra.");
            return compra;
        }

        Console.WriteLine("Produtos disponíveis:");
        foreach (var produto in produtos)
            Console.WriteLine(produto);

        Console.WriteLine("\nInforme os produtos da compra. Digite 0 para finalizar.");
        while (true)
        {
            Console.Write("\nID do produto (0 para finalizar): ");
            if (!int.TryParse(Console.ReadLine(), out int id) || id == 0)
                break;

            var produtoSelecionado = produtoRepository.BuscarPorId(id);
            if (produtoSelecionado == null)
            {
                ExibirMensagem("Produto não encontrado.");
                continue;
            }

            Console.Write("Quantidade: ");
            if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
            {
                ExibirMensagem("Quantidade inválida.");
                continue;
            }

            var itemExistente = compra.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if (itemExistente != null)
                itemExistente.Quantidade += quantidade;
            else
                compra.Produtos.Add(new CompraProduto(0, produtoSelecionado, quantidade));
        }

        return compra;
    }
}
