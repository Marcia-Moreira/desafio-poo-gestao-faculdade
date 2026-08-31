using System;

class Program
{
    static void Main(string[] args)
    {
        // Para TESTAR: Popular/Carregamento de Dados para Teste
        // BancoDados.CarregarDadosDeTeste();

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
                // Núcleo Acadêmico (Daianne - Agora separado e adaptado! )
                case 1: GerenciadorCursos.CadastrarCurso(); break;
                case 4: GerenciadorCursos.CadastrarDisciplina(); break;
                case 5: GerenciadorCursos.VincularDisciplina(); break;
                case 9: GerenciadorCursos.ConsultarCursos(); break;

                // Núcleo Humano (Mariana)
                case 2: GerenciadorPessoas.CadastrarProfessor(); break;
                case 3: GerenciadorPessoas.CadastrarAluno(); break;
                case 8: GerenciadorPessoas.ConsultarPessoas(); break;

                // Núcleo de Matrícula (Aline)
                case 6: GerenciadorMatricula.MatricularAluno(); break;
                case 10: GerenciadorMatricula.ConsultarMatriculas(); break;
                case 11: GerenciadorMatricula.ConsultarBoletim(); break;

                // Núcleo de Notas e Notificações (Luana - Agora separado e adaptado!)
                case 7: GerenciadorNotas.IniciarLancamentoNota(); break;
                case 12: GerenciadorNotas.IniciarNotificacao(); break;

                case 0: Console.WriteLine("Sistema encerrado."); break;
                default: Console.WriteLine("Opção inválida!"); break;
            }
        } while (opcao != 0);
    }
}// dotnet run
