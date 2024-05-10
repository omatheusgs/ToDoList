Controle de Tarefas To-Do

Objetivo:
 - Criar um sistema de controle de tarefas estilo to-do.
 - Cadastro de uma tarefa.
 - Listagem de tarefas com filtro de 'pendente, em andamento ou todos'.
 - Alteração da tarefa.
 - Exclusão da tarefa.
 
Descrição do Projeto:

- A aplicação foi construída com .NET 7 e Entity Framework. Para executar será necessário ter essa versão instalada. Você pode encontrá-la aqui: https://dotnet.microsoft.com/pt-br/download/dotnet/7.0.
- O projeto não possui comunicação com o banco de dados. Todos os dados são persistidos e consumidos em memória (cache) do entity framework.
- Caso precise configurar algum banco de dados, basta configurar a aplicação com a ConnectionString necessária que o funcionamento será o mesmo.

A aplicação está divida em duas camadas:

- Teste.ToDoList: possui o controller e as views. Essa é a camada que deve ser executada;
- Teste.ToDoList.Infra: possui a entidade, os repositorios que implementam as regras de negócio da aplicação e comunicação com os dados que estão em cache do entity framework. 

Execução do projeto:
- Instale a versão 7 do .NET Framework;
- Clone o repositório;
- Abra a solução;
- Defina o projeto 'Teste.ToDoList' como projeto de inicialização;
- Execute a aplicação (F5);
- Execute as funcionalidades da aplicação;
