using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuario
{
    internal class BaseDeDados
    {
        private List<CadastroPessoa> listaDePessoas;

        public void AdicionarPessoa(CadastroPessoa pessoa)
        {
            listaDePessoas.Add(pessoa);
        }

        public List<CadastroPessoa> PesquisaPessoaPorCpf(string pCpf)
        {
            List<CadastroPessoa> listaDePessoasTemp = listaDePessoas.Where(x => x.Cpf == pCpf).ToList();
            if(listaDePessoasTemp.Count > 0)
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
        public BaseDeDados()
        {
            listaDePessoas = new List<CadastroPessoa>();
        }
    }
}
