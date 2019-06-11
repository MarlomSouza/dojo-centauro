using System;

namespace ToDo.Dominio
{
    public abstract class Data
    {
        private static Data _atual;
        static Data() => ResetarDataParaAtual();
        public abstract DateTime UtcNow { get; }
        public static Data Atual
        {
            get { return Data._atual; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Hora inválida");
                Data._atual = value;
            }
        }

        public static void ResetarDataParaAtual() => Data._atual = new DataAtual();
    }


}