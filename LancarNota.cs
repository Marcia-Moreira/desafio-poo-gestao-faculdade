using System;
using System.Linq;

namespace desafio_poo_gestao_faculdade
{
    public class ServicoNota
    {
        public bool LancarNota(Aluno aluno, string codigoCurso, string codigoDisciplina, double nota)
        {
            if (nota < 0 || nota > 10)
            {
                Console.WriteLine("Erro: A nota deve estar entre 0.0 e 10.0.");
                return false;
            }

            var matricula = aluno.MatriculasAtivas
                ?.FirstOrDefault(m => m.CursoAssociado != null && m.CursoAssociado.Codigo == codigoCurso);

            if (matricula == null)
            {
                Console.WriteLine($"Erro: O aluno {aluno.Nome} não possui matrícula no curso '{codigoCurso}'.");
                return false;
            }

            var disciplina = matricula.CursoAssociado.Disciplinas
                ?.FirstOrDefault(d => d.Codigo == codigoDisciplina);

            if (disciplina == null)
            {
                Console.WriteLine($"Erro: A disciplina '{codigoDisciplina}' não pertence ao curso {matricula.CursoAssociado.Nome}.");
                return false;
            }

            // Acessa diretamente o dicionário de Notas criado no Boletim pela Aline
            matricula.BoletimEspecifico.Notas[disciplina] = nota;

            // Define a situação baseada no tipo de curso
            string tipoCurso = matricula.CursoAssociado.Tipo ?? "Graduação";
            double notaCorte = tipoCurso.Equals("Pós-graduação", StringComparison.OrdinalIgnoreCase) ? 8.0 : 7.0;
            matricula.BoletimEspecifico.Situacao[disciplina] = nota >= notaCorte ? "Aprovado" : "Reprovado";
            
            Console.WriteLine($"Sucesso! Nota {nota:F1} lançada para {aluno.Nome} na disciplina {disciplina.Nome}.");
            return true;
        }

        public void EnviarNotificacao(Pessoa pessoa, string mensagem)
        {
            if (pessoa == null)
            {
                Console.WriteLine("Erro: Nenhuma pessoa foi selecionada.");
                return;
            }

            if (string.IsNullOrWhiteSpace(mensagem))
            {
                Console.WriteLine("Erro: A mensagem da notificação não pode estar vazia.");
                return;
            }

            pessoa.ReceberNotificacao(mensagem);
        }
    }
}