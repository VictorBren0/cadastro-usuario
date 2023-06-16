using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuario
{
    internal class CadastroPessoa
    {
        private string nome;
        private string cpf;
        private string dataDeNascimento;
        private string nomeDaRua;
        private UInt32 numeroDaCasa;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }
        public string DataDeNascimento
        {
            get { return dataDeNascimento; }
            set { dataDeNascimento = value; }
        }
        public string NomeDaRua
        {
            get { return nomeDaRua; }
            set { nomeDaRua = value; }
        }
        public UInt32 NumeroDaCasa
        {
            get { return numeroDaCasa; }
            set { numeroDaCasa = value; }
        }

        public CadastroPessoa(string nome, string cpf, string dataDeNascimento, string nomeDaRua, UInt32 numeroDaCasa)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.dataDeNascimento = dataDeNascimento;
            this.nomeDaRua = nomeDaRua;
            this.numeroDaCasa = numeroDaCasa;
        }
    }
}
