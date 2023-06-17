using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace CadastroUsuario
{
    [DataContract]
    internal class CadastroPessoa
    {
        [DataMember]
        private string nome;
        [DataMember]
        private string cpf;
        [DataMember]
        private string dataDeNascimento;
        [DataMember]
        private string nomeDaRua;
        [DataMember]
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
