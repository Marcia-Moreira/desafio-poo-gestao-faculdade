using System.Collections.Generic;

public static class BancoDados
{
    public static List<Aluno> Alunos { get; } = new List<Aluno>();
    public static List<Professor> Professores { get; } = new List<Professor>();
    public static List<Curso> Cursos { get; } = new List<Curso>();
    public static List<Disciplina> Disciplinas { get; } = new List<Disciplina>();
    public static List<Matricula> Matriculas { get; } = new List<Matricula>();
}
