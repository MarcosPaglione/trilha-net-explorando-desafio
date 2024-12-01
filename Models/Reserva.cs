using System.ComponentModel;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // OK: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                // OK: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                throw new Exception("Capacidade da Suite é MENOR do que a quantidade de HOSPEDES");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // OK: Retorna a quantidade de hóspedes (propriedade Hospedes)
            int quant = Hospedes.Count; 
            return quant;
        }

        public decimal CalcularValorDiaria()
        {
            // OK: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            decimal valor = 0;
            try
            { 
                valor = Suite.ValorDiaria * Convert.ToDecimal(DiasReservados); 
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Nao foi possivel realizar a conversao {ex}");
            }
            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            if (DiasReservados >= 10)
            {
                decimal desconto = valor * 0.1M; 
                valor = valor - desconto;
            }

            return valor;
        }
    }
}