using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;


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
        private string line = "";
        private CurrentState state = new CurrentState();
        private DateTime lastReportDateTime = DateTime.Now;

        public void CountFiles(
       CancellationTokenSource token, ManualResetEvent PauseWorker, BlockingCollection<CurrentState> queueState)
        {
            ParallelOptions po = new ParallelOptions
            {
                CancellationToken = token.Token,
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };
            
            // Initialize the variables.
            if (CompareString == null ||
                CompareString == System.String.Empty)
            {
                throw new Exception("CompareString not specified.");
            }
            FileSearch(SourceDirectory, PauseWorker, po, queueState);
            token.Cancel();
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
        public void FileSearch(
            string SourceDirectory,
            ManualResetEvent PauseWorker,
            ParallelOptions po, 
            BlockingCollection<CurrentState> queueState
            )
        {
            try
            {
                Parallel.ForEach(Directory.GetFiles(SourceDirectory, CompareFileName), po, (file) =>
               {
                   PauseWorker.WaitOne();

                   {
                        //Создаем  State Object и добавляем его в очередь
                        CurrentState newState = new CurrentState();
                       newState.CurrentFile = file;
                       newState.isMatched = Matching(file, CompareString);
                       newState.CurrentDirectory = SourceDirectory;
                       queueState.Add(newState);
                       po.CancellationToken.ThrowIfCancellationRequested();

                   }
               });
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
                        Parallel.ForEach(Directory.GetFiles(SourceDirectory, CompareFileName), po, (file) =>
                        {
                            PauseWorker.WaitOne();
                            {
                                CurrentState newState = new CurrentState();
                                newState.CurrentFile = file;
                                newState.isMatched = Matching(file, CompareString);
                                newState.CurrentDirectory = directory;
                                queueState.Add(newState);
                                po.CancellationToken.ThrowIfCancellationRequested();
                            }
                        });
                    }
                    catch (Exception excpt)
                    {
                        Console.WriteLine(excpt.Message);
                    }
                    po.CancellationToken.ThrowIfCancellationRequested();
                    FileSearch(directory, PauseWorker, po, queueState);   
                }
            }
            catch (Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }

    }
}
