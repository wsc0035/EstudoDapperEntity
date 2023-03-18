namespace EstudoEntityDapper.Core.Entities;

public class Evento
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public int QtdMax { get; set; }
    public int QtdInscritos { get; set;}
    public DateTime DataEvento { get; set; }
}
