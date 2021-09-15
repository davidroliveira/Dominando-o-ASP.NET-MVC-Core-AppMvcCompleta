using DevIO.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Services
{
    public interface IProdutoService: IDisposable
    {
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task Remover(Guid id);
    }
}