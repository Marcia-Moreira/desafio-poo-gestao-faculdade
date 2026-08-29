public class GerenciadorMatricula
{
    public static void MatricularAluno()
    {
        Console.WriteLine("----- Matrícula de Aluno no Curso -----\n");
        string nome = ValidarAluno();
        if(nome is "null") return;

        string nomeCurso = ValidarCurso();
        if(nomeCurso is "null") return;
        
        if(nome is not "null" && nomeCurso is not "null")
        {
            Console.WriteLine($"Aluno(a) {nome} já matriculado");
            return;
        }

        try
        {
            Aluno matriculaAluno = new Aluno("null","null","null","null");
            foreach(var a in BancoDados.Alunos)
            {
                if(a.Nome == nome)
                {
                    matriculaAluno = new Aluno(a.Nome, a.CPF, a.Email, a.Matricula);
                }
            }            
            
            Curso matriculaCurso = new Curso("null", "null", "null");
            foreach(var c in BancoDados.Cursos)
            {
                if(c.Nome == nomeCurso)
                {
                    matriculaCurso = new Curso(c.Codigo, c.Nome, c.Tipo);
                }
            }
            Matricula novaMatricula = new Matricula(matriculaAluno, matriculaCurso);
            BancoDados.Matriculas.Add(novaMatricula);
            Console.WriteLine($"Matricula do aluno(a) {nome} no curso {nomeCurso}, realizada.");

        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void ConsultarMatriculas()
    {
        Console.WriteLine("----- Consulta de matrícula -----");
        InformacoesMatricula();     
    }

    public static void ConsultarBoletim()
    {
        Console.WriteLine("----- Consulta de Boletim -----");
        InformacoesBoletim();
    }

    public static string ValidarAluno()
    {
        Console.Write("Nome do aluno: ");
        var nomeAluno = Console.ReadLine();

        foreach(var a in BancoDados.Matriculas)
        {
            if(a.AlunoAssociado.Nome == nomeAluno)
            {
                return a.AlunoAssociado.Nome;
            }
        }
        Console.WriteLine($"Aluno(a) {nomeAluno} não cadastrado.");
        return "null";
    }

    public static string ValidarCurso()
    {
        Console.Write("Código do curso: ");
        var nomeCurso = Console.ReadLine();

        foreach(var a in BancoDados.Matriculas)
        {
            if(a.CursoAssociado.Codigo == nomeCurso)
            {
                return a.CursoAssociado.Nome;
            }
        }
        Console.WriteLine($"Código de curso {nomeCurso} não cadastrado.");
        return "null";
    }

    public static void InformacoesMatricula()
    {
        var nome = ValidarAluno();
        foreach(var m in BancoDados.Matriculas)
        {
            if(m.AlunoAssociado.Nome == nome)
            {
                Console.WriteLine("---------------------");
                Console.WriteLine($"Nome: {m.AlunoAssociado.Nome}");
                Console.WriteLine($"Matrícula: {m.AlunoAssociado.Matricula}");
                Console.WriteLine();
                Console.WriteLine($"Curso: {m.CursoAssociado.Codigo}");
                Console.WriteLine($"Tipo: {m.CursoAssociado.Tipo}");
            }
        }
    }

    public static void InformacoesBoletim()
    {
        var nomeAluno = ValidarAluno();
        var nomeCurso = ValidarCurso();

        foreach(var m in BancoDados.Matriculas)
        {
            if(m.AlunoAssociado.Nome == nomeAluno)
            {
                Console.WriteLine("----- Boletim -----");
                Console.WriteLine($"Nome: {m.AlunoAssociado.Nome}");
                Console.WriteLine($"Matrícula: {m.AlunoAssociado.Matricula}");
                Console.WriteLine();
            }
        }
        foreach(var c in BancoDados.Matriculas)
        {
            if(c.CursoAssociado.Nome == nomeCurso)
            {

                Console.WriteLine($"Curso: {c.CursoAssociado.Codigo}");
                Console.WriteLine($"Tipo: {c.CursoAssociado.Tipo}");
            }
        }
        
        List<Disciplina> disciplinas = new List<Disciplina>();
        foreach(var d in disciplinas)
        {
            Console.WriteLine();
            Console.WriteLine(d.Nome);
        }
        Dictionary<Disciplina, double> notas = new Dictionary<Disciplina, double>();
        foreach(var n in notas)
        {
            Console.WriteLine($"Nota: {n.Value}");
        }
        Dictionary<Disciplina, double> situacao = new Dictionary<Disciplina, double>();
        foreach(var s in situacao)
        {
            Console.WriteLine($"Situação: {s.Value}");
        }

    }
}