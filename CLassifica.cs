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
        private int numLivello;
        public Classifica(int numLivello)
        {
            InitializeComponent();
            this.numLivello = numLivello;
        }

        private void cmbClassifica_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadClassifica(ref ranking, cmbClassifica.SelectedIndex);
            for(int i=0;i<ranking.ClassificaPunteggi.Count;i++)
            {
                lstClassifica.Items.Add(ranking.ClassificaPunteggi[i].NomePlayer);
                lstClassifica.Items.Add(ranking.ClassificaPunteggi[i].PunteggioPlayer);
            }
            
        }
        private void ReadClassifica(ref Ranking ranking, int index)
        {
            try
            {
                StreamReader reader = new StreamReader("Data/Classifica/classifica" + index + ".json");
                ranking = JsonConvert.DeserializeObject<Ranking>(reader.ReadToEnd());
                reader.Close();
            }
            catch (FileNotFoundException)
            {

            }
            catch (DirectoryNotFoundException)
            {

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Classifica_Load(object sender, EventArgs e)
        {

        }
    }
}
