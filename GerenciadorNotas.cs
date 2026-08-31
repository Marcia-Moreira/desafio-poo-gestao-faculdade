// Complemento Luana para rodar no Menu separado:
using System;
using System.Globalization;
using desafio_poo_gestao_faculdade;

public static class GerenciadorNotas
{
    // Método estático que lê o Console e chama a classe da Luana
    public static void IniciarLancamentoNota()
    {
        Console.WriteLine("\n----- LANÇAR NOTA -----");
        Aluno? aluno = GerenciadorMatricula.ValidarAluno();
        if (aluno == null) return;

        Curso? curso = GerenciadorMatricula.ValidarCurso();
        if (curso == null) return;

        Console.Write("Código da Disciplina: ");
        string codigoDisc = (Console.ReadLine() ?? "").Trim().ToUpper();

        Console.Write("Digite a Nota (0.0 a 10.0): ");
        // if (!double.TryParse(Console.ReadLine(), out double nota))
        if (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out double nota))
        {
            Console.WriteLine("Erro: Entrada de nota inválida.");
            return;
        }

        ServicoNota servico = new ServicoNota();
        servico.LancarNota(aluno, curso.Codigo, codigoDisc, nota);
    }

    // Método estático que lê o Console e chama a notificação da Luana
    public static void IniciarNotificacao()
    {
        Console.WriteLine("\n----- ENVIAR NOTIFICAÇÃO -----");
        Aluno? aluno = GerenciadorMatricula.ValidarAluno();
        if (aluno == null) return;

        Console.Write("Digite a mensagem de notificação: ");
        string mensagem = Console.ReadLine() ?? "";

        ServicoNota servico = new ServicoNota();
        servico.EnviarNotificacao(aluno, mensagem);
    }
}
