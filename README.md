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
De qualquer forma, já foi criado uma imagem para essa aplicação e disponibilizado no dockerhub. Link: https://hub.docker.com/r/rodolfojesus/todo_manager

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
