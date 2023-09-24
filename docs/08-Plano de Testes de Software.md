# Plano de Testes de Software

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>

<p>Abaixo estão os cenários levantados e listados nos casos de teste de forma a atender os requisitos dessa aplicação:</p>

| **Caso de Teste** 	| **CT-01 – Tela de Cadastro** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-005|
| Objetivo do Teste 	| Verificar se o usuário consegue se cadastrar na aplicação. |
| Passos 	| - O usuário deve, na pagina inicial, clicar em Entrar, será direcionado a tela de cadastro e deverá fornecer as seguintes informações requeridas: Nome completo; gênero; Tipo de tratamento; Data de nascimento (formato DD/MM/AAAA); E-mail; telefone(contendo DDD) e senha <br> - Aceitar os termos de uso <br> - Clicar em "Cadastrar" |
|Critério de Êxito | - O cadastro foi realizado com sucesso e os dados armazenados com um Id único de identificação no banco de dados |
|  	|  	|
 
| **Caso de Teste** 	| **CT-02 – Login** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-006 |
| Objetivo do Teste 	| Verificar se o usuário consegue realizar Login na aplicação. |
| Passos 	| - Acessar o navegador <br> - Informar o e-mail<br> <br> - senha <br> - Clicar em "Entrar" |
|Critério de Êxito | - O Login foi realizado com sucesso. validação através dos dados da classe Usuário e da classe AutenticaçaoUsuário |
|  	|  	|

| **Caso de Teste** 	| **CT-03 – Teste de comportamento para cadastro dos medicamentos**	|
|:---:	|:---:	|
|Requisito Associado | RF-001 e RF-003. |
| Objetivo do Teste 	| Verificar se o comportamento e validação das classes de medicamentos. |
| Passos 	| - Usuário logado <br> - Clicar em medicamento - Adicionar Medicamento - Preencher os campos: Nome do medicamento, Informações sobre, Dosagem e Observações <br> - Clicar em "Adicionar" |
|Critério de Êxito | - Cadastrar medicamento. |
|  	|  	|

| **Caso de Teste** 	| **CT-04 – Teste de comportamento para consulta dos medicamentos**	|
|:---:	|:---:	|
|Requisito Associado | RF-001 e RF-003. |
| Objetivo do Teste 	| Verificar se o usuario consegue consultar os medicamentos cadastrados  |
| Passos 	| - Usuário logado <br> - Clicar em medicamento - Listagem de medicamento <br> - |
|Critério de Êxito | - Consultar medicamento. |
|  	|  	|

 | **Caso de Teste** 	| **CT-05 – Teste de comportamento para Cadastro dos tratamentos**	|
|:---:	|:---:	|
|Requisito Associado | RF-001 e RF-003. |
| Objetivo do Teste 	| Verificar se o comportamento e validação das classes de tratamentos  |
| Passos 	| - Usuário logado <br> - Clicar em Tratamento - Adicionar Tratamento - Preencher os campos: Tipo de tratamento, Duração do tratamento, Medicação, administração do medicamente <br> - |
|Critério de Êxito | - Cadastrar Tratamento. |
|  	|  	|

| **Caso de Teste** 	| **CT-06 – Teste de comportamento para consulta dos Tratamentos**	|
|:---:	|:---:	|
|Requisito Associado | RF-001 e RF-003. |
| Objetivo do Teste 	| Verificar se o usuario consegue consultar os tratamentos cadastrados  |
| Passos 	| - Usuário logado <br> - Clicar em Tratamento - Listagem dos tratamentos<br> - Clicar no tratamento desejado|
|Critério de Êxito | - Consultar tratamento. |
|  	|  	|

 | **Caso de Teste** 	| **CT-07 – Teste de comportamento para Cadastro das Consultas**	|
|:---:	|:---:	|
|Requisito Associado | RF-001 e RF-003. |
| Objetivo do Teste 	| Verificar se o comportamento e validação das classes de consultas  |
| Passos 	| - Usuário logado <br> - Clicar em Consultas - Adicionar Consulta - Preencher os campos: Nome do médico, Motivo, Data, anotações e recomendações - Clicar em Salvar <br> - |
|Critério de Êxito | - Cadastrar Consultas para lembrete. |
|  	|  	|

| **Caso de Teste** 	| **CT-08 – Teste de comportamento para averiguar as Consultas**	                                                  |
|:---:	|:---:	|
|Requisito Associado | RF-001 e RF-003.                                                                                                 |
| Objetivo do Teste 	| Verificar se o usuario consegue conferir as consultas cadastradas                                                |             
| Passos 	| - Usuário logado <br> - Clicar em Consultas - Listagem das consultas <br> - Clicar na consulta desejada -  Editar ou Excluir|
|Critério de Êxito | - Averiguar Consultas. |
|  	|  	|

 | **Caso de Teste** 	| **CT-09 – Teste de comportamento para Cadastro Ciclo Menstrual**	|
|:---:	|:---:	|
|Requisito Associado | RF-001 e RF-003. |
| Objetivo do Teste 	| Verificar se o comportamento e validação das classes de Ciclo menstrual  |
| Passos 	| - Usuário logado <br> - Clicar em Ciclo Menstrual - Preencher os campos: Duração, Medicação utilizada, Fluxo, Condição - Clicar em Salvar <br> - |
|Critério de Êxito | - Cadastrar ciclo menstrual. |
|  	|  	|

| **Caso de Teste** 	| **CT-10 – Teste de comportamento para averiguar as Acompanhamento Diário**	                                                  |
|:---:	|:---:	|
|Requisito Associado | RF-001 e RF-003.                                                                                                 |
| Objetivo do Teste 	| Verificar se o usuario consegue consultar o Acompanhamento diário do ciclo biológico   |             
| Passos 	| - Usuário logado <br> - Clicar em Ciclo Menstrual - Clicar em acompanhamento diário <br> - Editar/Inserir o ciclo menstrual -  Ter acesso ao calendário |
|Critério de Êxito | - Consultar Acompanhamento diário. |
|  	|  	|

| **Caso de Teste** 	| **CT-11 – Teste de comportamento para averiguar as Alterações fisicas**	                                                  |
|:---:	|:---:	|
|Requisito Associado | RF-001 e RF-003.                                                                                                 |
| Objetivo do Teste 	| Verificar se o usuario consegue consultar as Alterações Fisicas    |             
| Passos 	| - Usuário logado <br> - Clicar em Ciclo Menstrual - Clicar em Alterações Fisicas <br> - Marcar as alterações correspondentes  |
|Critério de Êxito | - Consultar Alterações fisicas. |
|  	|  	|

| **Caso de Teste** 	| **CT-12 – Teste de comportamento para averiguar o Humor**	                                                  |
|:---:	|:---:	|
|Requisito Associado | RF-001 e RF-003.                                                                                                 |
| Objetivo do Teste 	| Verificar se o usuario consegue consultar as Alterações de Humor    |             
| Passos 	| - Usuário logado <br> - Clicar em Ciclo Menstrual - Clicar em Alterações de Humor <br> - Marcar as alterações correspondentes  |
|Critério de Êxito | - Consultar Alterações de Humor. |
|  	|  	|
