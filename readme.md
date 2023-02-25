# VarietyStoreAPI e VarietyStoreFront

Este repositório contém dois projetos Visual Studio: `VarietyStoreAPI` e `VarietyStoreFront`. O projeto `VarietyStoreAPI` é uma API criada com Microsoft Entity Framework e SQL Server, com três models chamados `User`, `Product` e `Order`. O projeto `VarietyStoreFront` é um frontend para o serviço da API, que permite listar os produtos, as vendas e editar os produtos disponíveis para venda.

## Configuração

Para rodar o projeto da API, é necessário atualizar a ConnectionString com o server e senha no `appsettings.json`. Talvez seja necessário atualizar as Migrations. Ao clicar em "Rodar", a API abrirá o Swagger e poderá sofrer modificações por ali mesmo.

Para rodar o projeto do frontend, basta abrir o projeto `VarietyStoreFront` e rodá-lo. Ao executar, a página de produtos será exibida, mostrando os produtos obtidos por meio da API. O frontend conta com uma página de vendas, que lista todas as compras registradas, e uma página de administração, que permite a modificação dos produtos disponíveis para venda.

## Tecnologias

- Visual Studio
- Microsoft Entity Framework
- SQL Server
- HTML
- CSS
- JavaScript

## Autor

Este projeto foi desenvolvido por João Victor Ramiro para um Teste de .NET API.
