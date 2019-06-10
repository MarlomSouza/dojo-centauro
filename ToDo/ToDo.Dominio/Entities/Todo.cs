using System;
using System.Linq;

namespace ToDo.Dominio.Entities
{
    public class Todo
    {
        public string Titulo { get; private set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }

        private string[] _tipoValidos = {"Desenvolvimento", "Atendimento", "Manutenção", "Manutenção urgente"};

        public Todo(string titulo, string descricao, string tipo)
        {

            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentNullException("Titulo obrigatorio");
                
            if (string.IsNullOrWhiteSpace(descricao))
                throw new ArgumentNullException("Descricao obrigatoria");

            if (string.IsNullOrWhiteSpace(tipo) || !_tipoValidos.Contains(tipo))
                throw new ArgumentException("Tipo invalido");

            if(Data.Atual.UtcNow.DayOfWeek == DayOfWeek.Friday && Data.Atual.UtcNow.Hour >= 13)
                throw new ArgumentException("Todo sexta inválido");
            
            Titulo = titulo;
            Descricao = descricao;
            Tipo = tipo;
            
        }
    }

}