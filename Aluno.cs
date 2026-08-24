using System.Collections.Generic;

public class Aluno : Pessoa
{
    public string Matricula { get; set; }
    public List<Matricula> MatriculasAtivas { get; set; }

    public Aluno(string nome, string cpf, string email, string matricula) 
        : base(nome, cpf, email)
    {
        Matricula = matricula;
        MatriculasAtivas = new List<Matricula>();
    }
}