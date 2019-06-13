## ToDo - DOJO

![](https://i.imgur.com/OvMZBs9.jpg)

- Possibilidade de criar um ToDo contendo um título, descrição e tipo;
- Listar os ToDo em aberto;
- Marcar e desmarcar os ToDo como concluídos;
- Listar os ToDo concluídos;
- Editar o título, descrição e tipo de uma ToDo;
- Remover um ToDo.

# Regras de negócio
- Os tipos de ToDo podem ser: Desenvolvimento, Atendimento, Manutenção e Manutenção urgente;

- ToDo de manutenção urgente não podem ser removidas, apenas concluído;

- ToDo de atendimento e manutenção urgente não podem ser concluído se a descrição estiver preenchida com menos de 50 caracteres válidos;

- Manutenções urgentes não podem ser criadas (nem via edição) após as 13:00 das sextas-feiras.
