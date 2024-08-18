namespace ProgramacaoDoZero.Models
{
    public class Moto : Veiculo
    {
        public Moto()
        {
            QuantidadeRodas = 2;
            
            TanqueCombustivel = 15;
        }

        public override void Acelerar()
        {
            InjetarCombustivel(1);
        }
        public void InjetarCombustivel(int QuantidadeRodas)
        {
            base.TanqueCombustivel = base.TanqueCombustivel - QuantidadeRodas;
        }

        public int  QuantidadeRodas { get; set; }

    }      
}
