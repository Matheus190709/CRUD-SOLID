namespace ProjetoSOLID.view;

public class MenuConsoleView : IMenuView
{
    public int ExibirMenu()
    {
        Console.Clear();
        Console.WriteLine("=== GERENCIAMENTO ===");
        Console.WriteLine("\n--- PRODUTOS ---");
        Console.WriteLine("1 - Cadastrar produto");
        Console.WriteLine("2 - Listar produtos");
        Console.WriteLine("3 - Buscar produto");
        Console.WriteLine("4 - Atualizar produto");
        Console.WriteLine("5 - Excluir produto");
        Console.WriteLine("\n--- COMPRAS ---");
        Console.WriteLine("6 - Cadastrar compra");
        Console.WriteLine("7 - Listar compras");
        Console.WriteLine("8 - Buscar compra");
        Console.WriteLine("9 - Atualizar compra");
        Console.WriteLine("10 - Excluir compra");
        Console.WriteLine("\n0 - Sair");
        Console.Write("\nEscolha uma opção: ");
        return int.TryParse(Console.ReadLine(), out int opcao) ? opcao : -1;
    }
}
