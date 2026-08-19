# 📑 Contrato Técnico - Sistema de Gestão de Faculdade

Para garantir que o código de todas as integrantes se conecte perfeitamente sem erros de compilação, todas as classes devem seguir rigorosamente a nomenclatura combinada abaixo:

## 🗂️ Classes e Atributos Combinados

### 1. Classe Base: `Pessoa` (Abstrata)

- `string Nome`
- `string CPF`
- `string Email`
- `virtual void ReceberNotificacao(string mensagem)`

### 2. Classe: `Aluno` (Herda de Pessoa)

- `string Matricula`
- `List<Matricula> MatriculasAtivas`

### 3. Classe: `Professor` (Herda de Pessoa)

- `string Registro`
- `string Especialidade`

### 4. Classe: `Curso`

- `string Codigo`
- `string Nome`
- `string Tipo` (Valores aceitos: "Graduação" ou "Pós-graduação")
- `List<Disciplina> Disciplinas`
- `List<Aluno> AlunosMatriculados`

### 5. Classe: `Disciplina`

- `string Codigo`
- `string Nome`
- `int CargaHoraria`
- `Professor ProfessorResponsavel`

### 6. Classe: `Matricula`

- `Aluno AlunoAssociado`
- `Curso CursoAssociado`
- `Boletim BoletimEspecifico`

### 7. Classe: `Boletim`

- `Dictionary<Disciplina, double> Notas` (Guarda a disciplina e a nota tirada)
- `Dictionary<Disciplina, string> Situacao` (Guarda se está "Aprovado" ou "Reprovado")

## 📌 Padrões de Validação Obrigatórios

- **Validação de Unicidade:** Métodos que barram repetição de CPF, Matrícula, Registro, Código do Curso e Código da Disciplina.
- **Formatação de Texto:** Sempre usar `.Trim().ToUpper()` antes de salvar ou comparar códigos de cursos e disciplinas (ex: "ADS").
- **Validação de Nota:** Bloquear qualquer entrada menor que 0 ou maior que 10.
