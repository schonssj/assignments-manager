# Assignments Manager API - API de Gerenciamento de Tarefas. #

## O que é? ##
Esta é uma API RESTful tematizada pelo gerenciamento de tarefas. Ela foi escrita com a linguagem C#, utilizando a plataforma .NET Core. Seu armazenamento de dados é feito em um banco de dados relacional, utilizando o SQL Server. Toda esta tecnologia está hospedada na Microsoft Azure.

## Como foi pensada? ##
A estrutura da solução foi **embasada** nos conceitos arguidos pela Clean Architecture, onde foram elencadas 4 camadas a isolarem as responsabilidades da aplicação em seus devidos contextos, sendo elas:

A **Infra**, cuja sustenta o sistema com os seus repositórios e trata de conversar com o banco de dados.
O **Core**, que é o núcleo, a essência. Lá estão as entidades que desvencilham as regras presentes no sistema. 
A **Application**, responsável por intermediar a comunicação entre o que a API deseja e o que o Core tem para oferecer.
E a **API**, que é exposta ao consumidor; onde se pode entender o seu propósito.
