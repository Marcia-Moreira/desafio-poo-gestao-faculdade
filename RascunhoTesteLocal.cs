using System;
using System.Collections.Generic;
using desafio_poo_gestao_faculdade;

public class RascunhoTesteLocal
{
    public static void TestarEstrutura()
    {

        var servico = new ServicoNota();

        // 1. Instanciando com Construtores exigidos pelas classes do projeto
        var professor = new Professor("Carlos Silva", "111.222.333-44", "carlos@faculdade.com", "REG123", "C#");
        var disciplinaPOO = new Disciplina("POO", "Programação Orientada a Objetos", 80, professor);
        
        var cursoADS = new Curso("ADS", "Análise e Desenvolvimento de Sistemas", "Graduação");
        cursoADS.Disciplinas = new List<Disciplina> { disciplinaPOO };

        var aluno = new Aluno("Ana Souza", "999.888.777-66", "ana@email.com", "2026001");
        
        var matricula = new Matricula(aluno, cursoADS);
        aluno.MatriculasAtivas.Add(matricula);

        // 2. Testes de Lançamento de Nota
        Console.WriteLine("\n--- Teste 1: Lançar Nota Válida (8.5) ---");
        servico.LancarNota(aluno, "ADS", "POO", 8.5);

        Console.WriteLine("\n--- Teste 2: Lançar Nota Inválida (11.0) ---");
        servico.LancarNota(aluno, "ADS", "POO", 11.0);

        Console.WriteLine("\n--- Teste 3: Curso Não Matriculado (ARQ) ---");
        servico.LancarNota(aluno, "ARQ", "POO", 9.0);

        // 3. Testes de Notificação
        Console.WriteLine("\n--- Teste 4: Notificação para Aluno ---");
        servico.EnviarNotificacao(aluno, "Sua nota de POO foi lançada com sucesso!");

        Console.WriteLine("\n--- Teste 5: Notificação para Professor ---");
        servico.EnviarNotificacao(professor, "Lembrete: Reunião pedagógica às 18h.");
    }
}