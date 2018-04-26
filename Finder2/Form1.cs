using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using System.Xml;
using System;
using System.IO;
using System.Collections.Generic;

namespace Finder2
{
    public partial class Form1 : Form
    {
        private TimeSpan timePassed = new TimeSpan(0,0,0,0);
        private string _fileRegEx;
        private string _directoryForSearch;
        private string _compareString;

        private Label label2;
        private Label timeLabel;
        private Label label3;
        private TreeView treeView1;
        private ImageList imageList1;
        private TextBox WordsCounted;
        private TextBox CompareString;
        private TextBox CurrentFile;
        internal Button btnSearch;
        internal TextBox txtFile;
        internal Label lblFile;
        internal Label lblDirectory;
        internal ComboBox cboDirectory;
        private Label label1;
        private Button Cancel;
        private Button btnPause;
        private BackgroundWorker backgroundWorker1;
        private XmlDocument AppData;
        private static ManualResetEvent PauseWorker = new ManualResetEvent(true);


        public Form1()
        {
            LoadSearchParameters();
            InitializeComponent();

        }

        //Проверяем изменение объекта  state в Searcher
        private void backgroundWorker1_ProgressChanged_1(object sender, ProgressChangedEventArgs e)
        {
            Searcher.CurrentState state =
                (Searcher.CurrentState)e.UserState;
            this.WordsCounted.Text = state.FilesCounted.ToString();
            this.CurrentFile.Text = state.CurrentFile;
            //Если в файле были совпадения, отрисовываем путь в TreeView
            if (state.isMatched)
            {
                string pathToFile = state.CurrentFile.Remove(
                    state.CurrentFile.IndexOf(treeView1.Nodes[0].Text),
                    treeView1.Nodes[0].Text.Length + 1);
                List<string> pathDirectories = new List<string>(pathToFile.Split('\\'));
                AddNodePathToFile(pathDirectories, treeView1.Nodes[0]);
            }

        }
         
        private void backgroundWorker1_RunWorkerCompleted_1(object sender, RunWorkerCompletedEventArgs e)
        {
            timer1.Stop();

            if (e.Error != null)
                MessageBox.Show("Error: " + e.Error.Message);
            else if (e.Cancelled)
                MessageBox.Show("Word counting canceled.");
            else
                MessageBox.Show("Finished counting words.");
            SetDefaultButtonStatus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timePassed = timePassed.Add(TimeSpan.FromMilliseconds(10)); 
            timeLabel.Text = timePassed.ToString(@"hh\:mm\:ss\:ff");
        }

       

    }
}
