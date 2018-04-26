using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finder2
{
    class Searcher
    {
        public class CurrentState
        {
            public string TimePassed;
            public int FilesCounted;
            public string CurrentFile;
            public string CurrentDirectory;
            public bool isMatched;
        }
        public string SourceDirectory;
        public string CompareString;
        public string CompareFileName;
        private int FilesCount;
        private string line = "";
        private CurrentState state = new CurrentState();
        private DateTime lastReportDateTime = DateTime.Now;

        public void CountFiles(
       System.ComponentModel.BackgroundWorker worker,
       System.ComponentModel.DoWorkEventArgs e, ManualResetEvent PauseWorker)
        {
            // Initialize the variables.

            if (CompareString == null ||
                CompareString == System.String.Empty)
            {
                throw new Exception("CompareString not specified.");
            }
            FileSearch(worker, e, SourceDirectory, PauseWorker);
               

        }
        private bool Matching(
        string file,
        string CompareString)
        {

            using (StreamReader myStream = new StreamReader(file))
            {
                while (!myStream.EndOfStream)
                {
                    line = myStream.ReadLine();
                    string EscapedCompareString =
                        System.Text.RegularExpressions.Regex.Escape(CompareString);

                    System.Text.RegularExpressions.Regex regex;
                    regex = new System.Text.RegularExpressions.Regex(
                        @"\b" + EscapedCompareString + @"\b",
                        System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                    System.Text.RegularExpressions.MatchCollection matches;
                    matches = regex.Matches(line);
                    if (matches.Count > 0)
                        return true;
                }
                return false;
            }
        }

        //Метод для рекурсивного поиска в потоке
        public void FileSearch(System.ComponentModel.BackgroundWorker worker,
       System.ComponentModel.DoWorkEventArgs e, string SourceDirectory, ManualResetEvent PauseWorker)
        {
            try
            {
                foreach (string file in Directory.GetFiles(SourceDirectory, CompareFileName))
                {
                    PauseWorker.WaitOne();

                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                    else
                    {
                        FilesCount += 1;
                        // Вызываем событие BW сообщаем об изменении
                        Thread.Sleep(500);
                        
                        state.TimePassed = DateTime.Today.ToLongTimeString();
                        state.FilesCounted = FilesCount;
                        state.CurrentFile = file;
                        state.isMatched = Matching(file, CompareString);
                        state.CurrentDirectory = SourceDirectory;
                        worker.ReportProgress(0, state);
                        lastReportDateTime = DateTime.Now;

                        
                    }
                }
            }
            catch (Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
            try
            {
                foreach (string directory in Directory.GetDirectories(SourceDirectory))
                {
                    try
                    {
                        foreach (string file in Directory.GetFiles(directory, CompareFileName))
                        { 
                            PauseWorker.WaitOne();

                            if (worker.CancellationPending)
                            {
                                e.Cancel = true;
                                return;
                            }
                            else
                            {
                                FilesCount += 1;
                                Thread.Sleep(500);
                                // Вызываем событие BW сообщаем об изменении
                                
                                state.TimePassed = DateTime.Today.ToLongTimeString();
                                state.FilesCounted = FilesCount;
                                state.CurrentFile = file;
                                state.isMatched = Matching(file, CompareString);
                                Console.WriteLine(state.isMatched);
                                Console.WriteLine(file);
                                state.CurrentDirectory = directory;
                                worker.ReportProgress(0, state);
                                lastReportDateTime = DateTime.Now;

                                
                            }
                        }
                    }
                    catch (Exception excpt)
                    {
                        Console.WriteLine(excpt.Message);
                    }
                    FileSearch(worker, e, directory, PauseWorker);
                }
            }
            catch (Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }

        
        }

    }
}
