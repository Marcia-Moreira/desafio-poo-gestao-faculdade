using System;

class Program
{
    static void Main(string[] args)
    {
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

                case "1": // Cadastro de Curso
                Console.WriteLine("\n========= CADASTRO DO CURSO =========");
                Console.Write("Digite o Código: "); 
                string cod = Console.ReadLine();
                // Validação: Não permitir códigos duplicados
                if (listaCursos.Any(c => c.Codigo == cod)) {
                    Console.WriteLine("Erro: Código de curso já existe.");
                    break;
                }
                Console.Write("Digite o Nome: "); 
                string nomeC = Console.ReadLine();
    
                Console.Write("Digite o Tipo: Graduação ou Pós-Graduação: "); 
                string tipo = Console.ReadLine();
                
                listaCursos.Add(new Curso(cod, nomeC, tipo));
                break;


                    
                case 2: GerenciadorPessoas.CadastrarProfessor(); break;
                case 3: GerenciadorPessoas.CadastrarAluno(); break;
                case 4: RascunhoTesteLocal.TestarEstrutura(); break;

                case "4": // Cadastro Disciplina

                //  ● Código; ● Nome; ● Carga horária; ● Professor responsável. 
                // O professor responsável deve estar previamente cadastrado. 
                // Não deve ser possível cadastrar duas disciplinas com o mesmo código. 

                Console.WriteLine("\n====== CADASTRO DE DISCIPLINA ====== ");

                // 1. Validar se existem professores cadastrados
                if (listaProfessores.Count == 0)
                {
                    Console.WriteLine("Erro: Não há professores cadastrados. Cadastre um professor (Opção 2) antes de criar uma disciplina.");
                    break;
                }

                // 2. Mostrar a lista de professores para seleção
                Console.WriteLine("Selecione o Professor Responsável:");
                for (int i = 0; i < listaProfessores.Count; i++)
                {
                    Console.WriteLine($"{i} - {listaProfessores[i].Nome} (Registro: {listaProfessores[i].Registro})");
                }

                Console.Write("Digite o número do professor: ");
                int indiceProfessor = int.Parse(Console.ReadLine());
    
                // Validar se o índice escolhido é válido
                if (indiceProfessor < 0 || indiceProfessor >= listaProfessores.Count)
                {
                    Console.WriteLine("Erro: Seleção de professor inválida.");
                    break;
                }

            Professor profSelecionado = listaProfessores[indiceProfessor];

               // 3. Capturar os dados da disciplina 
                Console.Write("Código da Disciplina: ");
                string codDisc = Console.ReadLine();
    
                // REGRA: Código da disciplina não pode se repetir 
                if (listaDisciplinas.Any(d => d.Codigo == codDisc))
                {
                    Console.WriteLine("Erro: Já existe uma disciplina com este código.");
                    break;
                }
    
                Console.Write("Nome da Disciplina: ");
                string nomeDisc = Console.ReadLine();
                
                Console.Write("Carga Horária: ");
                int cargaH = int.Parse(Console.ReadLine());

                // 4. Criar e salvar a disciplina com o professor vinculado
                Disciplina novaDisciplina = new Disciplina(codDisc, nomeDisc, cargaH, profSelecionado);
                listaDisciplinas.Add(novaDisciplina);
    
                Console.WriteLine($"Disciplina '{nomeDisc}' cadastrada com sucesso com o professor {profSelecionado.Nome}!");
                break;

                    
                case 5: RascunhoTesteLocal.TestarEstrutura(); break;
                case 6: RascunhoTesteLocal.TestarEstrutura(); break;
                case 7: RascunhoTesteLocal.TestarEstrutura(); break;
                case 8: GerenciadorPessoas.ConsultarPessoas(); break;
                case 9: RascunhoTesteLocal.TestarEstrutura(); break;

                case "9": // Consulta de cursos

            Console.WriteLine("\n====== CONSULTAR CURSOS CADASTRADOS ====== ");

            if (listaCursos.Count == 0)
            {
                Console.WriteLine("Nenhum curso cadastrado até o momento.");
            }
            else
            {
                // Conforme requisito: Apresentar Código, Nome, Tipo, Disciplinas, Professores e Alunos [1]
                for (int i = 0; i < listaCursos.Count; i++)
                {
                    var c = listaCursos[i];
                    Console.WriteLine($"\n[{i}] Curso: {c.Nome} | Código: {c.Codigo} | Tipo: {c.Tipo}");
                    
                    Console.WriteLine("   Disciplinas e Professores:");
                    if (c.Disciplinas.Count == 0) Console.WriteLine("   - Nenhuma disciplina vinculada.");
                    foreach (var d in c.Disciplinas)
                    {
                        // Exibe disciplina e o professor responsável conforme regra [1, 2]
                        Console.WriteLine($"   - {d.Nome} (Professor: {d.ProfessorResponsavel.Nome})");
                    }

                    Console.WriteLine("   Alunos Matriculados:");
                    // Busca na lista de matrículas quem está neste curso específico [1, 2]
                    var alunosNoCurso = listaMatriculas.Where(m => m.CursoVinculado.Codigo == c.Codigo).ToList();
                    if (alunosNoCurso.Count == 0) Console.WriteLine("   - Nenhum aluno matriculado.");
                    foreach (var m in alunosNoCurso)
                    {
                        Console.WriteLine($"   - {m.AlunoVinculado.Nome}");
                    }
                }
            }
            break;
                    
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
