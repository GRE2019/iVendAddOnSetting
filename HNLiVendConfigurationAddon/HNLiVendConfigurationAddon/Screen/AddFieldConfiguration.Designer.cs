namespace HNLiVendConfigurationAddon.Screen
{
    partial class AddFieldConfiguration
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_tableName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_fieldName = new System.Windows.Forms.TextBox();
            this.txt_Description = new System.Windows.Forms.TextBox();
            this.txt_dataLength = new System.Windows.Forms.TextBox();
            this.cm_dataType = new System.Windows.Forms.ComboBox();
            this.dtg_validValues = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_validValues)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.81818F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.18182F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_tableName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txt_fieldName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txt_Description, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txt_dataLength, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.cm_dataType, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.dtg_validValues, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.button1, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.button2, 3, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(808, 792);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lbl_tableName
            // 
            this.lbl_tableName.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lbl_tableName, 4);
            this.lbl_tableName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_tableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tableName.Location = new System.Drawing.Point(0, 0);
            this.lbl_tableName.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_tableName.Name = "lbl_tableName";
            this.lbl_tableName.Size = new System.Drawing.Size(808, 50);
            this.lbl_tableName.TabIndex = 0;
            this.lbl_tableName.Text = "U_ConfigurationAddon";
            this.lbl_tableName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(10, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 50);
            this.label1.TabIndex = 1;
            this.label1.Text = "FieldName";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(10, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 50);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(10, 150);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 50);
            this.label3.TabIndex = 3;
            this.label3.Text = "DataType";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(10, 200);
            this.label4.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 50);
            this.label4.TabIndex = 4;
            this.label4.Text = "DataLength";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_fieldName
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txt_fieldName, 3);
            this.txt_fieldName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_fieldName.Location = new System.Drawing.Point(163, 60);
            this.txt_fieldName.Margin = new System.Windows.Forms.Padding(3, 10, 20, 0);
            this.txt_fieldName.Name = "txt_fieldName";
            this.txt_fieldName.Size = new System.Drawing.Size(625, 31);
            this.txt_fieldName.TabIndex = 5;
            this.txt_fieldName.Text = "U_";
            // 
            // txt_Description
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txt_Description, 3);
            this.txt_Description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Description.Location = new System.Drawing.Point(163, 110);
            this.txt_Description.Margin = new System.Windows.Forms.Padding(3, 10, 20, 0);
            this.txt_Description.Name = "txt_Description";
            this.txt_Description.Size = new System.Drawing.Size(625, 31);
            this.txt_Description.TabIndex = 6;
            // 
            // txt_dataLength
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txt_dataLength, 3);
            this.txt_dataLength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_dataLength.Location = new System.Drawing.Point(163, 210);
            this.txt_dataLength.Margin = new System.Windows.Forms.Padding(3, 10, 20, 0);
            this.txt_dataLength.Name = "txt_dataLength";
            this.txt_dataLength.Size = new System.Drawing.Size(625, 31);
            this.txt_dataLength.TabIndex = 8;
            this.txt_dataLength.Text = "50";
            // 
            // cm_dataType
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cm_dataType, 3);
            this.cm_dataType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cm_dataType.FormattingEnabled = true;
            this.cm_dataType.Items.AddRange(new object[] {
            "string",
            "int",
            "decimal",
            "bool",
            "validvalues",
            "long"});
            this.cm_dataType.Location = new System.Drawing.Point(163, 160);
            this.cm_dataType.Margin = new System.Windows.Forms.Padding(3, 10, 20, 0);
            this.cm_dataType.Name = "cm_dataType";
            this.cm_dataType.Size = new System.Drawing.Size(625, 33);
            this.cm_dataType.TabIndex = 9;
            this.cm_dataType.SelectedIndexChanged += new System.EventHandler(this.cm_dataType_SelectedIndexChanged);
            this.cm_dataType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cm_dataType_KeyPress);
            // 
            // dtg_validValues
            // 
            this.dtg_validValues.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtg_validValues.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtg_validValues.BackgroundColor = System.Drawing.Color.White;
            this.dtg_validValues.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtg_validValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_validValues.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.description});
            this.tableLayoutPanel1.SetColumnSpan(this.dtg_validValues, 4);
            this.dtg_validValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtg_validValues.Location = new System.Drawing.Point(20, 270);
            this.dtg_validValues.Margin = new System.Windows.Forms.Padding(20);
            this.dtg_validValues.Name = "dtg_validValues";
            this.dtg_validValues.RowTemplate.Height = 33;
            this.dtg_validValues.Size = new System.Drawing.Size(768, 432);
            this.dtg_validValues.TabIndex = 10;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            // 
            // description
            // 
            this.description.HeaderText = "Description";
            this.description.Name = "description";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(505, 722);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 70);
            this.button1.TabIndex = 11;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(655, 722);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(153, 70);
            this.button2.TabIndex = 12;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AddFieldConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 792);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddFieldConfiguration";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_validValues)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl_tableName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_fieldName;
        private System.Windows.Forms.TextBox txt_Description;
        private System.Windows.Forms.TextBox txt_dataLength;
        private System.Windows.Forms.ComboBox cm_dataType;
        private System.Windows.Forms.DataGridView dtg_validValues;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}