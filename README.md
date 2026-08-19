# 🏫 Sistema de Gestão de Faculdade

 Desafio prático focado em Programação Orientada a Objetos (POO) em C# e .NET.

---

## 👥 Integrantes da Squad Carmen Portinho

* **Aline Shimoi Rodrigues** - [GitHub](https://github.com/AlineShimoi)

* **Daianne Coelho Pinheiro** - [GitHub](https://github.com/daiannec-p)

* **Luana Ferreira Souza** - [GitHub](https://github.com/luanaferreirasouza)

* **Marcia Daniele da Silva Moreira** - [GitHub](https://github.com/Marcia-Moreira)

* **Mariana Nascimento Lemos** (Líder da Squad) - [GitHub](https://github.com/mariananlemos)

## 🏛️ Instituição e Contexto

* **Comunidade:** WoMakersCode
  
* **Programa:** Bootcamp Back-End .NET 2026.2
  
* **Objetivo do Desafio:** Desenvolver um sistema robusto em formato Console Application para a secretaria de uma faculdade, permitindo o gerenciamento de cursos, disciplinas, professores, matrículas e boletins acadêmicos utilizando os pilares de POO (Herança, Composição, Encapsulamento e Polimorfismo).

---

## 📖 Documentação do Projeto

Para entender as regras detalhadas e o escopo técnico do desafio, acesse os arquivos de apoio abaixo:

* [📑 Regras de Negócio e Requisitos Completo](REQUISITOS.md) - Enunciado oficial, validações e especificações do sistema.
* [📑 Contrato Técnico da Squad](CONTRATO.md) - Padrões de nomenclatura de classes e variáveis combinados pela Squad.

## 🚀 Como Executar e Testar o Projeto

Para rodar este sistema localmente na sua máquina, você precisará do **SDK do .NET 8.0 (ou superior)** instalado.

### 1. Clonar o Repositório

Abra o terminal do seu computador e execute o comando:

```bash
git clone https://github.com/desafio-poo-gestao-faculdade.git
```

### 2. Entrar no Diretório

```bash
cd desafio-poo-gestao-faculdade
```

### 3. Executar a Aplicação

```bash
dotnet run
```

---

## 📊 Estrutura de Menu do Sistema

O sistema opera de forma assíncrona e interativa através das seguintes opções:

1. **Cadastrar curso** (Graduação ou Pós-Graduação)
2. **Cadastrar professor** (Com checagem de CPF/Registro único)
3. **Cadastrar aluno** (Gera número de matrícula único)
4. **Cadastrar disciplina** (Vinculada a um professor cadastrado)
5. **Vincular disciplina a um curso**
6. **Matricular aluno em curso** (Gera automaticamente o Boletim)
7. **Lançar nota** (Validações de 0 a 10 e regras por tipo de curso)
8. **Consultar pessoas** (Filtros específicos para Alunos e Professores)
9. **Consultar cursos**
10. **Consultar matrículas**
11. **Consultar boletim** (Notas separadas por curso do aluno)
12. **Enviar notificação** (Sistema de alertas para Alunos/Professores)
13. **Sair**

---
⭐ *Desenvolvido com dedicação pela Squad Carmen Portinho - Agosto de 2026.*
