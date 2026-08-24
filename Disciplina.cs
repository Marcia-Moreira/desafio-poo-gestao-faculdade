
using System;

public class Disciplina
{
    public string Codigo { get; set; }
    public string Nome { get; set; }
    public int CargaHoraria { get; set; }
    public Professor ProfessorResponsavel { get; set; }

    public Disciplina(string codigo, string nome, int cargaHoraria, Professor professorResponsavel)
    {
        Codigo = codigo;
        Nome = nome;
        CargaHoraria = cargaHoraria;
        ProfessorResponsavel = professorResponsavel;
    }
}