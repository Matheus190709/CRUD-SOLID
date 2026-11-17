using ProjetoSOLID.model;

namespace ProjetoSOLID.dados;

public class ListaCompras : IRepository<Compra>
{
    private readonly List<Compra> compras = new();
    private int proximoId = 1;

    public void Adicionar(Compra nova)
    {
        nova.Id = proximoId++;
        foreach (var item in nova.Produtos)
            item.CompraId = nova.Id;
        compras.Add(nova);
    }

    public List<Compra> ListarTodos() => compras.ToList();

    public Compra BuscarPorId(int id) => compras.FirstOrDefault(c => c.Id == id);

    public void Atualizar(Compra entidade)
    {
        int indice = compras.FindIndex(c => c.Id == entidade.Id);
        if (indice >= 0)
        {
            foreach (var item in entidade.Produtos)
                item.CompraId = entidade.Id;
            compras[indice] = entidade;
        }
    }

    public void Remover(Compra entidade)
    {
        if (entidade != null) compras.RemoveAll(c => c.Id == entidade.Id);
    }

    public void Remover(int id) => compras.RemoveAll(c => c.Id == id);
}
