namespace ProgramacaoDoZero.Models
{
    public class Veiculo
    {

        public Veiculo()
        {
            TanqueCombustivel = 40;
        }
        public   string  Cor  { get; set; }

        public   string   Marca  { get; set; }

        public   string  Placa  { get; set; }

        public   string  Modelo { get; set; }

        public   int    TanqueCombustivel { get; set; }


        public virtual void Acelerar()
        {
            InjetarCombustivel(2);
        }

        public void Frear()
        {

        }

        private void InjetarCombustivel(int quantidadeCombustivel)
        {
            TanqueCombustivel = TanqueCombustivel - quantidadeCombustivel;
        }

        
    }
}
