using System;
using System.Collections.Generic;

public static class BancoDados
{
    public static List<Aluno> Alunos { get; set; } = new List<Aluno>();
    public static List<Professor> Professores { get; set; } = new List<Professor>();
    public static List<Curso> Cursos { get; set; } = new List<Curso>();
    public static List<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();
    public static List<Matricula> Matriculas { get; set; } = new List<Matricula>();

    //! Método para TESTE:
    //! Para popular dados rápidos e testar sem digitar tudo no console.
    public static void CarregarDadosDeTeste()
    {
        // 1. Cria um professor pré-cadastrado
        Professor prof1 = new Professor("Dra. Graziele", "11122233344", "grazi@faculdade.com", "REG001", "C# e .NET");
        Professores.Add(prof1);

        // 2. Cria uma disciplina com o professor
        Disciplina discPOO = new Disciplina("POO", "Programação Orientada a Objetos", 80, prof1);
        Disciplinas.Add(discPOO);

        // 3. Cria um curso e vincula a disciplina
        Curso cursoADS = new Curso("ADS", "Análise e Desenvolvimento de Sistemas", "Graduação");
        // cursoADS.AdicionarDisciplina(discPOO);
        cursoADS.Disciplinas.Add(discPOO);
        Cursos.Add(cursoADS);

        // 4. Cria uma aluna
        Aluno aluna1 = new Aluno("Marcia Moreira", "99988877766", "marcia@email.com", "MAT2026");
        Alunos.Add(aluna1);

        // 5. Matricula a aluna no curso
        Matricula mat1 = new Matricula(aluna1, cursoADS);
        aluna1.MatriculasAtivas.Add(mat1);
        cursoADS.AlunosMatriculados.Add(aluna1);
        Matriculas.Add(mat1);
    }
}
