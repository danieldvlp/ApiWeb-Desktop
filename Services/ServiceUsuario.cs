using ApiWeb.Model;
using ApiWeb.Repository;
using ApiWeb.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Services
{
    public class ServiceUsuario : IInterfaceDefault<Usuario>

    {
        private readonly IRepository<Usuario> serviceUsuario;
        private int Id;

        public ServiceUsuario(IRepository<Usuario> serviceUsuario)
        {
            this.serviceUsuario = serviceUsuario;
        }

        void IInterfaceDefault<Usuario>.Adicionar(Usuario item)
        {
            serviceUsuario.Adicionar(item);
            serviceUsuario.Commit();

        }

        Usuario IInterfaceDefault<Usuario>.Atualizar(int id, Usuario entity)
        {
            var usuario = serviceUsuario.BuscaPorId(entity.Id);

            if (usuario != null)
            {
                usuario.Nome = entity.Nome;
                usuario.Endereco = entity.Endereco;
                usuario.Telefone = entity.Telefone;
                serviceUsuario.Editar(usuario);
            }
            return usuario;
        }

        Usuario IInterfaceDefault<Usuario>.BuscaPorId(int id)
        {
            return serviceUsuario.BuscaPorId(id);
        }

        List<Usuario> IInterfaceDefault<Usuario>.BuscarTodos()
        {
            return serviceUsuario.BuscarTodos().ToList();

        }

        void IInterfaceDefault<Usuario>.Excluir(int id)
        {
            var usuario = serviceUsuario.BuscaPorId(id);

            if (usuario != null)
                serviceUsuario.Remover(usuario);

        }
    }
}
