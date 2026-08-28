using System;

public class Matricula
{
    public Aluno AlunoAssociado { get; set; }
    public Curso CursoAssociado { get; set; }
    public Boletim BoletimEspecifico { get; set; }
    public List<Matricula> Matriculas { get; set; } = new List<Matricula>();

    public Matricula(Aluno alunoAssociado, Curso cursoAssociado)
    {
        AlunoAssociado = alunoAssociado;
        CursoAssociado = cursoAssociado;
        BoletimEspecifico = new Boletim();
    }
}