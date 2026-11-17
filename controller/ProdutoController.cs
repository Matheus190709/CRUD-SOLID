using ProjetoSOLID.dados;
using ProjetoSOLID.model;
using ProjetoSOLID.view;

namespace ProjetoSOLID.controller;

public class ProdutoController
{
    private readonly IRepository<Produto> repository;
    private readonly IProdutoView view;
    private readonly ICadastroView<Produto> cadastroView;

    public ProdutoController(IProdutoView view, IRepository<Produto> repository,
        ICadastroView<Produto> cadastroView)
    {
        this.view = view;
        this.repository = repository;
        this.cadastroView = cadastroView;
    }

    public void Cadastrar()
    {
        var produto = cadastroView.ObterDados();
        repository.Adicionar(produto);
        cadastroView.ExibirMensagem("Produto cadastrado com sucesso!");
    }

    public void Listar()
    {
        var produtos = repository.ListarTodos();
        if (produtos.Count == 0) Console.WriteLine("Nenhum produto cadastrado.");
        foreach (var produto in produtos) view.MostrarProduto(produto);
    }

    public Produto Buscar(int id) => repository.BuscarPorId(id);

    public void Atualizar(int id)
    {
        var existente = Buscar(id);
        if (existente == null) { Console.WriteLine("Produto não encontrado."); return; }

        Console.WriteLine($"Produto atual: {existente}");
        Console.Write("Novo nome: ");
        existente.Nome = Console.ReadLine() ?? existente.Nome;
        Console.Write("Novo preço: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal preco)) existente.Preco = preco;
        Console.Write("Nova descrição: ");
        existente.Descricao = Console.ReadLine() ?? existente.Descricao;
        repository.Atualizar(existente);
        Console.WriteLine("Produto atualizado com sucesso.");
    }

    public void Remover(int id)
    {
        if (Buscar(id) == null) { Console.WriteLine("Produto não encontrado."); return; }
        repository.Remover(id);
        Console.WriteLine("Produto excluído com sucesso.");
    }
}
