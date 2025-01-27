using System.Collections.Generic;
using MicroondasApp.Business.Models;

namespace MicroondasApp.Business.Controllers
{
    public interface IControladorMicroondas
    {
        ProgramaAquecimento AquecimentoAtual { get; }
        void IniciarAquecimento(int tempo, int potencia);
        void IniciarProgramaPredefinido(string nomePrograma);
        void IniciarProgramaCustomizado(string nomePrograma);
        void PausarAquecimento();
        void CancelarAquecimento();
        List<IProgramaAquecimento> ListarProgramasPredefinidos();
        List<IProgramaAquecimento> ListarProgramasCustomizados();
        void AdicionarProgramaCustomizado(IProgramaAquecimento programa);
        void RemoverProgramaCustomizado(string nome);
    }
}