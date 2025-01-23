using System;
using System.Windows.Forms;

namespace MicroondasApp
{
    public partial class MainForm : Form
    {
        private readonly ControladorMicroondas _controlador;
        private Timer _timer;

        public MainForm()
        {
            InitializeComponent();
            _controlador = new ControladorMicroondas();
            ConfigurarTimer();
            ConfigurarValoresPadrao();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblMensagens.Text = "Bem-vindo ao micro-ondas!";
        }

        private void ConfigurarTimer()
        {
            _timer = new Timer { Interval = 1000 };
            _timer.Tick += (s, e) => AtualizarInterface();
        }

        private void ConfigurarValoresPadrao()
        {
            txtPotencia.Text = "10";
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                var tempo = ObterTempoValido();
                var potencia = ObterPotenciaValida();

                _controlador.IniciarAquecimento(tempo, potencia);
                _timer.Start();
            }
            catch (ArgumentException ex)
            {
                lblMensagens.Text = ex.Message;
            }
        }

        private int ObterTempoValido()
        {
            if (!int.TryParse(txtTempo.Text, out int tempo) || tempo < 1 || tempo > 120)
                throw new ArgumentException("Tempo inválido! Informe 1-120 segundos");

            return tempo;
        }

        private int ObterPotenciaValida()
        {
            if (string.IsNullOrEmpty(txtPotencia.Text)) return 10;

            if (!int.TryParse(txtPotencia.Text, out int potencia) || potencia < 1 || potencia > 10)
                throw new ArgumentException("Potência inválida! Informe 1-10");

            return potencia;
        }

        private void btnInicioRapido_Click(object sender, EventArgs e)
        {
            _controlador.IniciarAquecimento(30, 10);
            _timer.Start();
            lblMensagens.Text = "Início rápido ativado: 30 segundos na potência 10.";
        }

        private void btnPausarCancelar_Click(object sender, EventArgs e)
        {
            if (_controlador == null)
            {
                lblMensagens.Text = "Nenhum aquecimento em andamento.";
                return;
            }

            if (_timer.Enabled)
            {
                _controlador.PausarAquecimento();
                _timer.Stop();
                lblMensagens.Text = "Aquecimento pausado.";
            }
            else
            {
                _controlador.CancelarAquecimento();
                _timer.Stop();
                lblMensagens.Text = "Aquecimento cancelado.";
            }
        }

        private void AtualizarInterface()
        {
            lblMensagens.Text = _controlador.ObterStatus();
        }

        private void AtualizarContagemRegressiva(object sender, EventArgs e)
        {
            try
            {
                var mensagem = _controlador?.ObterStatus(); // Método correto
                lblMensagens.Text = mensagem;
            }
            catch
            {
                _timer.Stop();
                lblMensagens.Text = "Aquecimento concluído.";
            }
        }

        private void groupBoxConfiguracoes_Enter(object sender, EventArgs e)
        {

        }
    }
}