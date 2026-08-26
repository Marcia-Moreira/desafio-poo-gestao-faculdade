using System;

class Program
{
    static void Main(string[] args)
    {
        //! Para TESTAR: Popular/Carregamento de Dados para Teste
        BancoDados.CarregarDadosDeTeste();

        int opcao;
        do
        {
            Console.WriteLine("\n========= GESTÃO DA FACULDADE =========");
            Console.WriteLine("1 - Cadastrar curso");
            Console.WriteLine("2 - Cadastrar professor");
            Console.WriteLine("3 - Cadastrar aluno");
            Console.WriteLine("4 - Cadastrar disciplina");
            Console.WriteLine("5 - Vincular disciplina a um curso");
            Console.WriteLine("6 - Matricular aluno em curso");
            Console.WriteLine("7 - Lançar nota");
            Console.WriteLine("8 - Consultar pessoas");
            Console.WriteLine("9 - Consultar cursos");
            Console.WriteLine("10 - Consultar matrículas");
            Console.WriteLine("11 - Consultar boletim");
            Console.WriteLine("12 - Enviar notificação");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("=======================================");
            Console.Write("Escolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))  opcao = -1;

            switch (opcao)
            {
                // Chamando a sua classe de rascunho local para testar minimamente
                // case 1: GestaoMetodos.CadastrarCurso(); break;
                // case 2: GestaoMetodos.CadastrarProfessor(); break;
                // case 3: GestaoMetodos.CadastrarAluno(); break;
                // case 4: GestaoMetodos.CadastrarDisciplina(); break;
                // case 5: GestaoMetodos.VincularDisciplina(); break;
                // case 6: GestaoMetodos.MatricularAluno(); break;
                // case 7: GestaoMetodos.LancarNota(); break;
                // case 8: GestaoMetodos.ConsultarPessoas(); break;
                // case 9: GestaoMetodos.ConsultarCursos(); break;
                // case 10: GestaoMetodos.ConsultarMatriculas(); break;
                // case 11: GestaoMetodos.ConsultarBoletim(); break;
                // case 12: GestaoMetodos.EnviarNotificacao(); break;
                case 1: RascunhoTesteLocal.TestarEstrutura(); break;
                case 2: GerenciadorPessoas.CadastrarProfessor(); break;
                case 3: GerenciadorPessoas.CadastrarAluno(); break;
                case 4: RascunhoTesteLocal.TestarEstrutura(); break;
                case 5: RascunhoTesteLocal.TestarEstrutura(); break;
                case 6: RascunhoTesteLocal.TestarEstrutura(); break;
                case 7: RascunhoTesteLocal.TestarEstrutura(); break;
                case 8: GerenciadorPessoas.ConsultarPessoas(); break;
                case 9: RascunhoTesteLocal.TestarEstrutura(); break;
                case 10: RascunhoTesteLocal.TestarEstrutura(); break;
                case 11: RascunhoTesteLocal.TestarEstrutura(); break;
                case 12: GerenciadorPessoas.EnviarNotificacao(); break;
                case 0: Console.WriteLine("Sistema encerrado."); break;
                default: Console.WriteLine("Opção inválida!"); break;
            }
        } while (opcao != 0);
    }
}
// dotnet run