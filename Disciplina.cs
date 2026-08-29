//namespace FaculdadeCarmemPortinho
//{
    public class Disciplina
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }
        public Professor ProfessorResponsavel { get; set; }

        // Construtor
        public Disciplina(string codigo, string nome, int cargaHoraria, Professor professorResponsavel)
        {
            Codigo = codigo;
            Nome = nome;
            CargaHoraria = cargaHoraria;
            ProfessorResponsavel = professorResponsavel;
        }
    }
//}



//Cadastro de disciplina
// Para cadastrar uma disciplina, informe:
// Código;
// Nome;
// Carga horária;
// Professor responsável.
// O professor responsável deve estar previamente cadastrado.
// Não deve ser possível cadastrar duas disciplinas com o mesmo código.
// Vinculação de disciplina ao curso
// A secretaria deve selecionar:
// Um curso;
// Uma disciplina.
// A disciplina passa a fazer parte daquele curso.
// Uma mesma disciplina não deve ser adicionada duas vezes ao mesmo curso.
// Exemplo:
// Curso: ADS
// Disciplina: POO Professor: Carlos Silva
