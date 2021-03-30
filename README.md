# Assignments Manager API - API de Gerenciamento de Tarefas. #

## O que é? ##
Esta é uma API RESTful tematizada pelo gerenciamento de tarefas. Ela foi escrita com a linguagem C#, utilizando a plataforma .NET Core. Seu armazenamento de dados é feito em um banco de dados relacional, utilizando o SQL Server. Toda esta tecnologia está hospedada na Microsoft Azure.

## Como foi pensada? ##
A estrutura da solução foi **embasada** nos conceitos arguidos pela Clean Architecture (MARTIN, 2017), onde foram elencadas 4 camadas a isolarem as responsabilidades da aplicação em seus devidos contextos, sendo elas:

A **Infra**, cuja sustenta o sistema com os seus repositórios e trata de conversar com o banco de dados.
O **Core**, que é o núcleo, a essência. Lá estão as entidades que desvencilham as regras presentes no sistema. 
A **Application**, responsável por intermediar a comunicação entre o que a API deseja e o que o Core tem para oferecer.
E a **API**, que é exposta ao consumidor; onde se pode entender o seu propósito.

Para entender como o desenvolvimento é orquestrado num gerenciador de atividades, acesse [este link](https://trello.com/invite/b/ZBsz5V2n/28648543c2bbda854ead91b37b1fb2c3/assignments-manager-api-board).

## Como testar? ##
Para testar a API publicada, acesse [este link](https://assignmentsmanagerapi20210322090832.azurewebsites.net/swagger/index.html). Nele, você encontrará uma interface apta à testar os métodos de consulta, adição, edição e remoção de dados na API.

Para executar os métodos, deve-se clicar sobre um exemplar desejado, em seguida em *Try it out* e então em *Execute*. Quando necessário, como num método POST, deverá ser informado o corpo de requisição no formato JSON.

Na seção *responses*, estão elencados os possíveis tipos de retorno que a chamada do método pode oferecer.

## ... Tem mais? ##
É de todo saber que um software pende ao infindável – pelo menos, em sua grande maioria.
A lista abaixo nos fornece um spoiler do que está por vir:
- Criação de testes unitários para todas as camadas;
- Criação de logs para todas as camadas;
- Criação de sistema de autenticação do usuário.
---
