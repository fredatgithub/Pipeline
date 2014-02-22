using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Pipeline.Properties;

namespace Pipeline
{
    public partial class DemoForm : Form
    {
        private PipelineController<string> _demo;
        
        private Stopwatch _clock;        
        private int _stagesCount = 4;
        
        public DemoForm()
        {
            InitializeComponent();
            lblDuration.Text = Duration.ToString();

            CreatePipeline();

            CreateProgressTables();            
        }

        private void CreatePipeline()
        {
            _demo = new StageControllerDemo();
            _demo.Completed += DemoPipelineOnCompleted;
        }

        private void CreateProgressTables()
        {
            for (int i = 0; i < _stagesCount; i++)
            {
                string caption = "S" + i.ToString();
                grdProgressMap.Columns.Add(new DataGridViewImageColumn()
                {
                    HeaderText = caption,
                    DefaultCellStyle = new DataGridViewCellStyle() { NullValue = Resources.EmptyIcon, Alignment = DataGridViewContentAlignment.MiddleCenter },
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });
                grdPipelineState.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        HeaderText = caption,
                        Name = caption,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    });
            }

            grdLegend.Rows.Add(Resources.SuccessIcon, "Success");
            grdLegend.Rows.Add(Resources.ErrorIcon, "Error");
            grdLegend.Rows.Add(Resources.CancellationIcon, "Cancellation");
        }

        
        private void StartPipelineClick(object sender, EventArgs e)
        {
            butStart.Enabled = false;
            butStop.Enabled = true;
            
            var items = new List<String>();
            for (int i = 0; i < ItemsCount; i++)
                items.Add(Guid.NewGuid().ToString());

            grdPipelineState.Rows.Clear();
            grdProgressMap.Rows.Clear();

            timerState.Start();            
            _clock = Stopwatch.StartNew();
            _demo.Interval1 = Interval1;
            _demo.Interval2 = Interval2;
            _demo.Interval3 = Interval3;
            _demo.Start(items);
        }

        private void DemoPipelineOnCompleted(object sender, CancelEventArgs e)
        {
            _clock.Stop();
            timerState.Stop();
            MessageBox.Show((_clock.ElapsedMilliseconds * 0.001).ToString("0.000"), string.Format("{0} (seconds)", e.Cancel ? "Cancelled" : "Completed"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            DisplayPipelineState();
            butStart.Enabled = true;
            butStop.Enabled = false;
        } 

        private int ItemsCount { get { return (int)nudItems.Value; } }

        private int Interval1 { get { return (int)nudDuration1.Value * 1000; } }
        private int Interval2 { get { return (int)nudDuration2.Value * 1000; } }
        private int Interval3 { get { return (int)nudDuration3.Value * 1000; } }

        private int Duration { get { return (Math.Max(Interval1, Math.Max(Interval2, Interval3))*(ItemsCount - 1) + Interval1+Interval2+Interval3)/1000; } }

        private void TimerStateTick(object sender, EventArgs e)
        {
            DisplayPipelineState();
        }

        private void DisplayPipelineState()
        {
            grdPipelineState.Rows.Clear();
            grdProgressMap.Rows.Clear();
            int column;
            int row = -1;            
            foreach (var status in _demo.Results.ToArray())
            {
                grdPipelineState.Rows.Add();
                grdProgressMap.Rows.Add();
                row++;
                for(column = 0; column<status.Results.Count; column++)
                {
                    grdPipelineState[column, row].Value = status.Results[column];
                    grdProgressMap[column, row].Value = Resources.SuccessIcon;
                }
                if (status.Error!=null)
                {
                    grdPipelineState[column, row].Value = status.Error.GetType().Name + " " + status.Error.Message;
                    grdProgressMap[column, row].Value = Resources.ErrorIcon;
                }
                else if (status.Cancelled)
                {
                    grdPipelineState[column, row].Value = "cancelled";
                    grdProgressMap[column, row].Value = Resources.CancellationIcon;
                }
            }
        }

        private void StopPipelineClick(object sender, EventArgs e)
        {
            _demo.Cancel();          
        }
        
        private void EstimatedTimeChanged(object sender, EventArgs e)
        {
            lblDuration.Text = Duration.ToString();
        }        
    }
}
