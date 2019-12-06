using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    interface ICategoriaRepository
    {
        void Cadastrar(Categorias categoria);

        List<Categorias> Listar();

        void Atualizar(Categorias categoria);

        Categorias BuscarPorId(int IdCategoria);
    }
}
