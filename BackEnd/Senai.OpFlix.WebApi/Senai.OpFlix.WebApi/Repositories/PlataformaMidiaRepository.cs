using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class PlataformaMidiaRepository : IPlataformaMidiaRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_OpFlix;User Id=sa;Pwd=132;";

        //atualizar plataformas ou mídias
        public void Atualizar(PlataformasMidias plataformamidia)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                PlataformasMidias PlataformaMidiaBuscada = ctx.PlataformasMidias.FirstOrDefault(x => x.IdPlataformaMidia == plataformamidia.IdPlataformaMidia);
                // update plataformasmidias set plataformamidia = @plataformamidia
                PlataformaMidiaBuscada.PlataformaMidia = plataformamidia.PlataformaMidia;
                // insert - add, delete - remove, update - update
                ctx.PlataformasMidias.Update(PlataformaMidiaBuscada);
                // efetivar
                ctx.SaveChanges();
            }
        }

        // buscar plataformas ou mídias por id
        public PlataformasMidias BuscarPorId(int Idplataformamidia)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.PlataformasMidias.FirstOrDefault(x => x.IdPlataformaMidia == Idplataformamidia);
            }
        }

        // cadastrar plataformas ou mídias 
        public void Cadastrar(PlataformasMidias plataformamidia)
        {
            string Query = "INSERT INTO PlataformasMidias(PlataformaMidia) VALUES (@PlataformaMidia)";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // insert into plataformasmidias (plataformamidia) values (@plataformamidia);
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@PlataformaMidia", plataformamidia.PlataformaMidia);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //filtrar plataformas ou mídias
        public PlataformasMidias FiltrarPlataforma(string nome)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                PlataformasMidias PlataformaMidiaBuscada = ctx.PlataformasMidias.FirstOrDefault(x => x.PlataformaMidia == nome);
                return PlataformaMidiaBuscada;
            }
        }

        //listar plataformas ou mídias
        public List<PlataformasMidias> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                // select * from plataformasmidias;
                return ctx.PlataformasMidias.OrderBy(x => x.IdPlataformaMidia).ToList();
            }
        }
    }
}
