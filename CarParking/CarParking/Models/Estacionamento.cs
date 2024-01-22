using System.Globalization;

namespace CarParking.Models
{
    public class Estacionamento
    {
        // Campos
        private List<Veiculo> _veiculos;
        private double _faturamento;

        // Atributos (propriedades)
        public List<Veiculo> Veiculos { get => _veiculos; set => _veiculos = value; }
        public double Faturamento { get => _faturamento; set => _faturamento = value; }

        // Construtor
        public Estacionamento()
        {
            _veiculos = new List<Veiculo>();
            Faturamento = 0;
        }

        // Métodos
        public void RegistrarEntrada(Veiculo veiculo)
        {
            veiculo.HoraEntrada = DateTime.Now;
            Veiculos.Add(veiculo);
            System.Console.WriteLine("Veículo registrado com sucesso!");
        }

        public void RegistrarSaida(string placa)
        {
            Veiculo veiculoProcurado = null;
            string informacao = null;
            foreach (Veiculo v in Veiculos)
            {
                if (v.Placa == placa.ToUpper())
                {
                    v.HoraSaida = DateTime.Now;
                    TimeSpan tempoPermanencia = v.HoraSaida - v.HoraEntrada;
                    double valorCobrado = 0;
                    if (v.Tipo == TipoVeiculo.Motocicleta)
                    {
                        /// o método Math.Ceiling() aplica o conceito de teto da matemática onde o valor máximo é o inteiro imediatamente posterior a ele.
                        /// Ex.: 0,9999 ou 0,0001 teto = 1
                        /// Obs.: o conceito de chão é inverso e podemos utilizar Math.Floor();
                        valorCobrado = 5 + (Math.Ceiling(tempoPermanencia.TotalHours) * 5);
                    }
                    else if (v.Tipo == TipoVeiculo.Carro)
                    {
                        valorCobrado = 10 + (Math.Ceiling(tempoPermanencia.TotalHours) * 5);
                    }
                    else
                    {
                        valorCobrado = 15 + (Math.Ceiling(tempoPermanencia.TotalHours) * 8);
                    }
                    informacao = $"\nHora de entrada: {v.HoraEntrada}\n" +
                                        $"Hora de saída: {v.HoraSaida}\n" +
                                        $"Permanência: {tempoPermanencia}\n" +
                                        $"Valor total: {valorCobrado.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"))}\n";

                    veiculoProcurado = v;
                    Faturamento += valorCobrado;
                    break;
                }
            }
            if (veiculoProcurado != null)
            {
                Veiculos.Remove(veiculoProcurado);
                System.Console.WriteLine(informacao);
            }
            else
            {
                Console.WriteLine("Veículo não encontrado com a placa informada");
            }
        }

        public void ExibirFaturamento()
        {
            Console.WriteLine($"\nTotal faturado até o momento: {Faturamento.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"))}");
        }

        public Veiculo LocalizaVeiculo(string placa)
        {
            Veiculo? encontrado = Veiculos.Where(v => v.Placa == placa).FirstOrDefault();

            return encontrado;
        }

        public Veiculo AlterarDadosVeiculo(Veiculo veiculoAlterado)
        {
            Veiculo? temp = Veiculos.Where(v => v.Placa == veiculoAlterado.Placa).FirstOrDefault();

            if (temp == null)
            {
                throw new Exception($"Veiculo com a placa {veiculoAlterado.Placa} não encontrado");
            }

            temp.AlterarDados(veiculoAlterado);

            return temp;
        }
    }
}