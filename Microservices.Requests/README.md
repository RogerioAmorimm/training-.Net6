# Hiper.Microservices.Template

📘 Microserviço de template.

### Jenkins e Sonarqube

| Produção | Release | 
|:---:|:------:|
|[![Build Status](http://jenkins.hiper.com.br/buildStatus/icon?job=Hiper.Microservices.Template%2Fmaster)](http://jenkins.hiper.com.br/job/Hiper.Microservices.Template/job/master/) | [![Build Status](http://jenkins.hiper.com.br/buildStatus/icon?job=Hiper.Microservices.Template%2Frelease)](http://jenkins.hiper.com.br/job/Hiper.Microservices.Template/job/release/)|
|[![Sonarqube](https://img.shields.io/badge/Sonarqube-master-1abc9c.svg)](http://sonarqube.hiper.com.br/dashboard?id=Hiper.Microservices.Template)|[![Sonarqube](https://img.shields.io/badge/Sonarqube-release-1abc9c.svg)](http://sonarqube.hiper.com.br/dashboard?branch=release&id=Hiper.Microservices.Template)|


------

## Criação de um Microservice a partir desse template

- Criar projeto no Github do Microservice baseando-se nesse template (dando Use Template).
- No branch master, executar o bat `rename_projects.bat` na pasta scripts, preenchendo o nome do MS e nome para infra-estrutura. Exemplo: Para o Microservice de Integração com a Linx, preencher:
  - Nome do projeto: Integracao.Linx
  - Nome para infra: integracao-linx
- Commitar as alterações. 
- Criar o branch `release`.
- Ir no branch `master` novamente e adicionar uma linha a mais no arquivo `.github/settings.yaml`, e commitar a alteração. Isso é feito para ele aplicar todas as regras nesse branch.
- [Criar pipeline no Jenkins](https://dev.azure.com/hiperdevops/Hiper%203.0/_wiki/wikis/Hiper-3.0.wiki/1611/Projeto-no-Jenkins)
- [Criar projeto no Sonarqube](https://dev.azure.com/hiperdevops/Hiper%203.0/_wiki/wikis/Hiper-3.0.wiki/1613/Projeto-no-Sonarqube)
