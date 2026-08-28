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
        else if(nome is "null" && nomeCurso is not "null") 
        {
            Console.WriteLine($"Matricula do aluno(a) {nome} no curso {nomeCurso}, realizada.");
        }

        /*try
        {
            Matricula matricula = new Matricula(nome, codigoCurso);
            matriculas.Add(matricula);

        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }*/
    }

    public static void ConsultarMatriculas()
    {
        Console.WriteLine("----- Consulta de matrícula -----");
        InformacoesMatricula();     
    }

    public static void ConsultarBoletim()
    {
        Console.WriteLine("----- Consulta de Boletim -----");
        string nome = ValidarAluno();
        if(nome is "null") return;

        string nomeCurso = ValidarCurso();
        if(nomeCurso is "null") return;
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






    /*public void MatricularAluno(List<Matricula> matriculas, List<Aluno> alunos, List<Curso> cursos)
    {
        //menu item 6: Matricular aluno em curso
        BancoDados.CarregarDadosDeTeste();
        Console.WriteLine("----- Matrícula de Aluno no Curso -----");
        
        var nomeAluno = BuscarAluno(alunos);
        var nomeCurso = BuscarCurso(cursos);
        if(nomeAluno is null || nomeCurso is null) return;

        var matricula = matriculas.FirstOrDefault(x => x.AlunoAssociado == nomeAluno && x.CursoAssociado == nomeCurso);
        //Matricula do aluno no curso encontrada se matricula not null
        if(matricula is not null)
        {
            Console.WriteLine($"Aluno {nomeAluno} já matriculado");
            return;
        }

        Console.WriteLine($"Matricula do aluno {nomeAluno} - {matricula}, realizada.");

        try
        {
            Matricula matricula = new Matricula(aluno, curso);
            matriculas.Add(matricula);

        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }   
        

    public Aluno BuscarAluno(List<Aluno> alunos)
    {
        BancoDados.CarregarDadosDeTeste();
            
        Console.WriteLine("Nome do aluno: ");
        var nomeAluno = Console.ReadLine();
        
        var aluno = alunos.FirstOrDefault(x => x.Nome == nomeAluno);

        if(aluno is null)
        {
            Console.WriteLine($"Aluno {aluno} não existe no sistema.");
        }

        return aluno;
    }

    public Curso BuscarCurso(List<Curso> cursos)
    { 
        Console.WriteLine("Curso: ");
        var nomeCurso = Console.ReadLine();
            
        var curso = cursos.FirstOrDefault(x => x.Nome == nomeCurso);

        if(curso is null)
        {
            Console.WriteLine($"Curso {curso} não existe no sistema.");                
        }
        
        return curso;
    }*/
    //10 - Consultar matrícula


    //11 - Consultar boletim

}