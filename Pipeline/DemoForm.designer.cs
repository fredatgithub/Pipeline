namespace Pipeline
{
    partial class DemoForm
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Dispose resources
        /// </summary>
        /// <param name="disposing">True if form should be disposed</param>
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tbcDemo = new System.Windows.Forms.TabControl();
            this.pageSettings = new System.Windows.Forms.TabPage();
            this.grdLegend = new System.Windows.Forms.DataGridView();
            this.ColIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColMeaning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.butStop = new System.Windows.Forms.Button();
            this.butStart = new System.Windows.Forms.Button();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblEstimatedTime = new System.Windows.Forms.Label();
            this.lblStage3 = new System.Windows.Forms.Label();
            this.nudDuration3 = new System.Windows.Forms.NumericUpDown();
            this.lblStage2 = new System.Windows.Forms.Label();
            this.nudDuration2 = new System.Windows.Forms.NumericUpDown();
            this.lblStage1 = new System.Windows.Forms.Label();
            this.nudDuration1 = new System.Windows.Forms.NumericUpDown();
            this.lblItems = new System.Windows.Forms.Label();
            this.nudItems = new System.Windows.Forms.NumericUpDown();
            this.pageProgressMap = new System.Windows.Forms.TabPage();
            this.grdProgressMap = new System.Windows.Forms.DataGridView();
            this.pagePipelineState = new System.Windows.Forms.TabPage();
            this.grdPipelineState = new System.Windows.Forms.DataGridView();
            this.timerState = new System.Windows.Forms.Timer(this.components);
            this.tbcDemo.SuspendLayout();
            this.pageSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLegend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudItems)).BeginInit();
            this.pageProgressMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProgressMap)).BeginInit();
            this.pagePipelineState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPipelineState)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcDemo
            // 
            this.tbcDemo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcDemo.Controls.Add(this.pageSettings);
            this.tbcDemo.Controls.Add(this.pageProgressMap);
            this.tbcDemo.Controls.Add(this.pagePipelineState);
            this.tbcDemo.Location = new System.Drawing.Point(12, 12);
            this.tbcDemo.Name = "tbcDemo";
            this.tbcDemo.SelectedIndex = 0;
            this.tbcDemo.Size = new System.Drawing.Size(680, 384);
            this.tbcDemo.TabIndex = 1;
            // 
            // pageSettings
            // 
            this.pageSettings.Controls.Add(this.grdLegend);
            this.pageSettings.Controls.Add(this.butStop);
            this.pageSettings.Controls.Add(this.butStart);
            this.pageSettings.Controls.Add(this.lblDuration);
            this.pageSettings.Controls.Add(this.lblEstimatedTime);
            this.pageSettings.Controls.Add(this.lblStage3);
            this.pageSettings.Controls.Add(this.nudDuration3);
            this.pageSettings.Controls.Add(this.lblStage2);
            this.pageSettings.Controls.Add(this.nudDuration2);
            this.pageSettings.Controls.Add(this.lblStage1);
            this.pageSettings.Controls.Add(this.nudDuration1);
            this.pageSettings.Controls.Add(this.lblItems);
            this.pageSettings.Controls.Add(this.nudItems);
            this.pageSettings.Location = new System.Drawing.Point(4, 22);
            this.pageSettings.Name = "pageSettings";
            this.pageSettings.Size = new System.Drawing.Size(672, 358);
            this.pageSettings.TabIndex = 2;
            this.pageSettings.Text = "Settings";
            this.pageSettings.UseVisualStyleBackColor = true;
            // 
            // grdLegend
            // 
            this.grdLegend.AllowUserToAddRows = false;
            this.grdLegend.AllowUserToDeleteRows = false;
            this.grdLegend.AllowUserToResizeRows = false;
            this.grdLegend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grdLegend.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grdLegend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLegend.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColIcon,
            this.ColMeaning});
            this.grdLegend.Location = new System.Drawing.Point(287, 10);
            this.grdLegend.Name = "grdLegend";
            this.grdLegend.ReadOnly = true;
            this.grdLegend.RowHeadersVisible = false;
            this.grdLegend.Size = new System.Drawing.Size(373, 99);
            this.grdLegend.TabIndex = 12;
            // 
            // ColIcon
            // 
            this.ColIcon.HeaderText = "Legend";
            this.ColIcon.Name = "ColIcon";
            this.ColIcon.ReadOnly = true;
            // 
            // ColMeaning
            // 
            this.ColMeaning.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColMeaning.HeaderText = "";
            this.ColMeaning.Name = "ColMeaning";
            this.ColMeaning.ReadOnly = true;
            // 
            // butStop
            // 
            this.butStop.Enabled = false;
            this.butStop.Location = new System.Drawing.Point(18, 208);
            this.butStop.Name = "butStop";
            this.butStop.Size = new System.Drawing.Size(75, 23);
            this.butStop.TabIndex = 11;
            this.butStop.Text = "Stop";
            this.butStop.UseVisualStyleBackColor = true;
            this.butStop.Click += new System.EventHandler(this.StopPipelineClick);
            // 
            // butStart
            // 
            this.butStart.Location = new System.Drawing.Point(17, 179);
            this.butStart.Name = "butStart";
            this.butStart.Size = new System.Drawing.Size(75, 23);
            this.butStart.TabIndex = 10;
            this.butStart.Text = "Start";
            this.butStart.UseVisualStyleBackColor = true;
            this.butStart.Click += new System.EventHandler(this.StartPipelineClick);
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(136, 146);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(13, 13);
            this.lblDuration.TabIndex = 9;
            this.lblDuration.Text = "0";
            // 
            // lblEstimatedTime
            // 
            this.lblEstimatedTime.AutoSize = true;
            this.lblEstimatedTime.Location = new System.Drawing.Point(14, 146);
            this.lblEstimatedTime.Name = "lblEstimatedTime";
            this.lblEstimatedTime.Size = new System.Drawing.Size(105, 13);
            this.lblEstimatedTime.TabIndex = 8;
            this.lblEstimatedTime.Text = "Estimated Time (sec)";
            // 
            // lblStage3
            // 
            this.lblStage3.AutoSize = true;
            this.lblStage3.Location = new System.Drawing.Point(14, 90);
            this.lblStage3.Name = "lblStage3";
            this.lblStage3.Size = new System.Drawing.Size(122, 13);
            this.lblStage3.TabIndex = 7;
            this.lblStage3.Text = "3rd Stage Duration (sec)";
            // 
            // nudDuration3
            // 
            this.nudDuration3.Location = new System.Drawing.Point(139, 88);
            this.nudDuration3.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudDuration3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDuration3.Name = "nudDuration3";
            this.nudDuration3.Size = new System.Drawing.Size(120, 20);
            this.nudDuration3.TabIndex = 6;
            this.nudDuration3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDuration3.ValueChanged += new System.EventHandler(this.EstimatedTimeChanged);
            // 
            // lblStage2
            // 
            this.lblStage2.AutoSize = true;
            this.lblStage2.Location = new System.Drawing.Point(14, 64);
            this.lblStage2.Name = "lblStage2";
            this.lblStage2.Size = new System.Drawing.Size(125, 13);
            this.lblStage2.TabIndex = 5;
            this.lblStage2.Text = "2nd Stage Duration (sec)";
            // 
            // nudDuration2
            // 
            this.nudDuration2.Location = new System.Drawing.Point(139, 62);
            this.nudDuration2.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudDuration2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDuration2.Name = "nudDuration2";
            this.nudDuration2.Size = new System.Drawing.Size(120, 20);
            this.nudDuration2.TabIndex = 4;
            this.nudDuration2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDuration2.ValueChanged += new System.EventHandler(this.EstimatedTimeChanged);
            // 
            // lblStage1
            // 
            this.lblStage1.AutoSize = true;
            this.lblStage1.Location = new System.Drawing.Point(14, 38);
            this.lblStage1.Name = "lblStage1";
            this.lblStage1.Size = new System.Drawing.Size(121, 13);
            this.lblStage1.TabIndex = 3;
            this.lblStage1.Text = "1st Stage Duration (sec)";
            // 
            // nudDuration1
            // 
            this.nudDuration1.Location = new System.Drawing.Point(139, 36);
            this.nudDuration1.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudDuration1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDuration1.Name = "nudDuration1";
            this.nudDuration1.Size = new System.Drawing.Size(120, 20);
            this.nudDuration1.TabIndex = 2;
            this.nudDuration1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDuration1.ValueChanged += new System.EventHandler(this.EstimatedTimeChanged);
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Location = new System.Drawing.Point(14, 12);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(58, 13);
            this.lblItems.TabIndex = 1;
            this.lblItems.Text = "Item Count";
            // 
            // nudItems
            // 
            this.nudItems.Location = new System.Drawing.Point(139, 10);
            this.nudItems.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudItems.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudItems.Name = "nudItems";
            this.nudItems.Size = new System.Drawing.Size(120, 20);
            this.nudItems.TabIndex = 0;
            this.nudItems.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudItems.ValueChanged += new System.EventHandler(this.EstimatedTimeChanged);
            // 
            // pageProgressMap
            // 
            this.pageProgressMap.Controls.Add(this.grdProgressMap);
            this.pageProgressMap.Location = new System.Drawing.Point(4, 22);
            this.pageProgressMap.Name = "pageProgressMap";
            this.pageProgressMap.Padding = new System.Windows.Forms.Padding(3);
            this.pageProgressMap.Size = new System.Drawing.Size(672, 358);
            this.pageProgressMap.TabIndex = 0;
            this.pageProgressMap.Text = "Progress Map";
            this.pageProgressMap.UseVisualStyleBackColor = true;
            // 
            // grdProgressMap
            // 
            this.grdProgressMap.AllowUserToAddRows = false;
            this.grdProgressMap.AllowUserToDeleteRows = false;
            this.grdProgressMap.AllowUserToResizeRows = false;
            this.grdProgressMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdProgressMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdProgressMap.Location = new System.Drawing.Point(3, 3);
            this.grdProgressMap.Name = "grdProgressMap";
            this.grdProgressMap.ReadOnly = true;
            this.grdProgressMap.Size = new System.Drawing.Size(666, 352);
            this.grdProgressMap.TabIndex = 0;
            // 
            // pagePipelineState
            // 
            this.pagePipelineState.Controls.Add(this.grdPipelineState);
            this.pagePipelineState.Location = new System.Drawing.Point(4, 22);
            this.pagePipelineState.Name = "pagePipelineState";
            this.pagePipelineState.Padding = new System.Windows.Forms.Padding(3);
            this.pagePipelineState.Size = new System.Drawing.Size(672, 358);
            this.pagePipelineState.TabIndex = 1;
            this.pagePipelineState.Text = "Pipeline State";
            this.pagePipelineState.UseVisualStyleBackColor = true;
            // 
            // grdPipelineState
            // 
            this.grdPipelineState.AllowUserToAddRows = false;
            this.grdPipelineState.AllowUserToDeleteRows = false;
            this.grdPipelineState.AllowUserToResizeRows = false;
            this.grdPipelineState.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPipelineState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPipelineState.Location = new System.Drawing.Point(3, 3);
            this.grdPipelineState.Name = "grdPipelineState";
            this.grdPipelineState.ReadOnly = true;
            this.grdPipelineState.Size = new System.Drawing.Size(666, 352);
            this.grdPipelineState.TabIndex = 1;
            // 
            // timerState
            // 
            this.timerState.Interval = 5000;
            this.timerState.Tick += new System.EventHandler(this.TimerStateTick);
            // 
            // DemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 408);
            this.Controls.Add(this.tbcDemo);
            this.MinimumSize = new System.Drawing.Size(720, 447);
            this.Name = "DemoForm";
            this.Text = "PipelineDemoForm";           
            this.tbcDemo.ResumeLayout(false);
            this.pageSettings.ResumeLayout(false);
            this.pageSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLegend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudItems)).EndInit();
            this.pageProgressMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdProgressMap)).EndInit();
            this.pagePipelineState.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPipelineState)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcDemo;
        private System.Windows.Forms.TabPage pageProgressMap;
        private System.Windows.Forms.TabPage pagePipelineState;
        private System.Windows.Forms.DataGridView grdProgressMap;
        private System.Windows.Forms.DataGridView grdPipelineState;
        private System.Windows.Forms.Timer timerState;
        private System.Windows.Forms.TabPage pageSettings;
        private System.Windows.Forms.Button butStop;
        private System.Windows.Forms.Button butStart;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblEstimatedTime;
        private System.Windows.Forms.Label lblStage3;
        private System.Windows.Forms.NumericUpDown nudDuration3;
        private System.Windows.Forms.Label lblStage2;
        private System.Windows.Forms.NumericUpDown nudDuration2;
        private System.Windows.Forms.Label lblStage1;
        private System.Windows.Forms.NumericUpDown nudDuration1;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.NumericUpDown nudItems;
        private System.Windows.Forms.DataGridView grdLegend;
        private System.Windows.Forms.DataGridViewImageColumn ColIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMeaning;



    }
}

