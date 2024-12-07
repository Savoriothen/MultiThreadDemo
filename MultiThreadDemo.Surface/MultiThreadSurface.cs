using System.Collections.Concurrent;
using System.Diagnostics;
using MultiThread.Core;

namespace MultiThreadDemo.Surface;

public partial class MultiThreadSurface : Form
{
    #region Fields
    BlockingCollection<string> _filenames = new();
    ConcurrentDictionary<string, List<string>?> _hashesWithFilenames = new();
    private long _elapsedMillisecond;
    private string _directoryPath=string.Empty;
    private decimal _threadCount=1;
    private readonly List<Task> _tasks;
    private CancellationTokenSource? _cancellationTokenSource;
    bool _processStopped;
    #endregion
    
    #region Constructor
    public MultiThreadSurface()
    {
        _tasks = new List<Task>();
        InitializeComponent();
        _cancellationTokenSource = null;
    }
    #endregion
    
    #region Buttons
    private void btnSelectFolder_Click(object sender, EventArgs e)
    {
        
        FolderBrowserDialog folderBrowserDialog = new();
        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
            tbSelectedFolder.Text = folderBrowserDialog.SelectedPath;
            _directoryPath=tbSelectedFolder.Text;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }
    }
    
    private async void btnStart_Click(object sender, EventArgs e)
    {
        if (_cancellationTokenSource != null && !_cancellationTokenSource.Token.IsCancellationRequested)
        {
            return;
        }

        BeforeStart();
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        try
        {
            
            var producerTask = Task.Run(() =>
            {
                if (_cancellationTokenSource != null) ReadData(_cancellationTokenSource.Token);
            });

            for (int i = 0; i < _threadCount; i++)
            {
                int taskId = i;
                _tasks.Add(Task.Run(() =>
                {
                    if (_cancellationTokenSource != null) ProcessData(taskId, _cancellationTokenSource.Token);
                }));
            }
            _tasks.Add(producerTask);
            await Task.WhenAll(_tasks);

        }
        finally
        {
            _cancellationTokenSource = null;
        }
        
        stopwatch.Stop();
        _elapsedMillisecond = stopwatch.ElapsedMilliseconds;
        lblElapsedTime.Text = $@"Elapsed time:{_elapsedMillisecond.ToString()} ms";
        tbResult.Text = GenerateSha1Hash.ResultStringCreator(ref _hashesWithFilenames);
        _tasks.Clear();
        SetControls();

    }
    
    private void btnStop_Click(object sender, EventArgs e)
    {
        try
        {
            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();

                Task.WhenAll(_tasks).ContinueWith(_ =>
                {
                    this.Invoke((Action)(() =>
                    {
                        tbResult.Text = GenerateSha1Hash.ResultStringCreator(ref _hashesWithFilenames);
                    }));
                });
            }
        }
        finally
        {
            _cancellationTokenSource = null;
            _tasks.Clear();
        }
        SetControls();
    }
    #endregion
    
    #region BusinessLogic
    private void ReadData(CancellationToken token)
    {
        try
        {
            while (!_filenames.IsAddingCompleted && !token.IsCancellationRequested)
            {
                FileOperations.GetFileNames(_directoryPath, ref _filenames);
                _filenames.CompleteAdding();
            }
        }
        catch (OperationCanceledException)
        {
            if (!_processStopped)
            {
                _processStopped = true;
                MessageBox.Show(@"Processing stops");
            }
        }
        finally
        {
            _filenames.CompleteAdding(); 
        }
    }
    private void ProcessData(int taskId, CancellationToken token)
    {
        try
        {
            foreach (var filename in _filenames.GetConsumingEnumerable(token))
            {
                GenerateSha1Hash.GenerateSha1HashToDictionaryFromFileName(filename,ref _hashesWithFilenames,taskId);
            }
        }
        catch (OperationCanceledException)
        {
            if (!_processStopped)
            {
                _processStopped = true;
                MessageBox.Show(@"Processing stops");
            }
        }
    }  
    #endregion
    
    #region Settings
    private void BeforeStart()
    {
        _cancellationTokenSource = new CancellationTokenSource();
        _hashesWithFilenames.Clear();
        _filenames = new BlockingCollection<string>();
        _threadCount=nudThreadNo.Value;
        tbResult.Text=String.Empty;
        lblElapsedTime.Text=string.Empty;
        btnSelectFolder.Enabled=false;
        btnStart.Enabled = false;
        btnStop.Enabled = true;
        nudThreadNo.Enabled = false;  
    }    
    private void SetControls()
    {
        btnStart.Enabled = _directoryPath.Length > 0;
        btnSelectFolder.Enabled=true;
        btnStop.Enabled = false;
        nudThreadNo.Enabled = true;
    }
    #endregion
 
}
