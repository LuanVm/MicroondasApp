using System;
using System.Text;

public class Aquecimento
{
    public int TempoTotal { get; private set; }
    public int TempoRestante { get; private set; }
    public int Potencia { get; private set; }
    public bool EmPausa { get; set; }
    public bool Concluido { get; private set; }
    public char CaractereAquecimento { get; private set; } = '.';
    public string Progresso => _progresso.ToString();

    private readonly StringBuilder _progresso;
    private DateTime _ultimaAtualizacao;

    public Aquecimento(int tempo, int potencia, char caractere = '.')
    {
        ValidarParametros(tempo, potencia);

        TempoTotal = tempo;
        TempoRestante = tempo;
        Potencia = potencia;
        CaractereAquecimento = caractere;
        _progresso = new StringBuilder();
        _ultimaAtualizacao = DateTime.Now;
    }

    private static void ValidarParametros(int tempo, int potencia)
    {
        if (tempo < 1 || tempo > 120)
            throw new ArgumentException("Tempo deve ser entre 1 e 120 segundos");

        if (potencia < 1 || potencia > 10)
            throw new ArgumentException("Potência deve ser entre 1 e 10");
    }

    public void Atualizar()
    {
        if (Concluido) return;

        var tempoDecorrido = (DateTime.Now - _ultimaAtualizacao).TotalSeconds;

        if (!EmPausa && tempoDecorrido >= 1)
        {
            int segundosDecorridos = (int)tempoDecorrido;
            TempoRestante -= segundosDecorridos;
            _ultimaAtualizacao = DateTime.Now;

            for (int i = 0; i < segundosDecorridos; i++)
            {
                _progresso.Append(new string(CaractereAquecimento, Potencia) + " ");
            }
        }

        if (TempoRestante <= 0)
        {
            Concluido = true;
            _progresso.Append(" Aquecimento concluído!");
        }
    }

    public void DefinirCaractere(char novoCaractere)
    {
        if (novoCaractere != '.' && !char.IsWhiteSpace(novoCaractere))
            CaractereAquecimento = novoCaractere;
    }

    public void AdicionarTempo(int segundos)
    {
        if (Concluido || EmPausa) return;
        TempoTotal += segundos;
        TempoRestante += segundos;
    }

    public static string FormatarTempo(int segundos)
    {
        int minutos = segundos / 60;
        int segundosRestantes = segundos % 60;
        return segundos > 60 ? $"{minutos}:{segundosRestantes:D2}" : $"{segundos} seg";
    }
}