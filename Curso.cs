// abstraçao : Dados essenciais para o sistema (Nome, Código e Tipo do curso)
// System.Collections.Generic para permitir o uso de listas e incluí a coleção de disciplinas

using System.Collections.Generic; // Necessário para usar Listas

//namespace FaculdadeCarmemPortinho
{
    public class Curso
    {
        public string Nome{ get; set; } //Permitem ler e gravar informações nos campos.
        public string Codigo { get; set; }
        public string Tipo { get; set; } // Graduação ou Pós-graduação
        public List<Disciplina> Disciplinas { get; set; } // Lista para armazenar as disciplinas vinculadas a este curso

        // Construtor
        public Curso(string nome, string codigo, string tipo)
        {
            Nome = nome;
            Codigo = codigo;
            Tipo = tipo;
            Disciplinas = new List<Disciplina>(); // Inicializamos a lista vazia para evitar erros de "referência nula"
        }
    }
}

//Cadastro de curso
// Para cadastrar um curso, informe:
// Código;
// Nome;
// Tipo do curso.
// Exemplo:
// Código: ADS Nome: Análise e Desenvolvimento de Sistemas Tipo: Graduação
