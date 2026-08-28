using System.Collections.Generic;

public class Boletim
{
    public Dictionary<Disciplina, double> Notas { get; set; } = new Dictionary<Disciplina, double>();
    public Dictionary<Disciplina, string> Situacao { get; set; } = new Dictionary<Disciplina, string>();


}  
