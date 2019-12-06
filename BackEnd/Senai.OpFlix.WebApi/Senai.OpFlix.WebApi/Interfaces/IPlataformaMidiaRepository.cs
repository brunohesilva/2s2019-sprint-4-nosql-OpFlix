using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    interface IPlataformaMidiaRepository
    {
        void Cadastrar(PlataformasMidias plataformamidia);

        List<PlataformasMidias> Listar();

        void Atualizar(PlataformasMidias plataformamidia);

        PlataformasMidias BuscarPorId(int Idplataformamidia);

        PlataformasMidias FiltrarPlataforma(string nome);
    }
}
