using System;
using Moq;
using NUnit.Framework;
using ToDo.Dominio.Entities;

namespace ToDo.TesteDeUnidade
{
    public class TodoTeste
    {
        private const string _tipoValido = "Manutenção urgente";
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
            var mensagemEsperada = "Não é possível criar manutenções urgentes após as 13h nas sextas";
            var dataSextaDepoisDasTreze = new DateTime(2019, 6, 7, 13, 10, 0);

            //Act
            TestDelegate code = () => new Todo(_tituloValido, _descricaoValida, _tipoValido, dataSextaDepoisDasTreze);
            //Assert
            var mensagemExcecao = Assert.Throws<ArgumentException>(code).Message;

            Assert.AreEqual(mensagemEsperada, mensagemExcecao);
        }

        [Test]
        public void Deve_Criar_Um_Todo_Com_Estado_Aberto()
        {
            //Arrange
            var estadoEsperado = EstadoToDo.Aberto;

            //Act
            var todo = new Todo(_tituloValido, _descricaoValida, _tipoValido, _dataCriacaoValida);
            
            //Assert
            Assert.AreEqual(estadoEsperado, todo.Estado);
        }

        [Test]
        public void TestName()
        {
            //Arrange
            
            //Act
            
            //Assert
            
        }

    }
}