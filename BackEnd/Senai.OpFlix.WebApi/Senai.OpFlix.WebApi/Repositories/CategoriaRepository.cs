using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_OpFlix;User Id=sa;Pwd=132;";

        //atualizar categorias
        public void Atualizar(Categorias categoria)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Categorias CategoriaBuscada = ctx.Categorias.FirstOrDefault(x => x.IdCategoria == categoria.IdCategoria);
                // update categorias set categoria = @categoria
                CategoriaBuscada.Categoria = categoria.Categoria;
                // insert - add, delete - remove, update - update
                ctx.Categorias.Update(CategoriaBuscada);
                // efetivar
                ctx.SaveChanges();
            }

        }

        //cadastrar categorias
        public void Cadastrar(Categorias categoria)
        {
            string Query = "INSERT INTO Categorias(Categoria) VALUES (@Categoria)";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // insert into categorias (categoria) values (@categoria);
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Categoria", categoria.Categoria);  
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //listar categorias
        public List<Categorias> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                // select * from categorias;
                return ctx.Categorias.OrderBy(x => x.IdCategoria).ToList();
            }
        }

        //buscar por id categorias
        public Categorias BuscarPorId(int IdCategoria)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Categorias.FirstOrDefault(x => x.IdCategoria == IdCategoria);
            }
        }

    }
}
