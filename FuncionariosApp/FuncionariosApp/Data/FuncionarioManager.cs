using FuncionariosApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionariosApp.Data
{
    public class FuncionarioManager
    {
        IRestService restService;

        public FuncionarioManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<Funcionarios>> GetFuncionariosAsync()
        {
            return restService.GetFuncionariosAsync();
        }

        public Task PostFuncionarioAsync(Funcionarios funcionario)
        {
            return restService.PostFuncionarioAsync(funcionario);
        }

        public Task PutFuncionarioAsync(Funcionarios funcionario)
        {
            return restService.PutFuncionarioAsync(funcionario);
        }

        public Task DeleteFuncionarioAsync(Funcionarios funcionario)
        {
            return restService.DeleteFuncionarioAsync(funcionario.ID.ToString());
        }
    }
}
