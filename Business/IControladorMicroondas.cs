using System.Collections.Generic;

public interface IControladorMicroondas
{
    void IniciarAquecimento(int tempo, int potencia);
    void IniciarProgramaPredefinido(string nomePrograma);
    void PausarAquecimento();
    void CancelarAquecimento();
    List<ProgramaAquecimento> ListarProgramasPredefinidos();
}
