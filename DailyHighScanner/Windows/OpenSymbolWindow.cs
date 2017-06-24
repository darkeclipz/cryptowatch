using Cryptowatch.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cryptowatch.App.Windows
{
    public partial class OpenSymbolWindow : Form
    {
        public Symbol Symbol { get; private set; } = new Symbol();
        private List<Symbol> _symbols { get; set; } = new List<Symbol>();

        public OpenSymbolWindow(List<Symbol> symbols)
        {
            InitializeComponent();
            _symbols = symbols;
            comboBox.Items.AddRange(symbols.Select(s => $"{s.Name}@{s.Exchange}").ToArray());
        }

        private void button_Click(object sender, EventArgs e)
        {
            try
            {
                var symbol = comboBox.Text.ToUpper();

                if (!_symbols.Any(s => $"{s.Name}@{s.Exchange}" == symbol))
                {
                    if (_symbols.Any(s => Regex.IsMatch($"{s.Name}@{s.Exchange}", symbol)))
                    {
                        var foundSymbol = _symbols.FirstOrDefault(s => Regex.IsMatch($"{s.Name}@{s.Exchange}", symbol));
                        symbol = $"{foundSymbol.Name}@{foundSymbol.Exchange}";
                    }
                    else
                    {
                        MessageBox.Show("Invalid symbol specified.", "Invalid symbol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                var regex = new Regex("([_a-zA-Z]*)@([a-zA-Z]*)");
                var matches = regex.Match(symbol);
                Symbol.Name = matches.Groups[1].Value;
                Symbol.Exchange = matches.Groups[2].Value;
                DialogResult = DialogResult.OK;
                this.Hide();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OpenSymbol_Load(object sender, EventArgs e)
        {
            comboBox.Focus();
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button_Click(this, null);
            }
        }
    }
}
