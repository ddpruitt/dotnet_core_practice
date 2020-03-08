namespace DC.SpiroGraph.WinForm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel1 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.ScatterLineSeriesView scatterLineSeriesView1 = new DevExpress.XtraCharts.ScatterLineSeriesView();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel2 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.endPointCountLabel = new DevExpress.XtraEditors.LabelControl();
            this.pointCountLabel = new DevExpress.XtraEditors.LabelControl();
            this.radius2TextEdit = new DevExpress.XtraEditors.SpinEdit();
            this.resolutionTextEdit = new DevExpress.XtraEditors.SpinEdit();
            this.radius1TextEdit = new DevExpress.XtraEditors.SpinEdit();
            this.positionTextEdit = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(scatterLineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radius2TextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resolutionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radius1TextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // chartControl1
            // 
            this.chartControl1.AppearanceNameSerializable = "Northern Lights";
            xyDiagram1.AxisX.Range.ScrollingRange.SideMarginsEnabled = true;
            xyDiagram1.AxisX.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.Range.ScrollingRange.SideMarginsEnabled = true;
            xyDiagram1.AxisY.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Legend.Visible = false;
            this.chartControl1.Location = new System.Drawing.Point(0, 81);
            this.chartControl1.Name = "chartControl1";
            series1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Numerical;
            pointSeriesLabel1.LineVisible = true;
            series1.Label = pointSeriesLabel1;
            series1.Name = "Series 1";
            series1.View = scatterLineSeriesView1;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            pointSeriesLabel2.LineVisible = true;
            this.chartControl1.SeriesTemplate.Label = pointSeriesLabel2;
            this.chartControl1.SeriesTemplate.View = lineSeriesView1;
            this.chartControl1.Size = new System.Drawing.Size(772, 500);
            this.chartControl1.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.tableLayoutPanel1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(772, 81);
            this.panelControl1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.simpleButton2, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.simpleButton1, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.endPointCountLabel, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.pointCountLabel, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.radius2TextEdit, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.resolutionTextEdit, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.radius1TextEdit, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.positionTextEdit, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(768, 77);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simpleButton2.Location = new System.Drawing.Point(423, 41);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(104, 33);
            this.simpleButton2.TabIndex = 12;
            this.simpleButton2.Text = "Refresh No Parallel";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(41, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Radius 1";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(3, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(37, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Position";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(213, 3);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(41, 13);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Radius 2";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(213, 41);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(50, 13);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Resolution";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simpleButton1.Location = new System.Drawing.Point(423, 3);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(104, 32);
            this.simpleButton1.TabIndex = 9;
            this.simpleButton1.Text = "Refresh Parallel For";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // endPointCountLabel
            // 
            this.endPointCountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.endPointCountLabel.Location = new System.Drawing.Point(533, 3);
            this.endPointCountLabel.Name = "endPointCountLabel";
            this.endPointCountLabel.Size = new System.Drawing.Size(78, 13);
            this.endPointCountLabel.TabIndex = 10;
            this.endPointCountLabel.Text = "# of End Points:";
            // 
            // pointCountLabel
            // 
            this.pointCountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pointCountLabel.Location = new System.Drawing.Point(533, 41);
            this.pointCountLabel.Name = "pointCountLabel";
            this.pointCountLabel.Size = new System.Drawing.Size(57, 13);
            this.pointCountLabel.TabIndex = 11;
            this.pointCountLabel.Text = "# of Points:";
            // 
            // radius2TextEdit
            // 
            this.radius2TextEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.radius2TextEdit.Location = new System.Drawing.Point(273, 3);
            this.radius2TextEdit.Name = "radius2TextEdit";
            this.radius2TextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.radius2TextEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.radius2TextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.radius2TextEdit.Size = new System.Drawing.Size(100, 20);
            this.radius2TextEdit.TabIndex = 7;
            // 
            // resolutionTextEdit
            // 
            this.resolutionTextEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.resolutionTextEdit.Location = new System.Drawing.Point(273, 41);
            this.resolutionTextEdit.Name = "resolutionTextEdit";
            this.resolutionTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.resolutionTextEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.resolutionTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.resolutionTextEdit.Size = new System.Drawing.Size(100, 20);
            this.resolutionTextEdit.TabIndex = 8;
            // 
            // radius1TextEdit
            // 
            this.radius1TextEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.radius1TextEdit.Location = new System.Drawing.Point(63, 3);
            this.radius1TextEdit.Name = "radius1TextEdit";
            this.radius1TextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.radius1TextEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.radius1TextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.radius1TextEdit.Size = new System.Drawing.Size(100, 20);
            this.radius1TextEdit.TabIndex = 5;
            // 
            // positionTextEdit
            // 
            this.positionTextEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.positionTextEdit.Location = new System.Drawing.Point(63, 41);
            this.positionTextEdit.Name = "positionTextEdit";
            this.positionTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.positionTextEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.positionTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.positionTextEdit.Size = new System.Drawing.Size(100, 20);
            this.positionTextEdit.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 581);
            this.Controls.Add(this.chartControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(scatterLineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radius2TextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resolutionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radius1TextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl chartControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl endPointCountLabel;
        private DevExpress.XtraEditors.LabelControl pointCountLabel;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SpinEdit radius2TextEdit;
        private DevExpress.XtraEditors.SpinEdit resolutionTextEdit;
        private DevExpress.XtraEditors.SpinEdit radius1TextEdit;
        private DevExpress.XtraEditors.SpinEdit positionTextEdit;
    }
}

