# PROCESSO_SELETIVO-cadastro_de_super_herois
CRUD para cadastro de super-heróis para processo seletivo. dotNET-Angular-SqlServer

Durante a análise dos requisitos para elaboração deste projeto, fiz a opção pelas tecnologias .Net Core 5.0 e Banco de dados SQLSERVER.
Optei por estrutar o código em camadas, de forma que ficasse mais próximo do padrão de design DDD(o que foi um grande desafio, pois apesar da opção pela estrutura, jamais havia feito do zero), seguindo a seguintes estrutura:

CrudSuperHeroes.Domain: camada do domínio da aplicação onde estão: script de base de dados; as entidades e interfaces com os modelos de negócio.
CrudSuperHeroes.Infra : localizados os arquivos de context, as migrations para alteração de base e a implementação dos repositórios
CrudSuperHeroes.API: onde se encontra a api do projeto, com controllers e demais configurações do projeto(tipo de SGBD, demais configurações de base e escopo. 
