<h1 align="center">
	Teste Técnico Desenvolvedor II .NET <br>
	Melhoria do teste <a href="https://github.com/lrodolfol/Teste-Tecnico-.NET"> Inicial </a>
</h1>
<h3 align="center"> Construção de API para gerenciamentos de TODO's </h3>

## Sobre 
A aplicação foi desenvolvida pensando em sua possível extensão para mais funcionalidades e models/controladores além do Todo. <br>
Os pacotes utilizados ajudam na implementação de padrões de projetos utilizados 
como criação e mapeamento de novos objetos, responsabilidades únicas de classe, 
reutilização de código, isolamento de funcionalidades e padronizações de código para melhor leitura.

## Tecnologias Utilizadas: 
 - Banco de dados Mysql / SqlServer
 - IDE Visual Studio Community 2022
 - .NET CORE 6

### Bibliotecas, Pacotes e Frameworks utilizados:
 - EntityFrameWorkCore
 - AutoMapper DependecyInjection
 - Provider SqlServer
 - Pomelo Mysql
 - EFCore Proxies Lazy-loading
 - EFCore Tools
 - CardsManagerLibTest (https://www.nuget.org/packages/CardsManagerLibTest/) v 1.1.1
 
## Rodando a aplicação
 - A aplicação utiliza a ConnectionString setada no arquivo appsettings.json para conexão com o bando de dados. Altere o arquivo com configurações da sua máquina local. Por padrão está usando o Mysql
 - A aplicação executa a migration para criar o database e tabelas automaticamente. Em caso de erro, será exibido as informações no console. Niss, Utilize o console de gerenciador de pacotes do NuGet e rode os comando de migrations: 
	- Add-Migration "migration"
	- Update-Database
 - O swagger está habilitado, mesmo assim, foi disponibilizado o arquivo CollectionRequests.json na raiz do projeto. Faça importação no Postman se necessário.
 
 ### Container
A aplicação também utiliza o Mysql no container. A comunicação é feita pelo nome da imagem mysql criado. Por padrão: mysql.  <br/>
Descomentar linha 20 do arquivo Program.cs <br/> <br/>

<i>var connectionString = builder.Configuration.GetConnectionString("StringConnApiTodoManagerPlusDocker"); </i>
<br/><br/>

<b>Use o Arquivo docker-compose.yml contido na pasta do projeto para criar todo ambiente e as dependencias necessárias automaticamente e execute o comando na pasta correpondente: </b><br/>
```
docker compose up
```

Mas se preferir

<b>Para criar containers rode os seguintes comandos via terminal: </b><br/>
```
docker network create --driver bridge todo_manager
```
```
docker run -d --name mysql --network todo_manager -e MYSQL_ROOT_PASSWORD=root123 mysql
```
```
docker run -d -p 8080:80 --network todo_manager rodolfojesus/todo_manager:1.1
```

Abra o navegador no endereço <i>http://localhost:8080/swagger/index.html</i>
<br/>Link do dockerhub: https://hub.docker.com/r/rodolfojesus/todo_manager
<br/>Use tag :1.1


### Possíveis alterações necessárias
 - A aplicação está rodando na porta padrão disponibilizada pela plataforma. Portas 5001 para https e 5000 para http.
Se necessário alterar uma ou outra, basta alterar na linha 25 do arquivo launchSttings.json dentro da pasta Properties.
 - Se utilizado o postman para usar as requições: <br>
caso seja exibido algum erro de SSL, desabilite a verificação em: File->settings->SSQL certificate verification(off)


## Credits
- [Rodolfo J.Silva](https://github.com/lrodolfol) (Developer)
- [LinkeIn](https://www.linkedin.com/in/rodolfoj-silva/)
- Email: (rodolfo0ti@gmail.com)

## License
The MIT License (MIT).
