using ProjetoSOLID.dados;
using ProjetoSOLID.model;
using ProjetoSOLID.view;

namespace ProjetoSOLID.controller;

public class CompraController
{
    private readonly IRepository<Compra> repository;
    private readonly ICadastroCompraView cadastroView;
    private readonly IRepository<Produto> produtoRepository;

    public CompraController(IRepository<Compra> repository,
        ICadastroCompraView cadastroView, IRepository<Produto> produtoRepository)
    {
        this.repository = repository;
        this.cadastroView = cadastroView;
        this.produtoRepository = produtoRepository;

        cadastroView.DefinirRepositorioProdutos(produtoRepository);
    }

    public void Cadastrar()
    {
        var compra = cadastroView.ObterDados();
        if (compra.Produtos.Count == 0)
        {
            cadastroView.ExibirMensagem("Compra não cadastrada: adicione pelo menos um produto.");
            return;
        }
        repository.Adicionar(compra);
        cadastroView.ExibirMensagem($"Compra #{compra.Id} cadastrada! Total: {compra.Total:C}");
    }

    public void Listar()
    {
        var compras = repository.ListarTodos();
        if (compras.Count == 0) { Console.WriteLine("Nenhuma compra cadastrada."); return; }
        foreach (var compra in compras) ExibirCompra(compra);
    }

    public Compra Buscar(int id)
    {
        var compra = repository.BuscarPorId(id);
        if (compra == null) Console.WriteLine("Compra não encontrada.");
        else ExibirCompra(compra);
        return compra;
    }

    public void Atualizar(int id)
    {
        var compra = repository.BuscarPorId(id);
        if (compra == null) { Console.WriteLine("Compra não encontrada."); return; }

        Console.WriteLine("Atualização: os itens atuais serão substituídos.");
        var atualizada = cadastroView.ObterDados();
        if (atualizada.Produtos.Count == 0)
        {
            Console.WriteLine("Atualização cancelada: a compra precisa ter pelo menos um produto.");
            return;
        }

        atualizada.Id = compra.Id;
        atualizada.Data = compra.Data;
        repository.Atualizar(atualizada);
        Console.WriteLine("Compra atualizada com sucesso.");
    }

    public void Remover(int id)
    {
        if (repository.BuscarPorId(id) == null)
        {
            Console.WriteLine("Compra não encontrada.");
            return;
        }
        repository.Remover(id);
        Console.WriteLine("Compra excluída com sucesso.");
    }

    private static void ExibirCompra(Compra compra)
    {
        Console.WriteLine($"\n=== COMPRA #{compra.Id} ===");
        Console.WriteLine($"Data: {compra.Data:dd/MM/yyyy HH:mm}");
        foreach (var item in compra.Produtos)
            Console.WriteLine($"Produto: {item.Produto.Nome} | Qtd: {item.Quantidade} | Unitário: {item.PrecoUnitario:C} | Subtotal: {item.Subtotal:C}");
        Console.WriteLine($"TOTAL: {compra.Total:C}");
    }
}
