# Projeto de Cadastro de Usuário

📌 Nota: Projeto desenvolvido para fins acadêmicos na disciplina de Advanced Business Development with .NET

Este é um sistema simples desenvolvido em ASP.NET Core MVC para o cadastro e gerenciamento de usuários e das regiões onde residem (cidade e estado), com as regiões sendo armazenadas em uma tabela separada.

A aplicação permite realizar cadastro, listagem, edição e exclusão.

Além disso, conta com um controller de alertas, utilizado para aplicar regras de negócio diretamente no front-end, sem persistência no banco de dados. Ele é responsável por exibir mensagens e notificações dinâmicas com base no comportamento ou nas informações do usuário.

## Integrantes

RM555679 - Lavinia Soo Hyun Park

RM556242 - Giovanna Laturague Bueno

## Funcionalidades

- Cadastro de usuários e regiões
- Dropdown que permite selecionar o estado de uma lista pre-definida
- Integração com banco Oracle utilizando Entity Framework Core
- Documentação da API via Swagger UI

## Interface

Tela Inicial

![Tela inicial](/img/tela-inicial.png)

Tela de Edição (Usuário)

![Edição de Usuário](/img/tela-edicao-usuario.png)

Tela de Informações do Usuário

![Tela de Informaçõs](/img/info-usuario.png)

## Configuração do Ambiente

**IMPORTANTE**

Clone o repositório e cole ele no terminal para poder rodá-lo em sua IDE

### 1. Requisitos

- .NET SDK 8.0 ou superior instalado (https://dotnet.microsoft.com/en-us/download)
- Oracle XE local ou acesso ao banco da sua instituição
- IDE: Visual Studio ou Rider (ou VS Code)

### 2. String de Conexão

No arquivo `appsettings.json`, configure sua conexão Oracle:

```
"ConnectionStrings": {
    "OracleConnection": "User Id=seu_usuario;Password=sua_senha;Data Source=localhost:1521/xe;"
}
```

### 3. Executando o Projeto

1. Restaure os pacotes

```
# Terminal
dotnet restore
```

2. Rode as migrations (importante rodar após configurar a conexão)

```
# Terminal
dotnet ef database update
```

3. Inicie o servidor

```
#Terminal
dotnet run
```

ou clique no play na parte superior da IDE

4. Caso não abra uma aba web automaticamente, acesse o link: http://localhost:5182

### 4. Testando o programa

Para acessar o Swagger, basta digitar a seguinte URL: http://localhost:5182/swagger/index.html

![Swagger UI](/img/tela-swagger.png)

Para avançar para a página web inicial, basta mudar a URL para: http://localhost:5182/Home

---
**Agora, podemos começar a testar as funcionalidades!**

Assim que clicarmos no menu Usuario, você será redirecionado para o formulário da Região.

1. Basta preencher o formulário e selecionar no dropdown o estado desejado.

![Cadastro da regiao](/img/cadastro-regiao.png)

2. Após clicar em Salvar, seremos redirecionados diretamente para o formulário do Usuário.

![Cadastro do usuario](/img/cadastro-usuario.png)

3. Por fim, quando clicarmos em salvar, iremos voltar para a tela principal do usuário.

![Informacao cadastrada](/img/tela-info-fim.png)

4. Caso queira editar alguma informação, basta clicar no botão "Editar", e assim você será redirecionado novamente para o formulário

5. Caso queira apagar, assim que clicar no botão "Excluir", seremos redirecionados para uma tela de confirmação, em que as informações serão mostradas novamente com uma mensagem de confirmação

## Tecnologias Utilizadas

- ASP.NET Core 8.0
- Oracle Entity Framework Core
- Swagger (Swashbuckle)
- Razor Pages

