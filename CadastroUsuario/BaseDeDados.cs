using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace CadastroUsuario
{
    [DataContract]
    internal class BaseDeDados
    {
        [DataMember]
        private List<CadastroPessoa> listaDePessoas;
        private string caminhoBaseDeDados;

        public void AdicionarPessoa(CadastroPessoa pessoa)
        {
            listaDePessoas.Add(pessoa);
            Serializador.Serializa(caminhoBaseDeDados, this);
        }

        public List<CadastroPessoa> PesquisaPessoaPorCpf(string pCpf)
        {
            List<CadastroPessoa> listaDePessoasTemp = listaDePessoas.Where(x => x.Cpf == pCpf).ToList();
            if (listaDePessoasTemp.Count > 0)
                return listaDePessoasTemp;
            else
                return null;
        }
        public List<CadastroPessoa> RemoverPessoaPorCpf(string pCpf)
        {
            List<CadastroPessoa> listaDePessoasTemp = listaDePessoas.Where(x => x.Cpf == pCpf).ToList();
            if (listaDePessoasTemp.Count > 0)
            {
                foreach (CadastroPessoa pessoa in listaDePessoasTemp)
                {
                    listaDePessoas.Remove(pessoa);
                }
                return listaDePessoasTemp;
            }
            else
                return null;
        }
        public BaseDeDados(string caminhoBaseDeDados)
        {
            this.caminhoBaseDeDados = caminhoBaseDeDados;
            BaseDeDados baseDeDadosTemp = Serializador.Desserializa(caminhoBaseDeDados);
            if(baseDeDadosTemp != null)
                listaDePessoas = baseDeDadosTemp.listaDePessoas;
            else
                listaDePessoas = new List<CadastroPessoa>();
        }
    }
}
