using System;
using Moq;
using NUnit.Framework;
using ToDo.Dominio.Entities;

namespace ToDo.TesteDeUnidade
{
    public class TodoTeste
    {
        private const string _tipoValido = "Desenvolvimento";
        private const string _descricaoValida = "Descricao valida";

        private const string _tituloValido = "Titulo";

        private DateTime _dataCriacaoValida = new DateTime(2019, 6, 11);

        [Test]
        public void Deve_criar_um_todo_com_titulo()
        {
            //Arrange
            string retornoTitulo = "Compras";
            //Act
            var todo = new Todo(retornoTitulo, _descricaoValida, _tipoValido, _dataCriacaoValida);
            //Assert
            Assert.AreEqual(retornoTitulo, todo.Titulo);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void Deve_Lancar_Excecao_Com_Mensagem_Quando_Titulo_Nao_Estiver_Preenchido(string tituloNaoPreenchido)
        {
            //Arrange
            var messageEsperada = "Titulo obrigatorio";
            //Act
            TestDelegate act = () => { var todo = new Todo(tituloNaoPreenchido, _descricaoValida, _tipoValido, _dataCriacaoValida); };

            //Assert
            var message = Assert.Throws<ArgumentNullException>(act).Message;

            Assert.IsTrue(message.Contains(messageEsperada));
        }

        [Test]
        public void Deve_criar_um_todo_com_descricao()
        {
            //Arrange
            var descricaoEsperada = "Comprar whey";
            //Act
            var todo = new Todo("Compras", "Comprar whey", _tipoValido, _dataCriacaoValida);
            //Assert
            Assert.AreEqual(descricaoEsperada, todo.Descricao);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void Deve_Lancar_Excecao_Com_Mensagem_Quando_Descricao_Nao_Estiver_Preenchida(string descricaoNaoPreenchida)
        {
            //Arrange
            const string titulo = "compras";
            const string mensagemEsperada = "Descricao obrigatoria";
            //Act
            TestDelegate act = () => { var todo = new Todo(titulo, descricaoNaoPreenchida, _tipoValido, _dataCriacaoValida); };

            //Assert
            var message = Assert.Throws<ArgumentNullException>(act).Message;
            Assert.IsTrue(message.Contains(mensagemEsperada));
        }

        [TestCase("Desenvolvimento")]
        [TestCase("Atendimento")]
        [TestCase("Manutenção")]
        [TestCase("Manutenção urgente")]
        public void Deve_Criar_Um_Todo_Com_tipo_valido(string tipoValido)
        {
            //Arrange
            const string tituloPreenchido = "Treinar";
            const string descricaoPreenchida = "Treinar crossfit";
            //Act
            var todo = new Todo(tituloPreenchido, descricaoPreenchida, tipoValido, _dataCriacaoValida);
            //Assert
            Assert.AreEqual(tipoValido, todo.Tipo);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase("Batata doce")]
        public void Deve_Lancar_Excecao_Com_Mensagem_Quando_Tipo_Quando_Invalido(string tipo)
        {
            //Arrange
            var mensagemEsperada = "Tipo invalido";

            //Act
            TestDelegate act = () => { var todo = new Todo(_tituloValido, _descricaoValida, tipo, _dataCriacaoValida); };

            //Assert
            var mensagem = Assert.Throws<ArgumentException>(act).Message;
            Assert.IsTrue(mensagem.Contains(mensagemEsperada));
        }

        [Test]
        public void Deve_Lancar_Excecao_Quando_Tipo_Manutencao_Urgente_For_Criado_Apos_Treze_Horas_As_Sextas_Feiras()
        {
            //Arrange
            var tipo = "Manutenção urgente";
            var mensagemEsperada = "Não é possível criar manutenções urgentes após as 13h nas sextas";
            var dataSextaDepoisDasTreze = new DateTime(2019, 6, 7, 13, 10, 0);

            //Act
            TestDelegate code = () => new Todo(_tituloValido, _descricaoValida, tipo, dataSextaDepoisDasTreze);
            //Assert
            var mensagemExcecao = Assert.Throws<ArgumentException>(code).Message;

            Assert.AreEqual(mensagemEsperada, mensagemExcecao);
        }

        [Test]
        public void Deve_Criar_Um_Todo_Nao_Concluido()
        {
            //Act
            var todo = new Todo(_tituloValido, _descricaoValida, _tipoValido, _dataCriacaoValida);

            //Assert
            Assert.IsFalse(todo.Concluido);
        }

        [Test]
        public void Deve_Marcar_Todo_Para_Concluido()
        {
            //Arrange
            var todo = new Todo(_tituloValido, _descricaoValida, _tipoValido, _dataCriacaoValida);

            //Act
            todo.MarcarTodoComoConcluido();

            //Assert
            Assert.IsTrue(todo.Concluido);
        }

        [Test]
        public void Deve_Desmarcar_Todo_Para_Nao_Concluido()
        {
            //Arrange
            var todo = new Todo(_tituloValido, _descricaoValida, _tipoValido, _dataCriacaoValida);
            todo.MarcarTodoComoConcluido();

            //Act
            todo.MarcarTodoComoNaoConcluido();

            //Assert
            Assert.IsFalse(todo.Concluido);
        }

        [TestCase("Atendimento")]
        [TestCase("Manutenção urgente")]
        public void Nao_Deve_Concluir_Todo_De_Atendimento_E_Manutencao_Urgente_Se_Descricao_Com_Menos_50_Caracteres(string tipo)
        {
            //Arrange
            var descricao = "Descricao valida com menos de 50 caracteres.";
            var todo = new Todo(_tituloValido, descricao, tipo, _dataCriacaoValida);

            //Act
            TestDelegate code = () => { todo.MarcarTodoComoConcluido(); };

            //Assert
            Assert.Throws<Exception>(code);
        }


    }
}