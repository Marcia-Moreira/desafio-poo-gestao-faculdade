using System;

public class Professor : Pessoa
{
    public string Registro { get; set; }
    public string Especialidade { get; set; }

    public Professor(string nome, string cpf, string email, string registro, string especialidade) 
        : base(nome, cpf, email)
    {
        Registro = registro;
        Especialidade = especialidade;
    }
}