using System;
using System.Linq;
using System.Collections.Generic;

public static class GerenciadorPessoas
{
    public static void CadastrarProfessor()
    {
        Console.WriteLine("\n=======================================");
        Console.WriteLine("        CADASTRO DE PROFESSOR");
        Console.WriteLine("=======================================");
        
        string nome = ObterEntradaObrigatoria("Nome: ");
        
        string cpf = "";
        while (true)
        {
            cpf = ObterEntradaObrigatoria("CPF: ");
            if (BancoDados.Alunos.Any(a => a.CPF == cpf) || BancoDados.Professores.Any(p => p.CPF == cpf))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: Já existe um aluno ou professor cadastrado com este CPF.");
                Console.ResetColor();
                continue;
            }
            break;
        }

        string email = ObterEntradaObrigatoria("E-mail: ");

        string registro = "";
        while (true)
        {
            registro = ObterEntradaObrigatoria("Registro: ");
            if (BancoDados.Professores.Any(p => p.Registro.Trim().ToUpper() == registro.Trim().ToUpper()))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: Já existe um professor cadastrado com este Registro.");
                Console.ResetColor();
                continue;
            }
            break;
        }

        string especialidade = ObterEntradaObrigatoria("Especialidade: ");

        Professor novoProfessor = new Professor(nome, cpf, email, registro, especialidade);
        BancoDados.Professores.Add(novoProfessor);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n✔️ Professor cadastrado com sucesso!");
        Console.ResetColor();
    }

    public static void CadastrarAluno()
    {
        Console.WriteLine("\n=======================================");
        Console.WriteLine("          CADASTRO DE ALUNO");
        Console.WriteLine("=======================================");
        
        string nome = ObterEntradaObrigatoria("Nome: ");
        
        string cpf = "";
        while (true)
        {
            cpf = ObterEntradaObrigatoria("CPF: ");
            if (BancoDados.Alunos.Any(a => a.CPF == cpf) || BancoDados.Professores.Any(p => p.CPF == cpf))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: Já existe um aluno ou professor cadastrado com este CPF.");
                Console.ResetColor();
                continue;
            }
            break;
        }

        string email = ObterEntradaObrigatoria("E-mail: ");

        string matricula = "";
        while (true)
        {
            matricula = ObterEntradaObrigatoria("Número de Matrícula: ");
            if (BancoDados.Alunos.Any(a => a.Matricula.Trim().ToUpper() == matricula.Trim().ToUpper()))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: Já existe um aluno cadastrado com este número de Matrícula.");
                Console.ResetColor();
                continue;
            }
            break;
        }

        Aluno novoAluno = new Aluno(nome, cpf, email, matricula);
        BancoDados.Alunos.Add(novoAluno);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n✔️ Aluno cadastrado com sucesso!");
        Console.ResetColor();
    }

    public static void ConsultarPessoas()
    {
        Console.WriteLine("\n=======================================");
        Console.WriteLine("         CONSULTA DE PESSOAS");
        Console.WriteLine("=======================================");
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n--- PROFESSORES ---");
        Console.ResetColor();
        
        if (BancoDados.Professores.Count == 0)
        {
            Console.WriteLine("Nenhum professor cadastrado.");
        }
        else
        {
            foreach (var p in BancoDados.Professores)
            {
                Console.WriteLine($"- Nome: {p.Nome}");
                Console.WriteLine($"  CPF: {p.CPF}");
                Console.WriteLine($"  E-mail: {p.Email}");
                Console.WriteLine($"  Registro: {p.Registro}");
                Console.WriteLine($"  Especialidade: {p.Especialidade}");
                Console.WriteLine();
            }
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("--- ALUNOS ---");
        Console.ResetColor();
        
        if (BancoDados.Alunos.Count == 0)
        {
            Console.WriteLine("Nenhum aluno cadastrado.");
        }
        else
        {
            foreach (var a in BancoDados.Alunos)
            {
                Console.WriteLine($"- Nome: {a.Nome}");
                Console.WriteLine($"  CPF: {a.CPF}");
                Console.WriteLine($"  E-mail: {a.Email}");
                Console.WriteLine($"  Número de Matrícula: {a.Matricula}");
                
                if (a.MatriculasAtivas == null || a.MatriculasAtivas.Count == 0)
                {
                    Console.WriteLine("  Cursos matriculado: Nenhum curso ativo.");
                }
                else
                {
                    var cursos = string.Join(", ", a.MatriculasAtivas.Select(m => m.CursoAssociado?.Nome ?? "Curso Sem Nome"));
                    Console.WriteLine($"  Cursos matriculado: {cursos}");
                }
                Console.WriteLine();
            }
        }
    }

    public static void EnviarNotificacao()
    {
        Console.WriteLine("\n=======================================");
        Console.WriteLine("          ENVIAR NOTIFICAÇÃO");
        Console.WriteLine("=======================================");
        
        int totalPessoas = BancoDados.Professores.Count + BancoDados.Alunos.Count;
        if (totalPessoas == 0)
        {
            Console.WriteLine("Não há pessoas cadastradas para notificar.");
            return;
        }

        Console.WriteLine("Selecione a pessoa que deseja notificar:");
        
        int index = 1;
        var listaPessoas = new List<Pessoa>();
        
        foreach (var p in BancoDados.Professores)
        {
            Console.WriteLine($"{index} - [Professor] {p.Nome} (Registro: {p.Registro})");
            listaPessoas.Add(p);
            index++;
        }
        
        foreach (var a in BancoDados.Alunos)
        {
            Console.WriteLine($"{index} - [Aluno] {a.Nome} (Matrícula: {a.Matricula})");
            listaPessoas.Add(a);
            index++;
        }

        int escolha;
        while (true)
        {
            Console.Write("\nDigite o número correspondente: ");
            if (int.TryParse(Console.ReadLine(), out escolha) && escolha >= 1 && escolha <= totalPessoas)
            {
                break;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Opção inválida. Tente novamente.");
            Console.ResetColor();
        }

        Pessoa selecionada = listaPessoas[escolha - 1];
        
        Console.Write($"Digite a mensagem de notificação para {selecionada.Nome}: ");
        string mensagem = Console.ReadLine() ?? "";
        if (string.IsNullOrWhiteSpace(mensagem))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("A mensagem não pode ser vazia.");
            Console.ResetColor();
            return;
        }

        selecionada.ReceberNotificacao(mensagem);
    }

    private static string ObterEntradaObrigatoria(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string entrada = Console.ReadLine()?.Trim() ?? "";
            if (!string.IsNullOrEmpty(entrada))
            {
                return entrada;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Erro: Este campo é obrigatório.");
            Console.ResetColor();
        }
    }
}
