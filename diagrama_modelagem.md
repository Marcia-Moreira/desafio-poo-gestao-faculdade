# 🏛️ Arquitetura do Sistema e Modelagem de Classes

Este cartão centraliza o mapa visual da nossa Programação Orientada a Objetos (POO) para o Sistema de Gestão de Faculdade.
Ele serve como o guia oficial para sabermos os atributos e métodos de cada arquivo do projeto.

## 📊 Diagrama de Classes (Visual)

```mermaid
classDiagram
    %% Alterando as cores para letras pretas e fundo limpo
    theme BCDE

    class Pessoa {
        <<Classe Mãe Abstrata>>
        +string Nome
        +string CPF
        +string Email
        +ReceberNotificacao(string mensagem) void
    }

    class Aluno {
        <<Classe Filha de Pessoa>>
        +string Matricula
        +List~Matricula~ MatriculasAtivas
    }

    class Professor {
        <<Classe Filha de Pessoa>>
        +string Registro
        +string Especialidade
    }

    class Curso {
        <<Classe Acadêmica>>
        +string Codigo
        +string Nome
        +string Tipo
        +List~Disciplina~ Disciplinas
        +List~Aluno~ AlunosMatriculados
        +AdicionarDisciplina(Disciplina d) void
        +MatricularAluno(Aluno a) void
    }

    class Disciplina {
        <<Classe Acadêmica>>
        +string Codigo
        +string Nome
        +int CargaHoraria
        +Professor ProfessorResponsavel
        +VincularProfessor(Professor p) void
    }

    class Matricula {
        <<Classe - A Cola do Sistema>>
        +Aluno AlunoAssociado
        +Curso CursoAssociado
        +Boletim BoletimEspecifico
    }

    class Boletim {
        <<Classe - O Histórico de Notas>>
        +Dictionary~Disciplina, double~ Notas
        +Dictionary~Disciplina, string~ Situacao
        +LancarNota(Disciplina d, double nota) void
        +CalcularMedia(double n1, double n2) double
        +CalcularAprovacao(string tipoCurso) void
    }

    %% Setas de Relacionamento
    Pessoa <|-- Aluno : Aluno HERDA de Pessoa
    Pessoa <|-- Professor : Professor HERDA de Pessoa
    Curso "1" *-- "muitas" Disciplina : Curso GUARDA lista de Disciplinas
    Disciplina "muitas" o-- "1" Professor : Disciplina APONTA para um Professor
    Matricula "1" o-- "1" Aluno : Matricula APONTA para um Aluno
    Matricula "1" o-- "1" Curso : Matricula APONTA para um Curso
    Matricula "1" *-- "1" Boletim : Matricula CRIA um Boletim automaticamente

```

---

## 📖 Legenda Oficial de Notações POO

### 🔍 Modificadores de Acesso (Sinais)

* **`+` (Public):** Visível para qualquer arquivo. Usado em quase todo o projeto para que as classes e métodos das colegas consigam conversar entre si.
* **`-` (Private):** Oculto. Apenas a própria classe pode ler (ótimo para funções de validações internas de segurança).
* **`#` (Protected):** Visível apenas na Classe Mãe (`Pessoa`) e nas Classes Filhas (`Aluno` / `Professor`).

### 📐 Estruturas de Flechas Universais (Relacionamentos)

* **`<|--` (Herança):** Indica que uma classe filha herda tudo da classe mãe. *(Exemplo: Aluno é uma Pessoa)*.
* **`*--` (Composição Rígida):** Forte dependência. As duas coisas nascem e morrem juntas. *(Exemplo: Se deletar a Matrícula, o Boletim dela some junto)*.
* **`o--` (Associação / Agregação):** Ligação independente. Aponta para algo que já existe fora dali. *(Exemplo: A Disciplina aponta para um Professor já cadastrado)*.

### 📊 Multiplicidades

* **`"1" *-- "muitas"`:** Sinaliza a existência de coleções, arrays ou listas (`List<Disciplina>`) para armazenar múltiplos dados dentro de um objeto.
