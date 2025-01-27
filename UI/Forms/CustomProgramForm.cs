using System;
using System.Windows.Forms;
using MicroondasApp.Business.Models;
using MicroondasApp.Business.Controllers;


namespace MicroondasApp
{
    public partial class CustomProgramForm : Form
    {
        private readonly ControladorMicroondas _controlador;
        public IProgramaAquecimento NovoPrograma { get; private set; }

        public CustomProgramForm(ControladorMicroondas controlador)
        {
            InitializeComponent();
            _controlador = controlador;
            ConfigurarValidacoes();

            // Remover event handlers não utilizados
            labelTempo.Click -= labelTempo_Click;
            labelInstrucoes.Click -= labelInstrucoes_Click;
        }

        private void ConfigurarValidacoes()
        {
            txtTempo.KeyPress += ValidarEntradaNumerica;
            txtPotencia.KeyPress += ValidarEntradaNumerica;
        }

        private void ValidarEntradaNumerica(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCamposObrigatorios();
                char caractere = ValidarCaractere(txtCaractere.Text);

                NovoPrograma = new IProgramaAquecimento(
                    txtNome.Text,
                    txtAlimento.Text,
                    int.Parse(txtTempo.Text),
                    int.Parse(txtPotencia.Text),
                    caractere,
                    txtInstrucoes.Text,
                    true
                );

                _controlador.AdicionarProgramaCustomizado(NovoPrograma);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidarCamposObrigatorios()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                string.IsNullOrWhiteSpace(txtAlimento.Text) ||
                string.IsNullOrWhiteSpace(txtTempo.Text) ||
                string.IsNullOrWhiteSpace(txtPotencia.Text) ||
                string.IsNullOrWhiteSpace(txtCaractere.Text) ||
                string.IsNullOrWhiteSpace(txtInstrucoes.Text))
            {
                throw new ArgumentException("Preencha todos os campos obrigatórios!");
            }
        }

        private char ValidarCaractere(string input)
        {
            if (input.Length != 1)
                throw new ArgumentException("Caractere deve ser um único caractere!");

            char caractere = input[0];

            if (caractere == '.' || char.IsWhiteSpace(caractere))
                throw new ArgumentException("Caractere reservado ou inválido!");

            if (_controlador.VerificarCaractereRepetido(caractere))
                throw new ArgumentException($"Caractere '{caractere}' já está em uso!");

            return caractere;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void labelTempo_Click(object sender, EventArgs e) { }
        private void labelInstrucoes_Click(object sender, EventArgs e) { }
    }
}