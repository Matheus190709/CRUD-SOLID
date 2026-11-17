using ProjetoSOLID.dados;
using ProjetoSOLID.model;

namespace ProjetoSOLID.view;

public interface ICadastroCompraView : ICadastroView<Compra>
{
    void DefinirRepositorioProdutos(IRepository<Produto> repository);
}
