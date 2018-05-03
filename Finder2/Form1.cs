using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using System.Xml;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;


namespace Finder2
{
    public partial class Form1 : Form
    {
        
        private string _fileRegEx;
        private string _directoryForSearch;
        private string _compareString;

        private TimeSpan timePassed;
        private int filesCount;
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
       // private BackgroundWorker backgroundWorker1;
        private XmlDocument AppData;
        private static ManualResetEvent PauseWorker = new ManualResetEvent(true);
        private BlockingCollection<Searcher.CurrentState> queueState;
        private CancellationTokenSource token;
        private System.Timers.Timer timer1;



        public Form1()
        {
            LoadSearchParameters();
            InitializeComponent();
        }


        //Метод потребитель для Consumer/Produ
        void Consumer()
        {
            while(!token.IsCancellationRequested)
                
            {
                var s = queueState.Take();
                filesCount++;
                if (InvokeRequired)
                {

                   
                    BeginInvoke(new Action(() => CurrentFile.Text = s.CurrentFile));
                    BeginInvoke(new Action(() => WordsCounted.Text = filesCount.ToString()));
                    timeLabel.BeginInvoke(new Action(() => timeLabel.Text = timePassed.ToString()));
                    if (s.isMatched)
                    {
                        BeginInvoke(new Action(() =>
                        {
                            string pathToFile = s.CurrentFile.Remove(
                                s.CurrentFile.IndexOf(treeView1.Nodes[0].Text),
                                treeView1.Nodes[0].Text.Length + 1);
                            List<string> pathDirectories = new List<string>(pathToFile.Split('\\'));
                            AddNodePathToFile(pathDirectories, treeView1.Nodes[0]);
                        }));
                    }
                }
                else
                {
                    timeLabel.Text = timePassed.ToString();
                    CurrentFile.Text = s.CurrentFile;
                    WordsCounted.Text = filesCount.ToString();
                }
            }
        }
    }
}
