using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CadastroUsuario
{
    internal class Program
    {
        static string delimitadorInicio;
        static string delimitadorFim;
        static string tagNome;
        static string tagDataNascimento;
        static string tagNomeDaRua;
        static string tagNumeroDaCasa;
        static string tagNumeroDoDocumento;
        static string caminhoArquivo;
        public struct DadosCadastraisStruct
        {
            public string Nome;
            public DateTime DataNascimento;
            public string NomeDaRua;
            public UInt32 NumeroDaCasa;
            public string NumeroDoDocumento;
        }
        public enum Resultado_e
        {
            Sucesso = 0,
            Sair = 1,
            Excecao = 2
        }

        public static void MostraMensagem(string mensagem)
        // Mostra mensagem na tela e espera o usuário pressionar qualquer tecla para continuar
        {
            Console.WriteLine(mensagem);
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        public static Resultado_e PegaString(ref string minhaString, string mensagem)
        // Pega uma string do usuário e retorna o resultado da operação
        {
            Resultado_e retorno;
            Console.WriteLine(mensagem);
            string temp = Console.ReadLine();
            if (temp == "s" || temp == "S")
            {
                retorno = Resultado_e.Sair;
            }
            else
            {
                minhaString = temp;
                retorno = Resultado_e.Sucesso;
            }
            Console.Clear();
            return retorno;
        }

        public static Resultado_e PegaData(ref DateTime minhaData, string mensagem)
        // Pega uma data do usuário e retorna o resultado da operação
        {
            Resultado_e retorno;
            do
            {
                try
                {
                    Console.WriteLine(mensagem);
                    string temp = Console.ReadLine();
                    if (temp == "s" || temp == "S")
                    {
                        retorno = Resultado_e.Sair;
                    }
                    else
                    {
                        minhaData = Convert.ToDateTime(temp);
                        retorno = Resultado_e.Sucesso;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro: " + e.Message);
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    retorno = Resultado_e.Excecao;
                }
            } while (retorno == Resultado_e.Excecao);
            Console.Clear();
            return retorno;
        }
        public static Resultado_e PegaUInt32(ref UInt32 numeroUInt32, string mensagem)
        // Pega um UInt32 do usuário e retorna o resultado da operação
        {
            Resultado_e retorno;
            do
            {
                try
                {
                    Console.WriteLine(mensagem);
                    string temp = Console.ReadLine();
                    if (temp == "s" || temp == "S")
                    {
                        retorno = Resultado_e.Sair;
                    }
                    else
                    {
                        numeroUInt32 = Convert.ToUInt32(temp);
                        retorno = Resultado_e.Sucesso;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro: " + e.Message);
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    retorno = Resultado_e.Excecao;
                }
            } while (retorno == Resultado_e.Excecao);
            Console.Clear();
            return retorno;
        }

        public static Resultado_e CadastraUsuario(ref List<DadosCadastraisStruct> ListaDeUsuarios)
        // Cadastra um usuário e retorna o resultado da operação
        {
            DadosCadastraisStruct cadastroUsuario;
            cadastroUsuario.Nome = "";
            cadastroUsuario.DataNascimento = new DateTime();
            cadastroUsuario.NomeDaRua = "";
            cadastroUsuario.NumeroDaCasa = 0;
            cadastroUsuario.NumeroDoDocumento = "";
            if (PegaString(ref cadastroUsuario.Nome, "Digite o nome do usuário ou S para sair:") == Resultado_e.Sair)
                return Resultado_e.Sair;
            if (PegaData(ref cadastroUsuario.DataNascimento, "Digite a data de nascimento no formato DD/MM/AAAA ou S para sair:") == Resultado_e.Sair)
                return Resultado_e.Sair;
            if (PegaString(ref cadastroUsuario.NomeDaRua, "Digite o nome da rua do usuário ou S para sair:") == Resultado_e.Sair)
                return Resultado_e.Sair;
            if (PegaUInt32(ref cadastroUsuario.NumeroDaCasa, "Digite o número da casa do usuário ou S para sair:") == Resultado_e.Sair)
                return Resultado_e.Sair;
            if (PegaString(ref cadastroUsuario.NumeroDoDocumento, "Digite o número do documento do usuário ou S para sair:") == Resultado_e.Sair)
                return Resultado_e.Sair;
            ListaDeUsuarios.Add(cadastroUsuario);
            GravaDados(caminhoArquivo, ListaDeUsuarios);
            return Resultado_e.Sucesso;
        }

        public static void GravaDados(string caminho, List<DadosCadastraisStruct> ListaDeUsuarios)
        // Grava os dados em um arquivo
        {
            try
            {
                string counteudoArquivo = "";
                foreach (DadosCadastraisStruct cadastro in ListaDeUsuarios)
                {
                    counteudoArquivo += delimitadorInicio + "\r\n";
                    counteudoArquivo += tagNome + cadastro.Nome + "\r\n";
                    counteudoArquivo += tagDataNascimento + cadastro.DataNascimento.ToString("dd/MM/yyyy") + "\r\n";
                    counteudoArquivo += tagNomeDaRua + cadastro.NomeDaRua + "\r\n";
                    counteudoArquivo += tagNumeroDaCasa + cadastro.NumeroDaCasa + "\r\n";
                    counteudoArquivo += tagNumeroDoDocumento + cadastro.NumeroDoDocumento + "\r\n";
                    counteudoArquivo += delimitadorFim + "\r\n";
                }
                File.WriteAllText(caminho, counteudoArquivo);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
        }

        public static void CarregaDados(string caminho, ref List<DadosCadastraisStruct> ListaDeUsuarios)
        // Carrega os dados de um arquivo
        {
            try
            {
                if (File.Exists(caminho))
                {
                    string[] conteudoArquivo = File.ReadAllLines(caminho);
                    DadosCadastraisStruct dadosCadastrais;
                    dadosCadastrais.Nome = "";
                    dadosCadastrais.DataNascimento = new DateTime();
                    dadosCadastrais.NomeDaRua = "";
                    dadosCadastrais.NumeroDaCasa = 0;
                    dadosCadastrais.NumeroDoDocumento = "";

                    foreach (string linha in conteudoArquivo)
                    {
                        if (linha.Contains(delimitadorInicio))
                            continue;
                        if (linha.Contains(delimitadorFim))
                            ListaDeUsuarios.Add(dadosCadastrais);
                        if (linha.Contains(tagNome))
                            dadosCadastrais.Nome = linha.Replace(tagNome, "");
                        if (linha.Contains(tagDataNascimento))
                            dadosCadastrais.DataNascimento = Convert.ToDateTime(linha.Replace(tagDataNascimento, ""));
                        if (linha.Contains(tagNomeDaRua))
                            dadosCadastrais.NomeDaRua = linha.Replace(tagNomeDaRua, "");
                        if (linha.Contains(tagNumeroDaCasa))
                            dadosCadastrais.NumeroDaCasa = Convert.ToUInt32(linha.Replace(tagNumeroDaCasa, ""));
                        if (linha.Contains(tagNumeroDoDocumento))
                            dadosCadastrais.NumeroDoDocumento = linha.Replace(tagNumeroDoDocumento, "");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
        }

        public static void BuscaUsuarioPeloDoc(List<DadosCadastraisStruct> ListaDeUsuarios)
        // Busca um usuário pelo número do documento
        {
            Console.WriteLine("Digite o número do documento do usuário que deseja buscar:");
            string temp = Console.ReadLine();
            if (temp.ToLower() == "s")
                return;
            else
            {
                List<DadosCadastraisStruct> ListaDeUsuariosTemp = ListaDeUsuarios.Where(x => x.NumeroDoDocumento == temp).ToList();
                if (ListaDeUsuariosTemp.Count > 0)
                {
                    foreach (DadosCadastraisStruct usuario in ListaDeUsuariosTemp)
                    {
                        Console.WriteLine(tagNome + usuario.Nome);
                        Console.WriteLine(tagDataNascimento + usuario.DataNascimento.ToString("dd/MM/yyyy"));
                        Console.WriteLine(tagNomeDaRua + usuario.NomeDaRua);
                        Console.WriteLine(tagNumeroDaCasa + usuario.NumeroDaCasa);
                        Console.WriteLine(tagNumeroDoDocumento + usuario.NumeroDoDocumento);
                    }
                }
                else
                {
                    Console.WriteLine("Não existe nenhum usuário com o documento: " + temp);

                }
                MostraMensagem("");
            }
        }

        public static void ExcluiUsuarioPeloDoc(ref List<DadosCadastraisStruct> ListaDeUsuarios)
        // Exclui um usuário pelo número do documento
        {
            Console.WriteLine("Digite o número do documento do usuário que deseja excluir ou digite S para sair");
            string temp = Console.ReadLine();
            bool alguemFoiExcluido = false;
            if (temp.ToLower() == "s")
                return;
            else
            {
                List<DadosCadastraisStruct> ListaDeUsuariosTemp = ListaDeUsuarios.Where(x => x.NumeroDoDocumento == temp).ToList();
                if (ListaDeUsuariosTemp.Count > 0)
                {
                    foreach (DadosCadastraisStruct usuario in ListaDeUsuariosTemp)
                    {
                        Console.WriteLine(tagNome + usuario.Nome);
                        Console.WriteLine(tagDataNascimento + usuario.DataNascimento.ToString("dd/MM/yyyy"));
                        Console.WriteLine(tagNomeDaRua + usuario.NomeDaRua);
                        Console.WriteLine(tagNumeroDaCasa + usuario.NumeroDaCasa);
                        Console.WriteLine(tagNumeroDoDocumento + usuario.NumeroDoDocumento);
                        Console.WriteLine("Deseja excluir este usuário? S/N");
                        string resposta = Console.ReadLine();
                        if (resposta.ToLower() == "s")
                        {
                            ListaDeUsuarios.Remove(usuario);
                            alguemFoiExcluido = true;
                        }
                        else if (resposta.ToLower() == "n")
                            continue;
                        else
                        {
                            Console.WriteLine("Resposta inválida");
                            break;
                        }

                    }
                    if (alguemFoiExcluido)
                        GravaDados(caminhoArquivo, ListaDeUsuarios);
                    Console.WriteLine(ListaDeUsuariosTemp.Count + " usuário(s) com documento " + temp + " excluído(s)");
                }
                else
                {
                    Console.WriteLine("Não existe nenhum usuário com o documento: " + temp);
                }
            }
            MostraMensagem("");
        }

        static void Main(string[] args)
        {
            List<DadosCadastraisStruct> ListaDeUsuarios = new List<DadosCadastraisStruct>();
            string opcao = "";
            delimitadorInicio = "##### INICIO #####";
            delimitadorFim = "##### FIM #####";
            tagNome = "NOME: ";
            tagDataNascimento = "DATA_DE_NASCIMENTO: ";
            tagNomeDaRua = "NOME_DA_RUA: ";
            tagNumeroDaCasa = "NUMERO_DA_CASA: ";
            tagNumeroDoDocumento = "NUMERO_DO_DOCUMENTO: ";
            caminhoArquivo = @"baseDeDados.txt";

            CarregaDados(caminhoArquivo, ref ListaDeUsuarios);

            do
            {
                Console.WriteLine("Pressione C para cadastrar um novo usuário");
                Console.WriteLine("Pressione B para buscar um usuário");
                Console.WriteLine("Pressione E para excluir um usuário");
                Console.WriteLine("Pressione S para sair");

                opcao = Console.ReadKey(true).KeyChar.ToString().ToLower();
                if (opcao == "c")
                {
                    CadastraUsuario(ref ListaDeUsuarios);

                }
                else if (opcao == "b")
                {
                    BuscaUsuarioPeloDoc(ListaDeUsuarios);
                }
                else if (opcao == "e")
                {
                    ExcluiUsuarioPeloDoc(ref ListaDeUsuarios);
                }
                else if (opcao == "s")
                {
                    MostraMensagem("Saindo...");
                }
                else
                {
                    MostraMensagem("Opção inválida!");
                }
            } while (opcao != "s");
        }
    }
}
