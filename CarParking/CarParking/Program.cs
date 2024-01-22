using CarParking.Models;

namespace CarParking
{
    class Program
    {
        static Estacionamento estacionamento = new Estacionamento();

        public static void Main(string[] args)
        {
            string opcao = null;
            while (opcao != "5")
            {
                ExibirCabecalho();
                ExibirMenu();
                Console.Write("Opção desejada: ");
                opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        RegistrarEntradaVeiculo();
                        break;
                    case "2":
                        RegistraSaidaVeiculo();
                        break;
                    case "3":
                        estacionamento.ExibirFaturamento();
                        Console.ReadKey();
                        break;
                    case "4":
                        ExibirVeiculosEstacionados();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ExibirCabecalho()
        {
            Console.Clear();
            Console.WriteLine("********** Car Parking - Controle de Estacionamento **********\n");
        }

        static void ExibirMenu()
        {
            Console.WriteLine("Escolha uma opção:\n" +
                                "1 - Registrar entrada\n" +
                                "2 - Registrar saída\n" +
                                "3 - Exibir faturamento\n" +
                                "4 - Exibir veículos estacionados\n" +
                                "5 - Encerrar\n"
                            );
        }

        static void RegistrarEntradaVeiculo()
        {
            Console.Clear();
            Console.WriteLine("Registro de entrada de veículo\n");
            Console.WriteLine("Informe o tipo de veículo:\n" +
                                "1 - Motocicleta\n" +
                                "2 - Carro\n" +
                                "3 - Carro grande\n" +
                                "0 - Voltar\n"
                            );
            Console.Write("Tipo de veículo: ");
            string tipoVeiculo = Console.ReadLine();
            switch (tipoVeiculo)
            {
                case "1":
                    RegistraEntradaMotocicleta();
                    break;
                case "2":
                    RegistraEntradaCarro();
                    break;
                case "3":
                    RegistraEntradaCarroGrande();
                    break;
                case "0":
                    break;
                default:
                    System.Console.WriteLine("Tipo inválido");
                    Console.ReadKey();
                    break;
            }
        }

        static void RegistraEntradaMotocicleta()
        {
            System.Console.WriteLine("\nDados da motocicleta");
            Veiculo motocicleta = new Veiculo();
            motocicleta.Tipo = TipoVeiculo.Motocicleta;
            try
            {
                System.Console.Write("Informe a placa da motocicleta (XXX-9999): ");
                motocicleta.Placa = Console.ReadLine();
                Console.Write("Informe o nome do proprietário: ");
                motocicleta.Proprietario = Console.ReadLine();
                System.Console.Write("Informe a cor: ");
                motocicleta.Cor = Console.ReadLine();
            }
            catch (FormatException fe)
            {
                System.Console.WriteLine($"Ocorreu um erro: {fe.Message}");
                Console.ReadKey();
                return;
            }
            estacionamento.RegistrarEntrada(motocicleta);
            Console.ReadKey();
        }

        static void RegistraEntradaCarro()
        {
            System.Console.WriteLine("\nDados do veículo");
            Veiculo carro = new Veiculo();
            carro.Tipo = TipoVeiculo.Carro;
            try
            {
                System.Console.Write("Informe a placa da motocicleta (XXX-9999): ");
                carro.Placa = Console.ReadLine();
                Console.Write("Informe o nome do proprietário: ");
                carro.Proprietario = Console.ReadLine();
                System.Console.Write("Informe a cor: ");
                carro.Cor = Console.ReadLine();
            }
            catch (FormatException fe)
            {
                System.Console.WriteLine($"Ocorreu um erro: {fe.Message}");
                Console.ReadKey();
                return;
            }
            estacionamento.RegistrarEntrada(carro);
            Console.ReadKey();
        }

        static void RegistraEntradaCarroGrande()
        {
            System.Console.WriteLine("\nDados do veículo");
            Veiculo carroGrande = new Veiculo();
            carroGrande.Tipo = TipoVeiculo.CarroGrande;
            try
            {
                System.Console.Write("Informe a placa da motocicleta (XXX-9999): ");
                carroGrande.Placa = Console.ReadLine();
                Console.Write("Informe o nome do proprietário: ");
                carroGrande.Proprietario = Console.ReadLine();
                System.Console.Write("Informe a cor: ");
                carroGrande.Cor = Console.ReadLine();
            }
            catch (FormatException fe)
            {
                System.Console.WriteLine($"Ocorreu um erro: {fe.Message}");
                Console.ReadKey();
                return;
            }
            estacionamento.RegistrarEntrada(carroGrande);
            Console.ReadKey();
        }

        static void RegistraSaidaVeiculo()
        {
            Console.Clear();
            System.Console.WriteLine("Registro de saída de veículo\n");
            System.Console.Write("Informe a placa do veículo: ");
            string placa = Console.ReadLine();
            estacionamento.RegistrarSaida(placa);
            Console.ReadKey();
        }

        static void ExibirVeiculosEstacionados()
        {
            System.Console.Clear();
            if (estacionamento.Veiculos.Count == 0)
            {
                Console.WriteLine("\nNão há veículos estacionados no momento...");
            }
            else
            {
                System.Console.WriteLine("\nVeículos estacionados\n");
                foreach (Veiculo v in estacionamento.Veiculos)
                {
                    Console.WriteLine($"Placa: {v.Placa}\n" +
                                      $"Proprietário: {v.Proprietario}\n" +
                                      $"Hora de entrada: {v.HoraEntrada}\n"
                                     );
                    Console.WriteLine("--------------------------------------");
                }
                Console.ReadKey();
            }
        }
    }
}