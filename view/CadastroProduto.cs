using ProjetoSOLID.model;

namespace ProjetoSOLID.view;

public class CadastroProduto : ICadastroView<Produto>
{
    public void ExibirMensagem(string mensagem) => Console.WriteLine(mensagem);

    public Produto ObterDados()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine() ?? "";
        Console.Write("Preço: ");
        decimal.TryParse(Console.ReadLine(), out decimal preco);
        Console.Write("Descrição: ");
        string descricao = Console.ReadLine() ?? "";
        return new Produto(0, nome, preco, descricao);
    }
}
