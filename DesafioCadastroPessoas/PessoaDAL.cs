using System;
using System.Data;
using System.Data.SqlClient;

namespace DesafioCadastroPessoas
{
    internal class PessoaDAL 
    {
        private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\PessoaDB.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";
        private static SqlConnection conn = new SqlConnection(connectionString);
        private static SqlCommand command;
        public static void conecta()
        {
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                Erro.setErro("Banco da Dados não localizado - contacte o suporte.");
            }
        }

        public static void desconecta()
        {
            conn.Close();
        }
        public static void AdicionarPessoa(Pessoa pessoa)
        {
            
            
                string query = "INSERT INTO Pessoas (Nome, Telefone, Email, Cep, Estado, Cidade, Bairro, Rua, Numero, Complemento) VALUES (@Nome, @Telefone, @Email, @Cep, @Estado, @Cidade, @Bairro, @Rua, @Numero, @Complemento)";

                    command = new SqlCommand(query, conn);
                
                    command.Parameters.AddWithValue("@Nome", pessoa.Nome);
                    command.Parameters.AddWithValue("@Telefone", pessoa.Telefone);
                    command.Parameters.AddWithValue("@Email", pessoa.Email);
                    command.Parameters.AddWithValue("@Cep", pessoa.Cep);
                    command.Parameters.AddWithValue("@Estado", pessoa.Estado);
                    command.Parameters.AddWithValue("@Cidade", pessoa.Cidade);
                    command.Parameters.AddWithValue("@Bairro", pessoa.Bairro);
                    command.Parameters.AddWithValue("@Rua", pessoa.Rua);
                    command.Parameters.AddWithValue("@Numero", pessoa.Numero);
                    command.Parameters.AddWithValue("@Complemento", pessoa.Complemento);

                
                    command.ExecuteNonQuery();
                
            
        }

        public static Pessoa BuscarPessoaPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Pessoas WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Pessoa pessoa = new Pessoa
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                Telefone = reader.GetString(reader.GetOrdinal("Telefone")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                Cep = reader.GetString(reader.GetOrdinal("Cep")),
                                Estado = reader.GetString(reader.GetOrdinal("Estado")),
                                Cidade = reader.GetString(reader.GetOrdinal("Cidade")),
                                Bairro = reader.GetString(reader.GetOrdinal("Bairro")),
                                Rua = reader.GetString(reader.GetOrdinal("Rua")),
                                Numero = reader.GetString(reader.GetOrdinal("Numero")),
                                Complemento = reader.GetString(reader.GetOrdinal("Complemento"))
                            };
                            return pessoa;
                        }
                        else
                        {
                           
                            Erro.setErro("Usuário não encontrado");
                            return null;
                        }
                    }
                }
            }
        }


        public static void AtualizarPessoa(Pessoa pessoa)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Pessoas SET Nome = @Nome, Telefone = @Telefone, Email = @Email, Cep = @Cep, Estado = @Estado, Cidade = @Cidade, Bairro = @Bairro, Rua = @Rua, Numero = @Numero, Complemento = @Complemento WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", pessoa.Nome);
                    command.Parameters.AddWithValue("@Telefone", pessoa.Telefone);
                    command.Parameters.AddWithValue("@Email", pessoa.Email);
                    command.Parameters.AddWithValue("@Cep", pessoa.Cep);
                    command.Parameters.AddWithValue("@Estado", pessoa.Estado);
                    command.Parameters.AddWithValue("@Cidade", pessoa.Cidade);
                    command.Parameters.AddWithValue("@Bairro", pessoa.Bairro);
                    command.Parameters.AddWithValue("@Rua", pessoa.Rua);
                    command.Parameters.AddWithValue("@Numero", pessoa.Numero);
                    command.Parameters.AddWithValue("@Complemento", pessoa.Complemento);
                    command.Parameters.AddWithValue("@Id", pessoa.Id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void RemoverPessoa(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Pessoas WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
