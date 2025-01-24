﻿using System;

public class Aquecimento
{
    public int TempoTotal { get; private set; }
    public int TempoRestante { get; private set; }
    public int Potencia { get; private set; }
    public bool EmPausa { get; set; }
    public bool Concluido { get; private set; }
    public bool IsPredefinido { get; }
    public string Progresso { get; private set; }

    private DateTime _ultimaAtualizacao;

    public Aquecimento(int tempo, int potencia, bool isPredefinido = false, char caractere = '.')
    {
        if (!isPredefinido && (tempo < 1 || tempo > 120))
            throw new ArgumentException("Tempo deve ser entre 1 e 120 segundos");

        if (potencia < 1 || potencia > 10)
            throw new ArgumentException("Potência deve ser entre 1 e 10");

        TempoTotal = tempo;
        TempoRestante = tempo;
        Potencia = potencia;
        IsPredefinido = isPredefinido;
        Progresso = "Em execução...";
        _ultimaAtualizacao = DateTime.Now;
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

            Progresso = "Em execução..."; // Mensagem fixa
        }

        if (TempoRestante <= 0)
        {
            Concluido = true;
            Progresso = "Aquecimento concluído!";
        }
    }

    public void AdicionarTempo(int segundos)
    {
        if (Concluido || EmPausa || IsPredefinido) return;
        TempoTotal += segundos;
        TempoRestante += segundos;
    }

    public static string FormatarTempo(int segundos)
    {
        int minutos = segundos / 60;
        int segundosRestantes = segundos % 60;
        return $"{minutos:D2}:{segundosRestantes:D2} Restantes";
    }
}
