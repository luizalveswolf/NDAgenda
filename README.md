# ND Agenda Contatos

Projeto Piloto de Uma Agenda de Contatos

Recursos da aplaição
Visual Studio 2015
ASP.NET MVC 5, 
Entityframework 6.1 como fonte de dados,
Castle Windsor como container de inversão de controle,
Padrão Repository.

Agenda praticamente faz um crud de contatos

Foi feita um desacoplamento da api do entityframework do controle de Contatos
atraves de uma Interface que contem a lógica do Crud dos Contatos caso, aja uma mudança de do ORM. 

O ControlerFactory padrão do MVC foi substituido pelo o WindsorControllerFactory para 
que possa reconhecer contrutores com parametros.

A implementados a API para exporlar e listar o ControllerAPI não foi finalizado.
Testes automatizados não foram feitos.
As Views do cadastro de Formularios estão no modo default inicial, seriam posteriormente organizadas assim
como as validações e cascaras das entidades.
