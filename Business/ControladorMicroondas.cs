using System.Collections.Generic;

public class ControladorMicroondas : IControladorMicroondas
{
    private Aquecimento _aquecimentoAtual;
    private readonly List<ProgramaAquecimento> _programasPredefinidos;
    private readonly List<ProgramaAquecimento> _programasCustomizados;

    public ControladorMicroondas()
    {
        _programasPredefinidos = new List<ProgramaAquecimento>
        {
            new ProgramaAquecimento("Pipoca", "Pipoca (de micro-ondas)", 180, 7, "*", "Observar o barulho..."),
            // Adicionar outros programas pré-definidos
        };

        _programasCustomizados = new List<ProgramaAquecimento>();
    }

    public void IniciarAquecimento(int tempo, int potencia)
    {
        if (_aquecimentoAtual == null)
        {
            _aquecimentoAtual = new Aquecimento(tempo, potencia);
        }
        else if (_aquecimentoAtual.EmPausa)
        {
            _aquecimentoAtual.EmPausa = false;
        }
        else
        {
            _aquecimentoAtual.AdicionarTempo(30);
        }
    }

    public void PausarAquecimento()
    {
        if (_aquecimentoAtual != null && !_aquecimentoAtual.Concluido)
        {
            _aquecimentoAtual.EmPausa = true;
        }
    }

    public void CancelarAquecimento()
    {
        _aquecimentoAtual = null;
    }

    public string ObterStatus()
    {
        return _aquecimentoAtual?.Atualizar() ?? "Pronto para iniciar";
    }

    public void AdicionarProgramaCustomizado(ProgramaAquecimento programa)
    {
        // Validações para caracteres únicos
        _programasCustomizados.Add(programa);
    }

    public List<ProgramaAquecimento> ListarProgramas() => new List<ProgramaAquecimento>(_programasPredefinidos);
}