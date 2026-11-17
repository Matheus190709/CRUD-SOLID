using ProjetoSOLID.model;

namespace ProjetoSOLID.dados;

public class ListaProdutos : IRepository<Produto>
{
    private readonly List<Produto> produtos = new();
    private int proximoId = 1;

    public void Adicionar(Produto novo)
    {
        novo.Id = proximoId++;
        produtos.Add(novo);
    }

    public List<Produto> ListarTodos() => produtos.ToList();

    public Produto BuscarPorId(int id) => produtos.FirstOrDefault(p => p.Id == id);

    public void Atualizar(Produto entidade)
    {
        int indice = produtos.FindIndex(p => p.Id == entidade.Id);
        if (indice >= 0) produtos[indice] = entidade;
    }

    public void Remover(Produto entidade)
    {
        if (entidade != null) produtos.RemoveAll(p => p.Id == entidade.Id);
    }

    public void Remover(int id) => produtos.RemoveAll(p => p.Id == id);
}
