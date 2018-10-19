namespace CapaPresentacion
{
    partial class frmReporteComprobante
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataSet = new CapaPresentacion.DataSet();
            this.Reporte_FacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Reporte_FacturaTableAdapter = new CapaPresentacion.DataSetTableAdapters.Reporte_FacturaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporte_FacturaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Reporte_FacturaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Reportes.ReporteComprobante.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(647, 476);
            this.reportViewer1.TabIndex = 0;
            // 
            // DataSet
            // 
            this.DataSet.DataSetName = "DataSet";
            this.DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Reporte_FacturaBindingSource
            // 
            this.Reporte_FacturaBindingSource.DataMember = "Reporte_Factura";
            this.Reporte_FacturaBindingSource.DataSource = this.DataSet;
            // 
            // Reporte_FacturaTableAdapter
            // 
            this.Reporte_FacturaTableAdapter.ClearBeforeFill = true;
            // 
            // frmReporteComprobante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 476);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReporteComprobante";
            this.Text = "Comprovante de Venta";
            this.Load += new System.EventHandler(this.frmReporteComprobante_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporte_FacturaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Reporte_FacturaBindingSource;
        private DataSet DataSet;
        private DataSetTableAdapters.Reporte_FacturaTableAdapter Reporte_FacturaTableAdapter;
    }
}