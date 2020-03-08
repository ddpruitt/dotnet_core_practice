using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;

namespace DC.SpiroGraph.WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void CreateData(bool useParallel)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var sg = new Core.SpiroGraphGenerator
                {
                    Radius1 = Convert.ToDouble(radius1TextEdit.Text),
                    Radius2 = Convert.ToDouble(radius2TextEdit.Text),
                    Position = Convert.ToDouble(positionTextEdit.Text),
                    Resolution = Convert.ToDouble(resolutionTextEdit.Text)
                };

                
                var endPoints = sg.FindAllEndPoints();
                endPointCountLabel.Text = string.Format("# of End Points: {0}", endPoints.Count());

                var graphPoints = useParallel?  sg.GetSpiroGraphPoints2() : sg.GetSpiroGraphPoints3();
                pointCountLabel.Text = string.Format("# of Points: {0}", graphPoints.Count());

                chartControl1.Series[0].DataSource = graphPoints;

            }
            catch (Exception)
            {

                // Eat It
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var series = chartControl1.Series[0];
            series.Label.Visible = false;
            series.ArgumentDataMember = "X";
            series.ValueDataMembers.AddRange(new string[] {"Y"});


            radius1TextEdit.Text = "60";
            radius2TextEdit.Text = "60";
            positionTextEdit.Text = "60";
            resolutionTextEdit.Text = "270";

            CreateData(true);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            CreateData(true);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            CreateData(false);
        }
    }
}
