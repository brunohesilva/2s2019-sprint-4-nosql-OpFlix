using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_OpFlix;User Id=sa;Pwd=132;";

        //atualizar lançamento
        public void Atualizar(Lancamentos lancamento)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Lancamentos LancamentoBuscado = ctx.Lancamentos.FirstOrDefault(x => x.IdLancamento == lancamento.IdLancamento);
                // update lancamentos set lancamento = @lancamento
                LancamentoBuscado.Titulo = lancamento.Titulo;
                // insert - add, delete - remove, update - update
                ctx.Lancamentos.Update(LancamentoBuscado);
                // efetivar
                ctx.SaveChanges();
            }
        }

        public List<Lancamentos> BuscarPorCategoria(int categoria)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamentos.Where(x => x.IdCategoria == categoria).ToList();
            }
        }

        public List<Lancamentos> BuscarPorData(DateTime data)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamentos.Where(x => x.DataLancamento == data).ToList();
            }
        }

        // buscar lançamento por id
        public Lancamentos BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamentos.FirstOrDefault(x => x.IdLancamento == id);
            }

        }

        //cadastrar lançamentos
        public void Cadastrar(Lancamentos lancamento)
        {
            string Query = "INSERT INTO Lancamentos(Titulo, Sinopse, IdCategoria, TempoDuracao, FilmeSerie, DataLancamento) VALUES (@Titulo, @Sinopse, @IdCategoria, @TempoDuracao, @FilmeSerie, @DataLancamento)";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // insert into categorias (titulo),(sinopse),(idcategoria),(tempoduracao),(filmeserie),(datalancamento) values (@titulo),(@sinopse),(@idcategoria),(@tempoduracao),(@filmeserie),(@datalancamento);
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Titulo", lancamento.Titulo);
                cmd.Parameters.AddWithValue("@Sinopse", lancamento.Sinopse);
                cmd.Parameters.AddWithValue("@IdCategoria", lancamento.IdCategoria);
                cmd.Parameters.AddWithValue("@TempoDuracao", lancamento.TempoDuracao);
                cmd.Parameters.AddWithValue("@FilmeSerie", lancamento.FilmeSerie);
                cmd.Parameters.AddWithValue("@DataLancamento", lancamento.DataLancamento);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //deletar lançamentos
        public void Deletar(int id)
        {
                using (OpFlixContext ctx = new OpFlixContext())
                {
                    // encontrar o item
                    Lancamentos LancamentoBuscado = ctx.Lancamentos.Find(id);
                    // remover do contexto
                    ctx.Lancamentos.Remove(LancamentoBuscado);
                    // efetivar as mudanças no banco de dados
                    ctx.SaveChanges();
                }
        }

        public List<Lancamentos> Listar()
        {
            List<Lancamentos> lancamentos = new List<Lancamentos>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT Lancamentos.IdLancamento, Lancamentos.Titulo, Lancamentos.Sinopse, Lancamentos.IdCategoria, Lancamentos.TempoDuracao, Lancamentos.FilmeSerie, Lancamentos.DataLancamento, Categorias.IdCategoria, Categorias.Categoria FROM Lancamentos JOIN Categorias ON Lancamentos.IdCategoria = Categorias.IdCategoria";
                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    // select * from lançamentos;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Lancamentos lancamento = new Lancamentos
                        {
                            IdLancamento = Convert.ToInt32(rdr["IdLancamento"]),
                            Titulo = rdr["Titulo"].ToString(),
                            Sinopse = rdr["Sinopse"].ToString(),
                            TempoDuracao = rdr["TempoDuracao"].ToString(),
                            FilmeSerie = rdr["FilmeSerie"].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),
                            IdCategoriaNavigation = new Categorias
                            {
                                IdCategoria = Convert.ToInt32(rdr["IdCategoria"]),
                                Categoria = rdr["Categoria"].ToString()
                            }
                        };
                        lancamentos.Add(lancamento);
                    }
                }
            }
            return lancamentos;
        }
    }
}
