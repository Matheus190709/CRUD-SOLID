using ProjetoSOLID.controller;
using ProjetoSOLID.dados;
using ProjetoSOLID.model;
using ProjetoSOLID.view;

namespace ProjetoSOLID;

internal class Program
{
    static void Main(string[] args)
    {
        IRepository<Produto> produtoRepository = new ListaProdutos();
        IRepository<Compra> compraRepository = new ListaCompras();

        IProdutoView produtoView = new ProdutoView();
        ICadastroView<Produto> cadastroProdutoView = new CadastroProduto();
        ICadastroView<Compra> cadastroCompraView = new CadastroCompra();
        IMenuView menuView = new MenuConsoleView();

        var produtoController = new ProdutoController(
            produtoView, produtoRepository, cadastroProdutoView);

        var compraController = new CompraController(
            compraRepository, cadastroCompraView, produtoRepository);

        int opcao;
        do
        {
            opcao = menuView.ExibirMenu();
            Console.Clear();

            switch (opcao)
            {
                case 1:
                    produtoController.Cadastrar();
                    break;
                case 2:
                    produtoController.Listar();
                    break;
                case 3:
                    Console.Write("ID do produto: ");
                    if (int.TryParse(Console.ReadLine(), out int idBusca))
                        produtoView.MostrarProduto(produtoController.Buscar(idBusca));
                    else
                        Console.WriteLine("ID inválido.");
                    break;
                case 4:
                    Console.Write("ID do produto que deseja atualizar: ");
                    if (int.TryParse(Console.ReadLine(), out int idAtualizar))
                        produtoController.Atualizar(idAtualizar);
                    else
                        Console.WriteLine("ID inválido.");
                    break;
                case 5:
                    Console.Write("ID do produto que deseja excluir: ");
                    if (int.TryParse(Console.ReadLine(), out int idExcluir))
                        produtoController.Remover(idExcluir);
                    else
                        Console.WriteLine("ID inválido.");
                    break;
                case 6:
                    compraController.Cadastrar();
                    break;
                case 7:
                    compraController.Listar();
                    break;
                case 8:
                    Console.Write("ID da compra: ");
                    if (int.TryParse(Console.ReadLine(), out int idCompra))
                        compraController.Buscar(idCompra);
                    else
                        Console.WriteLine("ID inválido.");
                    break;
                case 9:
                    Console.Write("ID da compra que deseja atualizar: ");
                    if (int.TryParse(Console.ReadLine(), out int idCompraAtualizar))
                        compraController.Atualizar(idCompraAtualizar);
                    else
                        Console.WriteLine("ID inválido.");
                    break;
                case 10:
                    Console.Write("ID da compra que deseja excluir: ");
                    if (int.TryParse(Console.ReadLine(), out int idCompraExcluir))
                        compraController.Remover(idCompraExcluir);
                    else
                        Console.WriteLine("ID inválido.");
                    break;
                case 0:
                    Console.WriteLine("Encerrando o sistema...");
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

            if (opcao != 0)
            {
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        } while (opcao != 0);
    }
}
