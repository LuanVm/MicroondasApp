using System.Collections.Generic;

public interface IControladorMicroondas
{
    void IniciarAquecimento(int tempo, int potencia);
    void PausarAquecimento();
    void CancelarAquecimento();
    void AdicionarProgramaCustomizado(ProgramaAquecimento programa);
    List<ProgramaAquecimento> ListarProgramas();
}
