using CarParking.Models;
using Xunit.Abstractions;

namespace CarParking.Tests
{
    public class VeiculoTest
    {

        public ITestOutputHelper _saidaConsole; // Permite que escrevemos mensagens no console

        public VeiculoTest(ITestOutputHelper saidaConsole)
        {
            _saidaConsole = saidaConsole;
            _saidaConsole.WriteLine("Testando console...");
        }

        // Escrita do teste antes da implementação do método (TDD)
        [Fact]
        public void ValidaAlterarDadosVeiculo()
        {
            Estacionamento estacionamento = new Estacionamento();

            Veiculo veiculo = new Veiculo();
            veiculo.Placa = "AAA-1111";
            veiculo.Proprietario = "Vitor";
            veiculo.Cor = "Preto";
            estacionamento.RegistrarEntrada(veiculo);

            Veiculo veiculoAlterado = new Veiculo();
            veiculoAlterado.Placa = "AAA-1111";
            veiculoAlterado.Proprietario = "Vitor";
            veiculoAlterado.Cor = "Azul"; // Alteração

            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado); // Método ainda não existente. Teste criado primeiro

            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }

        // Contains
        [Fact]
        public void ValidaFichaVeiculo()
        {
            Veiculo veiculo = new Veiculo();
            veiculo.Placa = "AAA-1111";
            veiculo.Proprietario = "Vitor";
            veiculo.Cor = "Preto";

            string ficha = veiculo.ToString();

            Assert.Contains("Ficha do veiculo", ficha);
        }

        // Teste de exceção
        [Fact]
        public void ValidaExceçãoNomeProprietario()
        {
            // Arrange
            string nomeProprietario = "Vit3r56";

            Veiculo veiculo = new Veiculo();

            // Assert                                     // Act
            Assert.Throws<System.FormatException>( () => veiculo.Proprietario = nomeProprietario);
        }

        // Teste de exceção
        [Fact]
        public void ValidaExceçãoPlacaVeiculo()
        {
            // Arrange
            string placaVeiculo = "aaa3412";

            Veiculo veiculo = new Veiculo();

            // Assert                                     // Act
            Assert.Throws<System.FormatException>(() => veiculo.Placa = placaVeiculo);
        }
    }
}
