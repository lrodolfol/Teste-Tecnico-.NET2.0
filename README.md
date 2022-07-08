<h1 align="center">
	Teste Técnico Desenvolvedor II .NET <br>
	Melhoria do teste <a href="https://github.com/lrodolfol/Teste-Tecnico-.NET"> Inicial </a>
</h1>
<h3 align="center"> Construção de API para gerenciamentos de TODO's </h3>

## Sobre 
O projeto inicial era para fazer uma API de gerenciamento de TODO's. Vi a oporunidade de transformar essa tarefa em algo mais robusto e utilizar outras ferramentas para isso. Onde dei push em 3 imagens no docckerhub: <b>(Veja as versões de cada para melhor uso da aplicação)</b> <br/><br/>
https://hub.docker.com/r/rodolfojesus/todo_manager <b>(Gerenciamento de Todo's) </b><br/>
https://hub.docker.com/r/rodolfojesus/progress-manager <b>(Gerenciamento de In Progress)</b><br/>
https://hub.docker.com/r/rodolfojesus/done-manager  <b>(Gerenciamento de Done's)</b><br/>

e outra assembly no Nuget: <br/> 
https://www.nuget.org/packages/CardsManagerLibTest/

<p>A aplicação foi desenvolvida pensando em sua possível extensão para mais funcionalidades e models/controladores além do Todo. <br>
Os pacotes utilizados ajudam na implementação de padrões de projetos utilizados 
como criação e mapeamento de novos objetos, responsabilidades únicas de classe, 
reutilização de código, isolamento de funcionalidades e padronizações de código para melhor leitura.</p>

## Tecnologias Utilizadas: 
 - Banco de dados Mysql / SqlServer
 - IDE Visual Studio Community 2022
 - .NET CORE 6
 - Docker

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

<i>var connectionString = builder.Configuration.GetConnectionString("StringConnApiTodoManagerDocker"); </i>
<br/><br/>

<b>Use o Arquivo docker-compose.yml contido na pasta de cada projeto para criar todos os ambientee e as dependencias necessárias automaticamente e execute o comando na pasta correpondente: </b><br/>
```
docker compose up
```

Mas se preferir

<b>Para criar containers rode os seguintes comandos via terminal: </b><br/>
```
docker network create --driver bridge cards_manager
```
```
docker run -d --name mysql --network cards_manager -e MYSQL_ROOT_PASSWORD=root123 mysql
```
```
docker run -d -p 8080:80 --network cards_manager rodolfojesus/todo_manager:2.0
docker run -d -p 8081:80 --network cards_manager rodolfojesus/progress_manager:1.0
docker run -d -p 8082:80 --network cards_manager rodolfojesus/done_manager:1.0
```

Abra o navegador no endereço <i>http://localhost:8080/swagger/index.html</i>

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
