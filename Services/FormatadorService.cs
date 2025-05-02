using Formatador_CPF_CNPJ.Entities;

namespace Formatador_CPF_CNPJ.Services
{
    public class FormatadorService
    {
        public Dictionary<string, string> FormatarCpfCnpj(DadosEntrada _dadosEntrada)
        {
            if (_dadosEntrada.Cpf && _dadosEntrada.Cnpj)
                throw new ArgumentException("Declare apenas um dos campos ('cpf' ou 'cnpj') como 'true'.");
            if (!_dadosEntrada.Cpf && !_dadosEntrada.Cnpj)
                throw new ArgumentException("Declare 'cpf' ou 'cnpj' como 'true'.");
            if (_dadosEntrada.Valor == "" || _dadosEntrada.Valor == null)
                throw new ArgumentException("O valor não pode ser vazio ou nulo.");

            if (_dadosEntrada.Cpf)
            {
                Dictionary<string, string> cpfFormatado = [];
                cpfFormatado.Add("cpf", FormatarCpf(_dadosEntrada.Valor));

                return cpfFormatado;
            }
            else
            {
                Dictionary<string, string> cnpjFormatado = [];
                cnpjFormatado.Add("cnpj", FormatarCnpj(_dadosEntrada.Valor));

                return cnpjFormatado;
            }
        }

        public string FormatarCpf(string cpf)
        {
            if (cpf.Length != 11)
                throw new ArgumentException("O CPF deve conter 11 dígitos.");
            return $"{cpf.Substring(0, 3)}.{cpf.Substring(3, 3)}.{cpf.Substring(6, 3)}-{cpf.Substring(9, 2)}";
        }

        public string FormatarCnpj(string cnpj)
        {
            if (cnpj.Length != 14)
                throw new ArgumentException("O CNPJ deve conter 14 dígitos.");
            return $"{cnpj.Substring(0, 2)}.{cnpj.Substring(2, 3)}.{cnpj.Substring(5, 3)}/{cnpj.Substring(8, 4)}-{cnpj.Substring(12, 2)}";
        }
    }
}
