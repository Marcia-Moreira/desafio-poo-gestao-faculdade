using System;

public class Curso
{
    public string Codigo { get; set; }
    public string Nome { get; set; }
    public string Tipo { get; set; } // "Graduação" ou "Pós-graduação"
    public List<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();
    public List<Aluno> AlunosMatriculados { get; set; } = new List<Aluno>();

    public Curso(string codigo, string nome, string tipo)
    {
        Codigo = codigo;
        Nome = nome;
        Tipo = tipo;
    }
}