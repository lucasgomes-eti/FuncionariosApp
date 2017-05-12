using FuncionariosApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionariosApp.Data
{
    public interface IRestService
    {
        Task<List<Funcionarios>> GetFuncionariosAsync();

        Task PostFuncionarioAsync(Funcionarios funcionario);

        Task PutFuncionarioAsync(Funcionarios funcionario);

        Task DeleteFuncionarioAsync(string id);
    }
}
