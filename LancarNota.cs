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

            var matricula = BancoDados.Matriculas.FirstOrDefault(m => 
                m.AlunoAssociado.CPF == aluno.CPF && 
                (m.CursoAssociado.Codigo.ToLower() == codigoCurso.ToLower() || 
                m.CursoAssociado.Nome.ToLower() == codigoCurso.ToLower()));

            if (matricula == null)
            {
                Console.WriteLine($"Erro: O aluno {aluno.Nome} não possui matrícula no curso '{codigoCurso}'.");
                return false;
            }

           var disciplina = matricula.CursoAssociado.Disciplinas.FirstOrDefault(d => d.Codigo == codigoDisciplina);

            if (disciplina == null)
            {
                Console.WriteLine($"Erro: A disciplina '{codigoDisciplina}' não pertence ao curso {matricula.CursoAssociado.Nome}.");
                return false;
            }

            matricula.BoletimEspecifico.Notas[disciplina] = nota;

            // 1. Define o tipo do curso
        string tipoCurso = matricula.CursoAssociado.Tipo;
        if (string.IsNullOrEmpty(tipoCurso))
        {
            tipoCurso = "Graduação";
        }

        
        double notaCorte = 7.0;

        if (tipoCurso.ToLower() == "pós-graduação")
        {
            notaCorte = 8.0;
        }
        if (nota >= notaCorte)
        {
            matricula.BoletimEspecifico.Situacao[disciplina] = "Aprovado";
        }
        else
        {
            matricula.BoletimEspecifico.Situacao[disciplina] = "Reprovado";
        }

        Console.WriteLine($"Nota {nota:F1} lançada para {aluno.Nome} na disciplina {disciplina.Nome}.");
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