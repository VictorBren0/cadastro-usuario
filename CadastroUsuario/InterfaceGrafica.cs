using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuario
{
    internal class InterfaceGrafica
    {
        public enum Resultado_e
        {
            Sucesso = 0,
            Sair = 1,
            Excecao = 2
        }
        public void MostraMensagem(string mensagem)
        // Mostra mensagem na tela e espera o usuário pressionar qualquer tecla para continuar
        {
            Console.WriteLine(mensagem);
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        public Resultado_e PegaString(ref string minhaString, string mensagem)
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

        public Resultado_e PegaData(ref DateTime minhaData, string mensagem)
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
                    MostraMensagem("Erro: " + e.Message);
                    retorno = Resultado_e.Excecao;
                }
            } while (retorno == Resultado_e.Excecao);
            Console.Clear();
            return retorno;
        }
        public Resultado_e PegaUInt32(ref UInt32 numeroUInt32, string mensagem)
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
                    MostraMensagem("Erro: " + e.Message);
                    retorno = Resultado_e.Excecao;
                }
            } while (retorno == Resultado_e.Excecao);
            Console.Clear();
            return retorno;
        }

        BaseDeDados baseDeDados;

        public InterfaceGrafica(BaseDeDados baseDeDados)
        {
            this.baseDeDados = baseDeDados;
        }

        public void ImprimeDadosNaTela(CadastroPessoa pPessoa)
        {
            Console.WriteLine("Nome: " + pPessoa.Nome);
            Console.WriteLine("CPF: " + pPessoa.Cpf);
            Console.WriteLine("Data de Nascimento: " + pPessoa.DataDeNascimento);
            Console.WriteLine("Nome da Rua: " + pPessoa.NomeDaRua);
            Console.WriteLine("Número da Casa: " + pPessoa.NumeroDaCasa);
            Console.WriteLine();
        }

        public void ImprimeDadosNaTela(List<CadastroPessoa> pListaPessoas)
        {
            foreach (CadastroPessoa pessoa in pListaPessoas)
            {
                ImprimeDadosNaTela(pessoa);
            }
        }

        public Resultado_e CadastraUsuario()
        {
            Console.Clear();
            string Nome = "";
            string Cpf = "";
            DateTime DataDeNascimento = new DateTime();
            string NomeDaRua = "";
            UInt32 NumeroDaCasa = 0;

            if (PegaString(ref Nome, "Digite o nome do usuário ou S para sair:") == Resultado_e.Sair)
                return Resultado_e.Sair;
            if (PegaString(ref Cpf, "Digite o número do documento do usuário ou S para sair:") == Resultado_e.Sair)
                return Resultado_e.Sair;
            if (PegaData(ref DataDeNascimento, "Digite a data de nascimento no formato DD/MM/AAAA ou S para sair:") == Resultado_e.Sair)
                return Resultado_e.Sair;
            if (PegaString(ref NomeDaRua, "Digite o nome da rua do usuário ou S para sair:") == Resultado_e.Sair)
                return Resultado_e.Sair;
            if (PegaUInt32(ref NumeroDaCasa, "Digite o número da casa do usuário ou S para sair:") == Resultado_e.Sair)
                return Resultado_e.Sair;

            CadastroPessoa cadastroUsuario = new CadastroPessoa(Nome, Cpf, DataDeNascimento.ToString(), NomeDaRua, NumeroDaCasa);
            baseDeDados.AdicionarPessoa(cadastroUsuario);
            Console.Clear();
            Console.WriteLine("Adicionando usuário: ");
            ImprimeDadosNaTela(cadastroUsuario);
            MostraMensagem("");
            return Resultado_e.Sucesso;
        }

        public void BuscaUsuario()
        {
            Console.Clear();
            Console.WriteLine("Digite o Cpf do usuário que deseja buscar ou digite s para sair");
            string temp = Console.ReadLine();
            if (temp.ToLower() == "s")
                return;

            List<CadastroPessoa> listaPessoasTemp = baseDeDados.PesquisaPessoaPorCpf(temp);
            Console.Clear();
            if (listaPessoasTemp != null)
            {
                Console.WriteLine("Usuário(s) encontrado(s):");
                ImprimeDadosNaTela(listaPessoasTemp);
            }
            else
            {
                Console.WriteLine("Nenhum usuário encontrado com o Cpf: " + temp);
                MostraMensagem("");
            }
        }

        public void RemoveUsuario()
        {
            Console.Clear();
            Console.WriteLine("Digite o Cpf do usuário que deseja remover ou digite s para sair");
            string temp = Console.ReadLine();

            if (temp.ToLower() == "s")
                return;
            Console.WriteLine("Deseja remover todos os usuários com o Cpf " + temp + "? (S/N)");
            string temp2 = Console.ReadLine();
            if (temp2.ToLower() == "s")
            {
                List<CadastroPessoa> listaPessoasTemp = baseDeDados.RemoverPessoaPorCpf(temp);
                Console.Clear();
                if (listaPessoasTemp != null)
                {
                    Console.WriteLine("Usuário(s) encontrado(s) com o Cpf " + temp + " removido(s)");
                    ImprimeDadosNaTela(listaPessoasTemp);
                    MostraMensagem("");
                }
                else
                {
                    Console.WriteLine("Nenhum usuário encontrado com o Cpf: " + temp);
                    MostraMensagem("");
                }
                return;
            }
            else if(temp2.ToLower() == "n")
            {
                Console.WriteLine("Remoção cancelada");
                MostraMensagem("");
                return;
            }
            else
            {
                Console.WriteLine("Opção desconhecida");
                MostraMensagem("");
                return;
            }
        }
        public void Sair()
        {
            Console.Clear();
            MostraMensagem("Saindo...");
        }

        public void OpcaoDesconhecida()
        {
            Console.Clear();
            MostraMensagem("Opção desconhecida");
        }

        public void IniciaInterface()
        {
            string temp;
            do
            {
                Console.WriteLine("Pressione C para cadastrar um novo usuário");
                Console.WriteLine("Pressione B para buscar um usuário pelo Cpf");
                Console.WriteLine("Pressione E para excluir um usuário pelo Cpf");
                Console.WriteLine("Pressione S para sair");
                temp = Console.ReadKey(true).KeyChar.ToString().ToLower();
                switch (temp)
                {
                    case "c":
                        if (CadastraUsuario() == Resultado_e.Sair)
                            return;
                        break;
                    case "b":
                        BuscaUsuario();
                        break;
                    case "e":
                        RemoveUsuario();
                        break;
                    case "s":
                        Sair();
                        break;
                    default:
                        OpcaoDesconhecida();
                        break;
                }

            } while (temp != "s");
        }
    }
}
