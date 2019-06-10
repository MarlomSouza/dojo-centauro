using System;

namespace ToDo.Dominio
{
    public class DataAtual : Data
    {
        public override DateTime UtcNow
        {
            get { return DateTime.UtcNow; }
        }
    }
}