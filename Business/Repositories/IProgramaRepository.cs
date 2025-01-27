using System.Collections.Generic;
using MicroondasApp.Business.Models;

namespace MicroondasApp.Business.Repositories
{
    public interface IProgramaRepository
    {
        void SalvarProgramasCustomizados(List<ProgramaAquecimento> programas);
        List<ProgramaAquecimento> CarregarProgramasCustomizados();
    }
}