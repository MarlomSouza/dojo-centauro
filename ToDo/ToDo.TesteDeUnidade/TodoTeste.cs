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

        [Test]
        public void Deve_criar_um_todo_com_titulo()
        {
            //Arrange
            string retornoTitulo = "Compras";
            //Act
            var todo = new Todo(retornoTitulo, _descricaoValida, _tipoValido);
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
            TestDelegate act = () => { var todo = new Todo(tituloNaoPreenchido, _descricaoValida, _tipoValido); };

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
            var todo = new Todo("Compras", "Comprar whey", _tipoValido);
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
            TestDelegate act = () => { var todo = new Todo(titulo, descricaoNaoPreenchida, _tipoValido); };
            
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
            var todo = new Todo(tituloPreenchido, descricaoPreenchida, tipoValido);
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
            TestDelegate act = () => { var todo = new Todo(_tituloValido, _descricaoValida, tipo);};
            
            //Assert
            var mensagem = Assert.Throws<ArgumentException>(act).Message;
            Assert.IsTrue(mensagem.Contains(mensagemEsperada));
        }

        [Test]
        public void Deve_Lancar_Excecao_Quando_Tipo_Manutencao_Urgente_For_Criado_Apos_Treze_Horas_As_Sextas_Feiras()
        {
            //Arrange
            
            //Act
            
            //Assert
            Assert.IsTrue(mensagemEsperada )
        }

    }
}