using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class UsuarioClienteRepository : IUsuarioClienteRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_OpFlix;User Id=sa;Pwd=132;";

        //cadastrar usuários CLIENTE
        public void Cadastrar(Usuarios usuario)
        {
            string Query = "INSERT INTO Usuarios(Nome, Email, Senha) VALUES (@Nome, @Email, @Senha)";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // insert into usuarioscliente (nome),(email),(senha) values (@nome),(@email),(@senha);
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
