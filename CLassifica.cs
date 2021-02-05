using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace Snake
{
    public partial class Classifica : Form
    {
        private Ranking ranking = new Ranking();
        private RootNomiFile rootNomiFile = new RootNomiFile();
        private int numLivello;
        public Classifica(int numLivello)
        {
            InitializeComponent();
            this.numLivello = numLivello;
        }

        private void Classifica_Load(object sender, EventArgs e)
        {
            lblSelezioneLivello.Location = new Point(Width / 2 - lblSelezioneLivello.Width - 15, lblSelezioneLivello.Location.Y);
            cmbLevelSelected.Location = new Point(Width / 2 + 15, lblSelezioneLivello.Location.Y);
            frmSnake.GetNomiFile(ref rootNomiFile);
            for (int i = 0; i < rootNomiFile.nomeFileDaLeggere.Count; i++)
            {
                cmbLevelSelected.Items.Add(i);
            }
            cmbLevelSelected.SelectedIndex = 0;

            frmSnake.ReadClassifica(ref ranking, 0);
            //dataGridViewClassifica.ColumnCount = 2;
            AddRows(ref dataGridViewClassifica, ref ranking);
        }

        private void cmbLevelSelected_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridViewClassifica.Rows.Clear();
                if (!frmSnake.ReadClassifica(ref ranking, cmbLevelSelected.SelectedIndex))
                    MessageBox.Show("Il livello selezionato non è ancora stato giocato. Provalo ora!",
                    "Classifica non trovata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                else
                    AddRows(ref dataGridViewClassifica, ref ranking);
            }
            catch (FileNotFoundException)
            {

            }
            catch (IOException)
            {

            }
        }

        private void AddRows(ref DataGridView dgv, ref Ranking r)
        {
            dgv.Rows.Clear();
            for (int i = 0; i < r.ClassificaPunteggi.Count; i++)
            {
                string temp = r.ClassificaPunteggi[i].NomePlayer + "|" + r.ClassificaPunteggi[i].PunteggioPlayer;
                dgv.Rows.Add(temp.Split('|'));
            }
        }
    }
}
