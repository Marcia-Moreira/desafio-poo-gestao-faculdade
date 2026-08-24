using System;

public abstract class Pessoa
{
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Email { get; set; }

    protected Pessoa(string nome, string cpf, string email)
    {
        Nome = nome;
        CPF = cpf;
        Email = email;
    }

    public virtual void ReceberNotificacao(string mensagem)
    {
        Console.WriteLine($"[Notificação para {Nome} ({CPF})]: {mensagem}");
    }
}