using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Finder2
{

    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Timer timer1;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.lblFile = new System.Windows.Forms.Label();
            this.lblDirectory = new System.Windows.Forms.Label();
            this.cboDirectory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Cancel = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.WordsCounted = new System.Windows.Forms.TextBox();
            this.CompareString = new System.Windows.Forms.TextBox();
            this.CurrentFile = new System.Windows.Forms.TextBox();
            this.btnPause = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timeLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(605, 278);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Поиск";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(8, 40);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(120, 20);
            this.txtFile.TabIndex = 4;
            // 
            // lblFile
            // 
            this.lblFile.Location = new System.Drawing.Point(8, 16);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(144, 16);
            this.lblFile.TabIndex = 5;
            this.lblFile.Text = "Маска имени файла:";
            // 
            // lblDirectory
            // 
            this.lblDirectory.Location = new System.Drawing.Point(8, 96);
            this.lblDirectory.Name = "lblDirectory";
            this.lblDirectory.Size = new System.Drawing.Size(120, 23);
            this.lblDirectory.TabIndex = 3;
            this.lblDirectory.Text = "Директория:";
            // 
            // cboDirectory
            // 
            this.cboDirectory.DropDownWidth = 112;
            this.cboDirectory.Location = new System.Drawing.Point(8, 122);
            this.cboDirectory.Name = "cboDirectory";
            this.cboDirectory.Size = new System.Drawing.Size(120, 21);
            this.cboDirectory.TabIndex = 2;
            this.cboDirectory.Text = "ComboBox1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Строка для поиска:";
            // 
            // Cancel
            // 
            this.Cancel.Enabled = false;
            this.Cancel.Location = new System.Drawing.Point(439, 278);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(74, 23);
            this.Cancel.TabIndex = 8;
            this.Cancel.Text = "Завершить";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged_1);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted_1);
            // 
            // WordsCounted
            // 
            this.WordsCounted.Location = new System.Drawing.Point(354, 271);
            this.WordsCounted.Name = "WordsCounted";
            this.WordsCounted.Size = new System.Drawing.Size(41, 20);
            this.WordsCounted.TabIndex = 10;
            // 
            // CompareString
            // 
            this.CompareString.Location = new System.Drawing.Point(8, 182);
            this.CompareString.Name = "CompareString";
            this.CompareString.Size = new System.Drawing.Size(100, 20);
            this.CompareString.TabIndex = 11;
            // 
            // CurrentFile
            // 
            this.CurrentFile.Location = new System.Drawing.Point(184, 16);
            this.CurrentFile.Name = "CurrentFile";
            this.CurrentFile.Size = new System.Drawing.Size(496, 20);
            this.CurrentFile.TabIndex = 12;
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(524, 278);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 13;
            this.btnPause.Text = "Пауза";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Файлов обработано:";
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(159, 274);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(64, 13);
            this.timeLabel.TabIndex = 15;
            this.timeLabel.Text = "00:00:00:00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Времени прошло:";
            // 
            // treeView1
            // 
            this.treeView1.ImageKey = "folderIco.png";
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(184, 47);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(496, 215);
            this.treeView1.TabIndex = 17;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folderIco.png");
            this.imageList1.Images.SetKeyName(1, "FileIco.png");
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(705, 313);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.CurrentFile);
            this.Controls.Add(this.CompareString);
            this.Controls.Add(this.WordsCounted);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.lblDirectory);
            this.Controls.Add(this.cboDirectory);
            this.Name = "Form1";
            this.Text = "Поиск в тексте файлов";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private void btnSearch_Click(object sender, System.EventArgs e)
        {

            txtFile.Enabled = false;
            cboDirectory.Enabled = false;
            btnSearch.Text = "Поиск...";
            this.Cursor = Cursors.WaitCursor;
            btnSearch.Enabled = false;
            CompareString.Enabled = false;
            btnPause.Enabled = true;
            Application.DoEvents();
            SaveSearchParameters();
            timePassed = new TimeSpan(0,0,0,0);
            Cancel.Enabled = true;
            treeView1.Nodes.Clear();
            timer1.Start();
            PopulateTreeView();
            StartThread();


        }
        private void SetPause()
        {
            btnPause.Text = "Продолжить";
            PauseWorker.Reset();
            timer1.Stop();
        }
        private void SetContinue()
        {
            btnPause.Text = "Пауза";
            PauseWorker.Set();
            timer1.Start();
        }
        private void btnPause_Click(object sender, EventArgs e)
        {
            if (btnPause.Text == "Пауза") SetPause();
            else SetContinue();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            SetContinue();
            this.backgroundWorker1.CancelAsync();
            Cancel.Enabled = false;
            
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            cboDirectory.Items.Clear();
            foreach (string s in Directory.GetLogicalDrives())
            {
                cboDirectory.Items.Add(s);
            }
            cboDirectory.Text = _directoryForSearch;
            txtFile.Text = _fileRegEx;
            CompareString.Text = _compareString;
        }



        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker;
            worker = (BackgroundWorker)sender;

            Searcher searcher = (Searcher)e.Argument;
            searcher.CountFiles(worker, e, PauseWorker);
        }

        private void StartThread()
        {

            this.WordsCounted.Text = "0";


            Searcher searcher = new Searcher();
            searcher.CompareString = this.CompareString.Text;
            searcher.SourceDirectory = this.cboDirectory.Text;
            searcher.CompareFileName = this.txtFile.Text;
            


            // Start the asynchronous operation.
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync(searcher);
            else
                MessageBox.Show("Еще не готово, повторите позже");
        }

        private void SetDefaultButtonStatus()
        {
            btnSearch.Text = "Поиск";
            this.Cursor = Cursors.Default;
            txtFile.Enabled = true;
            cboDirectory.Enabled = true;
            btnSearch.Enabled = true;
            CompareString.Enabled = true;
            btnPause.Enabled = false;
            Cancel.Enabled = false;
        }
        //сохранение параметров поиска
        private void SaveSearchParameters()
        {
            XmlElement xmlData = AppData.DocumentElement;
            xmlData.SelectSingleNode("fileName").InnerText = txtFile.Text;
            xmlData.SelectSingleNode("directory").InnerText = cboDirectory.Text;
            xmlData.SelectSingleNode("compareString").InnerText = CompareString.Text;
            AppData.Save("..\\..\\AppData.xml");
        }

        // загрузка последних параметров поиска
        private void LoadSearchParameters()
        {
            try
            {
                AppData = new XmlDocument();
                AppData.Load("..\\..\\AppData.xml");
                XmlElement xmlData = AppData.DocumentElement;
                _fileRegEx = xmlData.SelectSingleNode("fileName").InnerText;
                _directoryForSearch = xmlData.SelectSingleNode("directory").InnerText;
                _compareString = xmlData.SelectSingleNode("compareString").InnerText;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                _fileRegEx = "*.txt";
                _directoryForSearch = "C:\\";
                _compareString = String.Empty;
            }
        }

        private void PopulateTreeView()
        {
            TreeNode rootNode;

            DirectoryInfo info = new DirectoryInfo(cboDirectory.Text);
            if (info.Exists)
            {
                rootNode = new TreeNode(info.FullName);
                rootNode.Tag = info;
                treeView1.Nodes.Add(rootNode);
            }
        }
        //Проверяем есть ли в коллекции нода соответствующая строке
        private int MatchNodes(string Name, TreeNodeCollection Nodes)
        {
            foreach (TreeNode node in Nodes)
                if (node.Text == Name)
                    return Nodes.IndexOf(node);
            return -1;
        }

        //Добавляем узел по адресу файла
        private void AddNodes(List<string> subDirs, TreeNode nodeToAddTo)
        {
            TreeNode aNode;
            int dirIndex = subDirs.Count-1;
            foreach (string subDir in subDirs)
            {
                aNode = new TreeNode(subDir);
                if (subDirs.IndexOf(subDir) == dirIndex)
                    aNode.ImageKey = "FileIco.png";
                nodeToAddTo.Nodes.Add(aNode);
                nodeToAddTo = nodeToAddTo.Nodes[nodeToAddTo.Nodes.IndexOf(aNode)];
                

            }
        }

        //Заполняем  TreeView в реальном времени
        private void AddNodePathToFile(List<string> pathDirectories, TreeNode mainNode)
        {
            bool createdFlag = false;

            if (mainNode.Nodes.Count == 0)
            {
                AddNodes(pathDirectories, mainNode);
                return;
            }
            foreach (string dirString in pathDirectories)
            {
                if (!createdFlag)
                {
                    int nodeIndex = MatchNodes(dirString, mainNode.Nodes);
                    if (nodeIndex != -1)
                    {
                        List<string> pathDirectoriesCuted = pathDirectories.GetRange(pathDirectories.IndexOf(dirString) + 1, pathDirectories.Count - 1);
                        AddNodePathToFile(pathDirectoriesCuted, mainNode.Nodes[nodeIndex]);
                        return;
                    }
                    else
                    {
                        AddNodes(pathDirectories, mainNode);
                        createdFlag = true;
                        return;
                    }
                }
                else return;
            }
        }

    }
}

   



