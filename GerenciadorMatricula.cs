using desafio_poo_gestao_faculdade;

public class GerenciadorMatricula
{
    public static void MatricularAluno()
    {
        Console.WriteLine("----- Matrícula de Aluno no Curso -----\n");
        var aluno = ValidarAluno();
        if(aluno is null) return;

        var curso = ValidarCurso();
        if(curso is null) return;

        foreach(var a in BancoDados.Matriculas)
        {
            if(a.AlunoAssociado.Nome == aluno.Nome)
            {
                Console.WriteLine();
                Console.WriteLine($"Aluno(a) {aluno.Nome} já matriculado");
                return;
            }
        }

        try
        {
            Matricula novaMatricula = new Matricula(aluno, curso);
            BancoDados.Matriculas.Add(novaMatricula);
            Console.WriteLine();
            Console.WriteLine($"Matricula do aluno(a) {aluno.Nome} no curso {curso.Nome}, realizada.");

        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void ConsultarMatriculas()
    {
        Console.WriteLine("----- Consulta de matrícula -----");
        var aluno = ValidarAluno();
        if(aluno is null) return;

        int countIteracao = 0;

        foreach(var a in BancoDados.Matriculas)
        {
            if(a.AlunoAssociado.Nome == aluno.Nome)
            { 
                Console.WriteLine("---------------------");
                Console.WriteLine($"Nome: {aluno.Nome}");
                Console.WriteLine($"Matrícula: {aluno.Matricula}");
                Console.WriteLine();
                Console.WriteLine($"Curso: {a.CursoAssociado.Nome}");
                Console.WriteLine($"Tipo: {a.CursoAssociado.Tipo}");  
            }
        }
        
        if(countIteracao > 0)
        {
            Console.WriteLine();
            Console.WriteLine($"O aluno {aluno.Nome} não possui matrículas ativas.");
            return;
        }
    }

    public static void ConsultarBoletim()
    {
        Console.WriteLine("----- Consulta de Boletim -----");
        var aluno = ValidarAluno();
        if(aluno is null) return;
        var curso = ValidarCurso();
        if(curso is null) return;

        Console.WriteLine();
        Console.WriteLine("----- Boletim -----");
        Console.WriteLine($"Nome: {aluno.Nome}");
        Console.WriteLine($"Matrícula: {aluno.Matricula}");
        Console.WriteLine();
        Console.WriteLine($"Curso: {curso.Codigo}");
        Console.WriteLine($"Tipo: {curso.Tipo}");
        Console.WriteLine();

        foreach(var m in BancoDados.Matriculas)
        {
            if(m.AlunoAssociado.Nome == aluno.Nome && m.CursoAssociado.Nome == curso.Nome)
            {
                foreach(var d in BancoDados.Disciplinas)
                {
                    if(m.BoletimEspecifico.Notas.TryGetValue(d, out double nota))
                    {
                        string tipoCurso = m.CursoAssociado.Tipo ?? "Graduação";
                        double notaCorte = tipoCurso.Equals("Pós-graduação", StringComparison.OrdinalIgnoreCase) ? 8.0 : 7.0;
                        Console.WriteLine($"Disciplina: {d.Nome}");
                        Console.WriteLine($"Nota: {nota}");
                        Console.WriteLine("Situação: " + (nota >= notaCorte ? "Aprovado" : "Reprovado"));
                    }
                }
            }
        }    
    }

    public static Aluno? ValidarAluno()
    {
        Console.Write("Nome do aluno: ");
        var nomeAluno = Console.ReadLine();

        foreach(var a in BancoDados.Alunos)
        {
            if(a.Nome.ToLower() == nomeAluno)
            {
                return a;
            }
        }
        Console.WriteLine($"Aluno(a) {nomeAluno} não cadastrado.");
        return null;
    }

    public static Curso? ValidarCurso()
    {
        Console.Write("Código do curso: ");
        var nomeCurso = Console.ReadLine();

        foreach(var a in BancoDados.Cursos)
        {
            if(a.Codigo == nomeCurso)
            {
                return a;
            }
        }
        Console.WriteLine($"Código de curso {nomeCurso} não cadastrado.");
        return null;
    }
    public static void ExecutarLancarNota()
    {
        Console.WriteLine("\nLançamento de Nota");
        
        // 1. Buscar Aluno
        var aluno = ValidarAluno();
        if (aluno is null) return;

        // 2. Pedir Códigos do curso e da disciplina
        Console.Write("Código do Curso: ");
        string codigoCurso = Console.ReadLine();

        Console.Write("Código da Disciplina: ");
        string codigoDisciplina = Console.ReadLine();

        Console.Write("Nota (0.0 a 10.0): ");
        if (!double.TryParse(Console.ReadLine(), out double nota))
        {
            Console.WriteLine("Erro: Valor de nota inválido.");
            return;
        }
        ServicoNota servico = new ServicoNota();
        servico.LancarNota(aluno, codigoCurso, codigoDisciplina, nota);
    }
   
}