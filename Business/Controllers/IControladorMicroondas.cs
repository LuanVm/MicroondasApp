using System.Collections.Generic;

public interface IControladorMicroondas
{
    Aquecimento AquecimentoAtual { get; }
    void IniciarAquecimento(int tempo, int potencia);
    void IniciarProgramaPredefinido(string nomePrograma);
    void IniciarProgramaCustomizado(string nomePrograma);
    void PausarAquecimento();
    void CancelarAquecimento();
    List<ProgramaAquecimento> ListarProgramasPredefinidos();
    List<ProgramaAquecimento> ListarProgramasCustomizados();
    void AdicionarProgramaCustomizado(ProgramaAquecimento programa);
    void RemoverProgramaCustomizado(string nome);
}