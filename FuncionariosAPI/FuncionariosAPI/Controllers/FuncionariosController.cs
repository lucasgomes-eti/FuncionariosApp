using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FuncionarioDataAccess;

namespace FuncionariosAPI.Controllers
{
    public class FuncionariosController : ApiController
    {
        public IEnumerable<Funcionario> Get()
        {
            using (FuncionarioDBEntities entities = new FuncionarioDBEntities())
            {
                return entities.Funcionarios.ToList();
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (FuncionarioDBEntities entities = new FuncionarioDBEntities())
            {
                var entity = entities.Funcionarios.FirstOrDefault(e => e.ID == id);

                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Funcionario com o id: {id.ToString()} não foi encontrado");
                }
            }
        }

        public HttpResponseMessage Post([FromBody] Funcionario funcionario)
        {
            try
            {
                using (FuncionarioDBEntities entities = new FuncionarioDBEntities())
                {
                    entities.Funcionarios.Add(funcionario);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, funcionario);
                    message.Headers.Location = new Uri(Request.RequestUri + funcionario.ID.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (FuncionarioDBEntities entities = new FuncionarioDBEntities())
                {
                    var entity = entities.Funcionarios.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"O funcionario com o id: {entity.ID.ToString()} não foi encontrado!");
                    }
                    else
                    {
                        entities.Funcionarios.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Put(int id, [FromBody] Funcionario funcionario)
        {
            try
            {
                using (FuncionarioDBEntities entities = new FuncionarioDBEntities())
                {
                    var entity = entities.Funcionarios.FirstOrDefault(e => e.ID == id);

                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"O funciorario com o id: {entity.ID.ToString()} não foi encontrado");
                    }
                    else
                    {
                        entity.Nome = funcionario.Nome;
                        entity.Sobrenome = funcionario.Sobrenome;
                        entity.Genero = funcionario.Genero;
                        entity.Salario = funcionario.Salario;

                        entities.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
