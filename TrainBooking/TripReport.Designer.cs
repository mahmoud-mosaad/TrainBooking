namespace TrainBooking
{
    partial class TripReport
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.TripBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TrainBookingDataSet = new TrainBooking.TrainBookingDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.TripTableAdapter = new TrainBooking.TrainBookingDataSetTableAdapters.TripTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TripBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrainBookingDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // TripBindingSource
            // 
            this.TripBindingSource.DataMember = "Trip";
            this.TripBindingSource.DataSource = this.TrainBookingDataSet;
            // 
            // TrainBookingDataSet
            // 
            this.TrainBookingDataSet.DataSetName = "TrainBookingDataSet";
            this.TrainBookingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.TripBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TrainBooking.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 46);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(602, 251);
            this.reportViewer1.TabIndex = 0;
            // 
            // TripTableAdapter
            // 
            this.TripTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "< Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TripReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 309);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "TripReport";
            this.Text = "TripReport";
            this.Load += new System.EventHandler(this.TripReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TripBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrainBookingDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource TripBindingSource;
        private TrainBookingDataSet TrainBookingDataSet;
        private TrainBookingDataSetTableAdapters.TripTableAdapter TripTableAdapter;
        private System.Windows.Forms.Button button1;
    }
}