using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionariosApp.Models
{
    public class Funcionarios
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string NomeCompleto { get { return $"{Nome} {Sobrenome}"; } }
        public string Genero { get; set; }
        public string Salario { get; set; }
    }
}
