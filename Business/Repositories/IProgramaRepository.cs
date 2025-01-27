using System.Collections.Generic;

public interface IProgramaRepository
{
    void SalvarProgramasCustomizados(List<ProgramaAquecimento> programas);
    List<ProgramaAquecimento> CarregarProgramasCustomizados();
}