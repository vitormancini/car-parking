/*
 * Criar projeto de testes via CLI:
 * - dotnet new xunit -o nome_projeto_teste
 * - dotnet sln add nome_projeto_teste.csproj
 * - dotnet add nome_projeto_teste.csproj reference nome_projeto.csproj
 * 
 * Executar testes CLI:
 * - dotnet test
 * 
 * Padrão AAA
 * - Arrange: cenário (instaciar classes)
 * - Act: (método a ser executado)
 * - Assert: (valor esperado)
*/

using CarParking.Models;

namespace CarParking.Tests
{
    public class EstacionamentoTest
    {
        [Fact]
        public void ValidaFaturamento()
        {
            // Arrange
            Estacionamento estacionamento = new Estacionamento();
            Veiculo veiculo = new Veiculo();
            veiculo.Placa = "AAA-1111";
            veiculo.Proprietario = "Vitor";
            veiculo.Cor = "Preto";
            veiculo.Tipo = TipoVeiculo.Carro;
            estacionamento.RegistrarEntrada(veiculo);
            estacionamento.RegistrarSaida(veiculo.Placa);

            // Act
            double faturamento = estacionamento.Faturamento;

            // Assert
            Assert.Equal(15, faturamento);
        }

        // Theory permite avaliar várias entradas simultâneamente
        [Theory]
        [InlineData("AAA-1111", "Vitor", "Preto", TipoVeiculo.Carro)]
        [InlineData("BBB-2222", "Lucas", "Azul", TipoVeiculo.Carro)]
        [InlineData("AA-3333", "João", "Prata", TipoVeiculo.Carro)] // Falha
        [InlineData("CCC-4444", "Maria", "Branco", TipoVeiculo.Carro)] // Falha
        public void ValidaFaturamentoMultiplo(string placa, string proprietario, string cor, TipoVeiculo tipo)
        {
            // Arrange
            Estacionamento estacionamento = new Estacionamento();
            Veiculo veiculo = new Veiculo();
            veiculo.Placa = placa;
            veiculo.Proprietario = proprietario;
            veiculo.Cor = cor;
            veiculo.Tipo = tipo;
            estacionamento.RegistrarEntrada(veiculo);
            estacionamento.RegistrarSaida(veiculo.Placa);

            // Act
            double faturamento = estacionamento.Faturamento;

            // Assert
            Assert.Equal(15, faturamento);
        }

        // Podemos ignorar um teste, caso não esteja pronto ainda, por exemplo
        [Fact(Skip = "Teste não implementado. Ignorar...")]
        public void ValidaNomeProprietario()
        {

        }

        // Escrita do teste antes da implementação do método (TDD)
        [Theory]
        [InlineData("Vitor", "AAA-1111", "Preto")]
        public void LocalizaVeiculoEstacionado(string proprietario, string placa, string cor)
        {
            Estacionamento estacionamento = new Estacionamento();
            Veiculo veiculo = new Veiculo();

            veiculo.Placa = placa;
            veiculo.Proprietario= proprietario;
            veiculo.Cor = cor;

            estacionamento.RegistrarEntrada(veiculo);

            var consulta = estacionamento.LocalizaVeiculo(placa); // Método ainda não existente. Teste criado primeiro

            Assert.Equal(placa, consulta.Placa);
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

            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }
    }
}