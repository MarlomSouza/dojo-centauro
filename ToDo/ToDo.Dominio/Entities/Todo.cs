using System;
using System.Linq;

namespace ToDo.Dominio.Entities
{
    public class Todo
    {
        public string Titulo { get; private set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public bool Concluido { get; private set;}
        private string[] _tipoValidos = { "Desenvolvimento", "Atendimento", "Manutenção", "Manutenção urgente" };

        private const int _limiteCaracter = 50;

        public bool Aberto { get; private set; }

        public Todo(string titulo, string descricao, string tipo, DateTime dataCriacao)
        {
            ValidarConstrucao(titulo, descricao, tipo, dataCriacao);

            Titulo = titulo;
            Descricao = descricao;
            Tipo = tipo;
            Aberto = true;
        }

        private void ValidarConstrucao(string titulo, string descricao, string tipo, DateTime dataCriacao)
        {
            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentNullException("Titulo obrigatorio");

            if (string.IsNullOrWhiteSpace(descricao))
                throw new ArgumentNullException("Descricao obrigatoria");

            if (string.IsNullOrWhiteSpace(tipo) || !_tipoValidos.Contains(tipo))
                throw new ArgumentException("Tipo invalido");

            var ehSextaApos13 = dataCriacao.DayOfWeek == DayOfWeek.Friday && dataCriacao.Hour >= 13 && dataCriacao.Minute > 0;
            if (tipo.Equals("Manutenção urgente") && ehSextaApos13)
            {
                throw new ArgumentException("Não é possível criar manutenções urgentes após as 13h nas sextas");
            }
        }

        public void MarcarTodoComoConcluido(){
            
            if((Tipo == "Atendimento" || Tipo == "Manutenção urgente") && Descricao.Trim().Length < _limiteCaracter){
                throw new Exception();
            }
            Concluido = true;
            Aberto = false;
        }

        public void MarcarTodoComoNaoConcluido()
        {
            Concluido = false;
            Aberto = true;
        }
    }
}