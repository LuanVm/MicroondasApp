using System;
using System.Windows.Forms;

namespace MicroondasApp
{
    public partial class CustomProgramForm : Form
    {
        private readonly ControladorMicroondas _controlador;

        public ProgramaAquecimento ProgramaCriado { get; private set; }

        public CustomProgramForm(ControladorMicroondas controlador)
        {
            InitializeComponent();
            _controlador = controlador;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCamposObrigatorios();
                char caractere = ValidarCaractere(txtCaractere.Text);

                // 1. Atribuir o novo programa à propriedade ProgramaCriado
                ProgramaCriado = new ProgramaAquecimento(
                    nome: txtNome.Text,
                    alimento: txtAlimento.Text,
                    tempoSegundos: int.Parse(txtTempo.Text), // Nome do parâmetro corrigido
                    potencia: int.Parse(txtPotencia.Text),
                    caractereAquecimento: caractere,
                    instrucoes: txtInstrucoes.Text,
                    isCustomizado: true
                );

                // 2. Passar o objeto correto para o controlador
                _controlador.AdicionarProgramaCustomizado(ProgramaCriado);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ArgumentException ex)
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
                string.IsNullOrWhiteSpace(txtInstrucoes.Text)) // Adicione esta linha
            {
                throw new ArgumentException("Preencha todos os campos obrigatórios!");
            }

            // Verificar se tempo e potência são números válidos
            if (!int.TryParse(txtTempo.Text, out int tempo) || tempo < 1 || tempo > 6000)
                throw new ArgumentException("Tempo inválido (1-6000 segundos)");

            if (!int.TryParse(txtPotencia.Text, out int potencia) || potencia < 1 || potencia > 10)
                throw new ArgumentException("Potência inválida (1-10)");
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

        private void btnCancelar_Click(object sender, EventArgs e) => Close();

        private void labelTempo_Click(object sender, EventArgs e)
        {

        }

        private void labelInstrucoes_Click(object sender, EventArgs e)
        {

        }
    }
}