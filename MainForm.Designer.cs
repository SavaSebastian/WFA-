
namespace TNSA_Test
{
    partial class MainForm
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
            this.addButton = new System.Windows.Forms.Button();
            this.cantaririDataGrid = new System.Windows.Forms.DataGridView();
            this.TichetId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeClientDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeFurnizorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vehiculDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeProdusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeSoferDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeOperatorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.netDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCantaririBinding = new System.Windows.Forms.BindingSource(this.components);
            this.refreshButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPortStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cantaririDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateCantaririBinding)).BeginInit();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(12, 12);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Adauga";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // cantaririDataGrid
            // 
            this.cantaririDataGrid.AllowUserToAddRows = false;
            this.cantaririDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cantaririDataGrid.AutoGenerateColumns = false;
            this.cantaririDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cantaririDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TichetId,
            this.numeClientDataGridViewTextBoxColumn,
            this.numeFurnizorDataGridViewTextBoxColumn,
            this.vehiculDataGridViewTextBoxColumn,
            this.numeProdusDataGridViewTextBoxColumn,
            this.numeSoferDataGridViewTextBoxColumn,
            this.numeOperatorDataGridViewTextBoxColumn,
            this.taraDataGridViewTextBoxColumn,
            this.brutDataGridViewTextBoxColumn,
            this.netDataGridViewTextBoxColumn,
            this.tipDataGridViewTextBoxColumn,
            this.dataDataGridViewTextBoxColumn});
            this.cantaririDataGrid.DataSource = this.dateCantaririBinding;
            this.cantaririDataGrid.Location = new System.Drawing.Point(12, 41);
            this.cantaririDataGrid.Name = "cantaririDataGrid";
            this.cantaririDataGrid.ReadOnly = true;
            this.cantaririDataGrid.Size = new System.Drawing.Size(937, 368);
            this.cantaririDataGrid.TabIndex = 1;
            this.cantaririDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CantaririDataGrid_CellContentClick);
            // 
            // TichetId
            // 
            this.TichetId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TichetId.DataPropertyName = "TichetId";
            this.TichetId.HeaderText = "IDTichet";
            this.TichetId.Name = "TichetId";
            this.TichetId.ReadOnly = true;
            // 
            // numeClientDataGridViewTextBoxColumn
            // 
            this.numeClientDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.numeClientDataGridViewTextBoxColumn.DataPropertyName = "NumeClient";
            this.numeClientDataGridViewTextBoxColumn.HeaderText = "NumeClient";
            this.numeClientDataGridViewTextBoxColumn.Name = "numeClientDataGridViewTextBoxColumn";
            this.numeClientDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numeFurnizorDataGridViewTextBoxColumn
            // 
            this.numeFurnizorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.numeFurnizorDataGridViewTextBoxColumn.DataPropertyName = "NumeFurnizor";
            this.numeFurnizorDataGridViewTextBoxColumn.HeaderText = "NumeFurnizor";
            this.numeFurnizorDataGridViewTextBoxColumn.Name = "numeFurnizorDataGridViewTextBoxColumn";
            this.numeFurnizorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vehiculDataGridViewTextBoxColumn
            // 
            this.vehiculDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.vehiculDataGridViewTextBoxColumn.DataPropertyName = "Vehicul";
            this.vehiculDataGridViewTextBoxColumn.HeaderText = "Vehicul";
            this.vehiculDataGridViewTextBoxColumn.Name = "vehiculDataGridViewTextBoxColumn";
            this.vehiculDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numeProdusDataGridViewTextBoxColumn
            // 
            this.numeProdusDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.numeProdusDataGridViewTextBoxColumn.DataPropertyName = "NumeProdus";
            this.numeProdusDataGridViewTextBoxColumn.HeaderText = "NumeProdus";
            this.numeProdusDataGridViewTextBoxColumn.Name = "numeProdusDataGridViewTextBoxColumn";
            this.numeProdusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numeSoferDataGridViewTextBoxColumn
            // 
            this.numeSoferDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.numeSoferDataGridViewTextBoxColumn.DataPropertyName = "NumeSofer";
            this.numeSoferDataGridViewTextBoxColumn.HeaderText = "NumeSofer";
            this.numeSoferDataGridViewTextBoxColumn.Name = "numeSoferDataGridViewTextBoxColumn";
            this.numeSoferDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numeOperatorDataGridViewTextBoxColumn
            // 
            this.numeOperatorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.numeOperatorDataGridViewTextBoxColumn.DataPropertyName = "NumeOperator";
            this.numeOperatorDataGridViewTextBoxColumn.HeaderText = "NumeOperator";
            this.numeOperatorDataGridViewTextBoxColumn.Name = "numeOperatorDataGridViewTextBoxColumn";
            this.numeOperatorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // taraDataGridViewTextBoxColumn
            // 
            this.taraDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.taraDataGridViewTextBoxColumn.DataPropertyName = "Tara";
            this.taraDataGridViewTextBoxColumn.HeaderText = "Tara";
            this.taraDataGridViewTextBoxColumn.Name = "taraDataGridViewTextBoxColumn";
            this.taraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // brutDataGridViewTextBoxColumn
            // 
            this.brutDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.brutDataGridViewTextBoxColumn.DataPropertyName = "Brut";
            this.brutDataGridViewTextBoxColumn.HeaderText = "Brut";
            this.brutDataGridViewTextBoxColumn.Name = "brutDataGridViewTextBoxColumn";
            this.brutDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // netDataGridViewTextBoxColumn
            // 
            this.netDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.netDataGridViewTextBoxColumn.DataPropertyName = "Net";
            this.netDataGridViewTextBoxColumn.HeaderText = "Net";
            this.netDataGridViewTextBoxColumn.Name = "netDataGridViewTextBoxColumn";
            this.netDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipDataGridViewTextBoxColumn
            // 
            this.tipDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tipDataGridViewTextBoxColumn.DataPropertyName = "Tip";
            this.tipDataGridViewTextBoxColumn.HeaderText = "Tip";
            this.tipDataGridViewTextBoxColumn.Name = "tipDataGridViewTextBoxColumn";
            this.tipDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataDataGridViewTextBoxColumn
            // 
            this.dataDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataDataGridViewTextBoxColumn.DataPropertyName = "Data";
            this.dataDataGridViewTextBoxColumn.HeaderText = "Data";
            this.dataDataGridViewTextBoxColumn.Name = "dataDataGridViewTextBoxColumn";
            this.dataDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateCantaririBinding
            // 
            this.dateCantaririBinding.DataSource = typeof(TNSA_Test.DetaliiCantarire);
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.refreshButton.Location = new System.Drawing.Point(13, 415);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 2;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(494, 424);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Status port:";
            // 
            // labelPortStatus
            // 
            this.labelPortStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPortStatus.AutoSize = true;
            this.labelPortStatus.Location = new System.Drawing.Point(562, 424);
            this.labelPortStatus.Name = "labelPortStatus";
            this.labelPortStatus.Size = new System.Drawing.Size(0, 13);
            this.labelPortStatus.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 450);
            this.Controls.Add(this.labelPortStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.cantaririDataGrid);
            this.Controls.Add(this.addButton);
            this.Name = "MainForm";
            this.Text = "AplicatieCantarire";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cantaririDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateCantaririBinding)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.DataGridView cantaririDataGrid;
        private System.Windows.Forms.BindingSource dateCantaririBinding;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn TichetId;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeClientDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeFurnizorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vehiculDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeProdusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeSoferDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeOperatorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn brutDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn netDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPortStatus;
    }
}

