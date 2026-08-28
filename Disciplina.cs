
using System;

public class Disciplina
{
    public string CodigoDisciplina { get; set; }
    public string NomeDisciplina { get; set; }
    public int CargaHoraria { get; set; }
    public Professor ProfessorResponsavel { get; set; }

    public Disciplina(string codigoDisciplina, string nomeDisciplina, int cargaHoraria, Professor professorResponsavel)
    {
        CodigoDisciplina = codigoDisciplina;
        NomeDisciplina = nomeDisciplina;
        CargaHoraria = cargaHoraria;
        ProfessorResponsavel = professorResponsavel;
    }
}