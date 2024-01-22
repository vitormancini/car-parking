namespace CarParking.Models
{
    public class Veiculo
    {
        // Campos
        private string _placa;
        private string _proprietario;
        private TipoVeiculo _tipoVeiculo;
        private string _cor;

        // Atributos (propriedades)
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSaida { get; set; }
        public TipoVeiculo Tipo { get => _tipoVeiculo; set => _tipoVeiculo = value; }
        public string Cor
        {
            get
            {
                return _cor;
            }
            set
            {
                // Verifica se cor possui numeros
                for (int i = 0; i < value.Length; i++)
                {
                    if (char.IsDigit(value[i]))
                    {
                        throw new FormatException("Cor deve conter apenas letras");
                    }
                }
                // Veirifica se cor possui possui pelo menos 4 letras
                if (value.Length < 4)
                {
                    throw new FormatException("Cor deve conter pelo menos 3 letras");
                }

                _cor = value;
            }
        }
        public string Proprietario
        {
            get
            {
                return _proprietario;
            }
            set
            {
                // Verifica se o nome possui algum valor numérico
                for (int i = 0; i < value.Length; i++)
                {
                    if (char.IsDigit(value[i]))
                    {
                        throw new FormatException("Nome do proprietário deve conter apenas letras");
                    }
                }
                // Verifica se nome possui pelo menos 3 letras
                if (value.Length < 3)
                {
                    throw new FormatException("Nome do proprietário deve conter pelo menos 3 letras");
                }
                _proprietario = value;
            }
        }

        public string Placa
        {
            get
            {
                return _placa;
            }
            set
            {
                // Verifica se o valor informado possui 8 caracteres
                if (value.Length != 8)
                {
                    throw new FormatException("Placa inválida. Placa deve possuir 8 caracteres");
                }
                // Verifica se os 3 primeiros dígitos são letras
                for (int i = 0; i < 3; i++)
                {
                    if (char.IsDigit(value[i]))
                    {
                        throw new FormatException("Placa inválida. Os 3 primeiros caracteres devem ser letras");
                    }
                }
                // Verifica se possui hífen
                if (value[3] != '-')
                {
                    throw new FormatException("Placa inválida. O 4° caractere deve ser um hífen");
                }
                // verifica se os 4 últimos caracteres são números
                for (int i = 4; i < 8; i++)
                {
                    if (!char.IsDigit(value[i]))
                    {
                        throw new FormatException("Placa inválida. Os 4 últimos caracteres devem ser numéricos");
                    }
                }
                _placa = value.ToUpper();
            }
        }

        public void AlterarDados(Veiculo veiculoAlterado)
        {
            Proprietario = veiculoAlterado.Proprietario;
            Placa = veiculoAlterado.Placa;
            Cor = veiculoAlterado.Cor;
        }
    }
}