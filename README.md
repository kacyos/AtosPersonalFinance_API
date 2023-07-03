<h1 align="center">AtosPersonalFinance_API</h1>

<p align="center">
  <img alt="Principal linguagem do projeto" src="https://img.shields.io/github/languages/top/kacyos/atospersonalfinance_api?color=56BEB8">

  <img alt="Quantidade de linguagens utilizadas" src="https://img.shields.io/github/languages/count/kacyos/atospersonalfinance_api?color=56BEB8">

  <img alt="Tamanho do repositório" src="https://img.shields.io/github/repo-size/kacyos/atospersonalfinance_api?color=56BEB8">

  <img alt="Licença" src="https://img.shields.io/github/license/kacyos/atospersonalfinance_api?color=56BEB8">
</p>

<!-- Status -->

<!-- <h4 align="center">
	🚧  AtosPersonalFinance_API 🚀 Em construção...  🚧
</h4>

<hr> -->

<p align="center">
  <a href="#dart-sobre">Sobre</a> &#xa0; | &#xa0;  
  <a href="#rocket-tecnologias">Tecnologias</a> &#xa0; | &#xa0;
  <a href="#white_check_mark-pré-requisitos">Pré requisitos</a> &#xa0; | &#xa0;
  <a href="#checkered_flag-começando">Começando</a> &#xa0; | &#xa0;
  <a href="#memo-licença">Licença</a> &#xa0; | &#xa0;
  <a href="https://github.com/kacyos" target="_blank">Autor</a>
</p>

<br>

## :dart: Sobre

API de controle financeiro pessoal.

## :rocket: Tecnologias

Ferramenta usada na construção do projeto:

- [ASP.NET Core](https://dotnet.microsoft.com/pt-br/apps/aspnet)

## :white_check_mark: Pré requisitos

Antes de começar :checkered_flag:, você precisa ter o [.Net 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) e o [Sql Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) instalados em sua maquina.

## :checkered_flag: Começando

```bash
# Clone este repositório
$ git clone https://github.com/kacyos/atospersonalfinance_api

# Entre na pasta
$ cd atospersonalfinance_api

# Restaure as dependências do projeto
$ dotnet restore

# Para iniciar o projeto
$ dotnet run

# O app vai inicializar em <http://localhost:5029>

# Documentação <https://localhost:7254/swagger/index.html>
```

## :dart: Rotas

### Transações

- `GET /transaction/list-all?user_id={user_id}`: Retorna todas as transações do usuário com o ID fornecido.
- `POST /transaction/create?user_id={user_id}`: Cria uma nova transação para o usuário com o ID fornecido. Os detalhes da transação devem ser fornecidos no corpo da solicitação no formato JSON.
- `GET /transaction/last-seven-days?user_id={user_id}`: Retorna as transações dos últimos sete dias para o usuário com o ID fornecido.
- `GET /transaction/group-by-date?user_id={user_id}&number_of_days={number_of_days}`: Retorna as transações agrupadas por data para o usuário com o ID fornecido. O número de dias para a consulta é opcional.
- `HTTP PATCH /transaction/update?transaction_id={transaction_id}`: Atualiza uma transação com o ID fornecido. Os detalhes da transação atualizada devem ser fornecidos no corpo da solicitação no formato JSON.
- `DELETE /transaction/delete?transaction_id={transaction_id}`: Exclui uma transação com o ID fornecido.
- `GET /transaction/list-by?user_id={user_id}&transaction_type={transaction_type}&category_id={category_id}&initial_date={initial_date}&final_date={final_date}`: Retorna as transações filtradas por tipo, categoria e intervalo de datas para o usuário com o ID fornecido.

### Categorias

- `GET /category/list-all?user_id={user_id}`: Retorna todas as categorias.

### User

- `POST /user/create`: Cria um novo usuário.
- `POST /user/login`: Realiza a autenticação do usuário.

## :memo: Licença

Este projeto está sob licença MIT. Veja o arquivo [LICENSE](LICENSE.md) para mais detalhes.

Feito com :heart: por <a href="https://github.com/kacyos" target="_blank">Cacio de Castro</a>

&#xa0;

<a href="#top">Voltar para o topo</a>
