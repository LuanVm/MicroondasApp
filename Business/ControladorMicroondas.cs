using System.Collections.Generic;
using System.Linq;

public class ControladorMicroondas : IControladorMicroondas
{
    public Aquecimento AquecimentoAtual { get; private set; }
    private readonly List<ProgramaAquecimento> _programasCustomizados = new List<ProgramaAquecimento>();

    public ControladorMicroondas()
    {
        _programasCustomizados = new List<ProgramaAquecimento>
        {
            new ProgramaAquecimento("Pipoca", "Pipoca (de micro-ondas)", 180, 7, '*', "Observar o barulho de estouros"),
            new ProgramaAquecimento("Leite", "Leite", 300, 5, '~', "Cuidado com fervura instantânea"),
            new ProgramaAquecimento("Carnes", "Carne em pedaços", 840, 4, '#', "Virar na metade do tempo"),
            new ProgramaAquecimento("Frango", "Frango", 480, 7, '@', "Virar na metade do tempo"),
            new ProgramaAquecimento("Feijão", "Feijão congelado", 480, 9, '&', "Recipiente destampado")
        };
    }

    public void IniciarAquecimento(int tempo, int potencia)
    {
        if (AquecimentoAtual == null)
        {
            AquecimentoAtual = new Aquecimento(tempo, potencia);
        }
        else if (AquecimentoAtual.EmPausa)
        {
            AquecimentoAtual.EmPausa = false;
        }
        else
        {
            AquecimentoAtual.AdicionarTempo(30);
        }
    }

    public void IniciarProgramaPredefinido(string nomePrograma)
    {
        var programa = _programasCustomizados.FirstOrDefault(p => p.Nome == nomePrograma);
        if (programa != null)
        {
            AquecimentoAtual = new Aquecimento(programa.TempoSegundos, programa.Potencia, programa.CaractereAquecimento);
        }
    }

    public void AdicionarProgramaCustomizado(ProgramaAquecimento programa)
    {
        _programasCustomizados.Add(programa);
    }

    public void PausarAquecimento()
    {
        if (AquecimentoAtual != null && !AquecimentoAtual.Concluido)
        {
            AquecimentoAtual.EmPausa = true;
        }
    }

    public void CancelarAquecimento()
    {
        AquecimentoAtual = null;
    }

    public void AdicionarTempo(int segundos)
    {
        AquecimentoAtual?.AdicionarTempo(segundos);
    }

    public List<ProgramaAquecimento> ListarProgramas() => new List<ProgramaAquecimento>(_programasCustomizados);
}