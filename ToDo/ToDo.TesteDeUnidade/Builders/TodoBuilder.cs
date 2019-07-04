using System;
using ToDo.Dominio.Entities;

namespace ToDo.TesteDeUnidade.Builders
{
    public class TodoBuilder
    {
        private string _titulo;
        private string _descricao;
        private string _tipo;
        private DateTime _dataDeCriacao;
        private bool concluido;

        private TodoBuilder()
        {
            _titulo = "Desenvolvimento";
            _descricao = "Descricao valida";
            _tipo = "Desenvolvimento";
            _dataDeCriacao = new DateTime(2019, 6, 11);
        }

        public static TodoBuilder Novo()
        {
            return new TodoBuilder();
        }

        public TodoBuilder ComTitulo(string titulo)
        {
            this._titulo = titulo;
            return this;
        }

        public TodoBuilder ComDescricao(string descricao)
        {
            this._descricao = descricao;
            return this;
        }

        public TodoBuilder ComTipo(string tipo)
        {
            this._tipo = tipo;
            return this;
        }


        public TodoBuilder ComDataDeCriacao(DateTime dataDeCriacao)
        {
            this._dataDeCriacao = dataDeCriacao;
            return this;
        }

        public TodoBuilder Concluido()
        {
            this.concluido = true;
            return this;
        }

        public Todo Build()
        {
            var todo = new Todo(_titulo, _descricao, _tipo, _dataDeCriacao);

            if (concluido)
                todo.MarcarTodoComoConcluido();

            return todo;
        }

    }
}