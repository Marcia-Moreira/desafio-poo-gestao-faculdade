// Adaptação Código Danianne para rodar no Menu
using System;
using System.Linq;
using System.Collections.Generic;

public static class GerenciadorCursos
{
    // LÓGICA DO CASE "1" DA DAIANNE ADAPTADA
    public static void CadastrarCurso()
    {
        Console.WriteLine("\n========= CADASTRO DO CURSO =========");
        Console.Write("Digite o Código: "); 
        string cod = (Console.ReadLine() ?? "").Trim().ToUpper();
        
        // Validação de unicidade que a Daianne fez, lendo o BancoDados oficial
        if (BancoDados.Cursos.Any(c => c.Codigo == cod)) {
            Console.WriteLine("Erro: Código de curso já existe.");
            return;
        }
        Console.Write("Digite o Nome: "); 
        string nomeC = (Console.ReadLine() ?? "").Trim();

        Console.Write("Digite o Tipo: Graduação ou Pós-Graduação: "); 
        string tipo = (Console.ReadLine() ?? "").Trim();

        BancoDados.Cursos.Add(new Curso(cod, nomeC, tipo));
        Console.WriteLine($"✔️ Curso '{nomeC}' cadastrado com sucesso!");
    }

    // LÓGICA DO CASE "4" DA DAIANNE ADAPTADA
    public static void CadastrarDisciplina()
    {
        Console.WriteLine("\n====== CADASTRO DE DISCIPLINA ====== ");

        // 1. Validar se existem professores cadastrados (usando a lista global do BancoDados)
        if (BancoDados.Professores.Count == 0)
        {
            Console.WriteLine("Erro: Não há professores cadastrados. Cadastre um professor (Opção 2) antes de criar uma disciplina.");
            return;
        }

        // 2. Mostrar a lista de professores para seleção
        Console.WriteLine("Selecione o Professor Responsável:");
        for (int i = 0; i < BancoDados.Professores.Count; i++)
        {
            Console.WriteLine($"{i} - {BancoDados.Professores[i].Nome} (Registro: {BancoDados.Professores[i].Registro})");
        }

        Console.Write("Digite o número do professor: ");
        if (!int.TryParse(Console.ReadLine(), out int indiceProfessor) || indiceProfessor < 0 || indiceProfessor >= BancoDados.Professores.Count)
        {
            Console.WriteLine("Erro: Seleção de professor inválida.");
            return;
        }

        Professor profSelecionado = BancoDados.Professores[indiceProfessor];

        // 3. Capturar os dados da disciplina 
        Console.Write("Código da Disciplina: ");
        string codDisc = (Console.ReadLine() ?? "").Trim().ToUpper();

        if (BancoDados.Disciplinas.Any(d => d.Codigo == codDisc))
        {
            Console.WriteLine("Erro: Já existe uma disciplina com este código.");
            return;
        }

        Console.Write("Nome da Disciplina: ");
        string nomeDisc = (Console.ReadLine() ?? "").Trim();

        Console.Write("Carga Horária: ");
        if (!int.TryParse(Console.ReadLine(), out int cargaH))
        {
            Console.WriteLine("Erro: Carga horária inválida.");
            return;
        }

        // 4. Criar e salvar a disciplina com o professor vinculado
        Disciplina novaDisciplina = new Disciplina(codDisc, nomeDisc, cargaH, profSelecionado);
        BancoDados.Disciplinas.Add(novaDisciplina);

        Console.WriteLine($"✔️ Disciplina '{nomeDisc}' cadastrada com sucesso!");
    }

    // OPÇÃO 5: VINCULAR DISCIPLINA AO CURSO (Garantindo que o escopo funcione por completo)
    public static void VincularDisciplina()
    {
        Console.WriteLine("\n----- VINCULAR DISCIPLINA AO CURSO -----");
        Console.Write("Código do Curso: ");
        string codigoCurso = (Console.ReadLine() ?? "").Trim().ToUpper();

        Curso? curso = BancoDados.Cursos.FirstOrDefault(c => c.Codigo == codigoCurso);
        if (curso == null)
        {
            Console.WriteLine("Erro: Curso não encontrado.");
            return;
        }

        Console.Write("Código da Disciplina: ");
        string codigoDisc = (Console.ReadLine() ?? "").Trim().ToUpper();

        Disciplina? disciplina = BancoDados.Disciplinas.FirstOrDefault(d => d.Codigo == codigoDisc);
        if (disciplina == null)
        {
            Console.WriteLine("Erro: Disciplina não encontrada.");
            return;
        }

        if (curso.Disciplinas.Any(d => d.Codigo == codigoDisc))
        {
            Console.WriteLine("Erro: Esta disciplina já está vinculada a este curso.");
            return;
        }

        curso.Disciplinas.Add(disciplina);
        Console.WriteLine($"✔️ Disciplina '{disciplina.Nome}' vinculada ao curso '{curso.Nome}'!");
    }

    // LÓGICA DO CASE "9" DA DAIANNE ADAPTADA
    public static void ConsultarCursos()
    {
        Console.WriteLine("\n====== CONSULTAR CURSOS CADASTRADOS ====== ");

        if (BancoDados.Cursos.Count == 0)
        {
            Console.WriteLine("Nenhum curso cadastrado até o momento.");
            return;
        }

        for (int i = 0; i < BancoDados.Cursos.Count; i++)
        {
            var c = BancoDados.Cursos[i];
            Console.WriteLine($"\n[{i}] Curso: {c.Nome} | Código: {c.Codigo} | Tipo: {c.Tipo}");
            
            Console.WriteLine("   Disciplinas e Professores:");
            if (c.Disciplinas.Count == 0) Console.WriteLine("   - Nenhuma disciplina vinculada.");
            foreach (var d in c.Disciplinas)
            {
                Console.WriteLine($"   - {d.Nome} (Professor: {d.ProfessorResponsavel.Nome})");
            }

            Console.WriteLine("   Alunos Matriculados:");
            // Ajustado para ler a lista de matrículas oficial do BancoDados
            var alunosNoCurso = BancoDados.Matriculas.Where(m => m.CursoAssociado.Codigo == c.Codigo).ToList();
            if (alunosNoCurso.Count == 0) Console.WriteLine("   - Nenhum aluno matriculado.");
            foreach (var m in alunosNoCurso)
            {
                Console.WriteLine($"   - {m.AlunoAssociado.Nome}");
            }
        }
    }
}


