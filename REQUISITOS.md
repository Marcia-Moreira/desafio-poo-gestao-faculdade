# 📑 Requisitos Educacionais e Regras de Negócio

Este documento centraliza todas as regras de negócio e especificações exigidas para o desenvolvimento do Sistema de Gestão de Faculdade.

---

## ⚙️ Regras de Negócio Principais

### 1. Cursos e Disciplinas

* A faculdade pode possuir vários cursos.
* Cada curso possui obrigatoriamente: **Código** (ex: `ADS`), **Nome** e **Tipo** (*Graduação* ou *Pós-graduação*).
* Não é permitido cadastrar dois cursos com o mesmo código.
* Cada curso possui uma lista de disciplinas.
* Cada disciplina deve ter um professor responsável previamente cadastrado. Unicidade baseada no **Código da Disciplina**.
* Uma mesma disciplina não pode ser adicionada duas vezes ao mesmo curso.

### 2. Alunos e Matrículas

* O cadastro inicial do aluno exige: **Nome**, **CPF**, **E-mail** e **Número de Matrícula**.
* O cadastro inicial do aluno **não** o obriga a escolher um curso imediatamente.
* Não é permitido duplicidade de CPF ou Número de Matrícula.
* Um aluno pode estar matriculado em vários cursos, mas **nunca duas vezes no mesmo curso**.

### 3. Sistema de Boletim e Notas

* Cada matrícula gera **automaticamente** um boletim específico.
* O boletim armazena *apenas* as notas das disciplinas pertencentes àquele curso específico. As notas de um curso não se misturam com as de outro.
* Toda nota lançada deve estar estritamente entre **0 e 10**.

### 4. Critérios de Aprovação (Dependem do Tipo do Curso)

* 🎓 **Graduação:** Média final **>= 7.0** ➡️ *Aprovado* | Média < 7.0 ➡️ *Reprovado*.
* 📜 **Pós-graduação:** Média final **>= 8.0** ➡️ *Aprovado* | Média < 8.0 ➡️ *Reprovado*.

### 5. Notificações

* Alunos e professores devem possuir um mecanismo para receber mensagens/alertas textuais do sistema.

---

## 🗂️ Modelo de Entrada e Saída do Menu (Console)

O menu interativo deve seguir estritamente o layout abaixo:

```text
========= GESTÃO DA FACULDADE =========
1 - Cadastrar curso
2 - Cadastrar professor
3 - Cadastrar aluno
4 - Cadastrar disciplina
5 - Vincular disciplina a um curso
6 - Matricular aluno em curso
7 - Lançar nota
8 - Consultar pessoas
9 - Consultar cursos
10 - Consultar matrículas
11 - Consultar boletim
12 - Enviar notificação
0 - Sair
=======================================
```
