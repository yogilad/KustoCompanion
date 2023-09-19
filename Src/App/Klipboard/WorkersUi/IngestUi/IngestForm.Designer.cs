﻿namespace Klipboard.WorkersUi.IngestUi
{
    partial class IngestForm
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
            ClusterComboBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            DatabaseComboBox = new ComboBox();
            ExitingTableRadio = new RadioButton();
            TableComboBox = new ComboBox();
            NewTableRadio = new RadioButton();
            label4 = new Label();
            label5 = new Label();
            TableTextBox = new TextBox();
            TableSchemaTextBox = new TextBox();
            MappingTextBox = new TextBox();
            NoMappingRadio = new RadioButton();
            InlineMappingRadio = new RadioButton();
            ReferenceMappingRadio = new RadioButton();
            panel1 = new Panel();
            panel2 = new Panel();
            label3 = new Label();
            CancelButton = new Button();
            IngestButton = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // ClusterComboBox
            // 
            ClusterComboBox.FormattingEnabled = true;
            ClusterComboBox.Location = new Point(98, 20);
            ClusterComboBox.Name = "ClusterComboBox";
            ClusterComboBox.Size = new Size(121, 23);
            ClusterComboBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 23);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 1;
            label1.Text = "Cluster";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 52);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 2;
            label2.Text = "Database";
            // 
            // DatabaseComboBox
            // 
            DatabaseComboBox.FormattingEnabled = true;
            DatabaseComboBox.Location = new Point(98, 49);
            DatabaseComboBox.Name = "DatabaseComboBox";
            DatabaseComboBox.Size = new Size(121, 23);
            DatabaseComboBox.TabIndex = 3;
            // 
            // ExitingTableRadio
            // 
            ExitingTableRadio.AutoSize = true;
            ExitingTableRadio.Location = new Point(3, 3);
            ExitingTableRadio.Name = "ExitingTableRadio";
            ExitingTableRadio.Size = new Size(91, 19);
            ExitingTableRadio.TabIndex = 4;
            ExitingTableRadio.TabStop = true;
            ExitingTableRadio.Text = "Exiting Table";
            ExitingTableRadio.UseVisualStyleBackColor = true;
            // 
            // TableComboBox
            // 
            TableComboBox.FormattingEnabled = true;
            TableComboBox.Location = new Point(98, 106);
            TableComboBox.Name = "TableComboBox";
            TableComboBox.Size = new Size(121, 23);
            TableComboBox.TabIndex = 5;
            // 
            // NewTableRadio
            // 
            NewTableRadio.AutoSize = true;
            NewTableRadio.Location = new Point(100, 3);
            NewTableRadio.Name = "NewTableRadio";
            NewTableRadio.Size = new Size(79, 19);
            NewTableRadio.TabIndex = 7;
            NewTableRadio.TabStop = true;
            NewTableRadio.Text = "New Table";
            NewTableRadio.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 171);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 8;
            label4.Text = "Mapping";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 141);
            label5.Name = "label5";
            label5.Size = new Size(79, 15);
            label5.TabIndex = 9;
            label5.Text = "Table Schema";
            // 
            // TableTextBox
            // 
            TableTextBox.Location = new Point(225, 106);
            TableTextBox.Name = "TableTextBox";
            TableTextBox.Size = new Size(123, 23);
            TableTextBox.TabIndex = 10;
            // 
            // TableSchemaTextBox
            // 
            TableSchemaTextBox.Location = new Point(98, 135);
            TableSchemaTextBox.Name = "TableSchemaTextBox";
            TableSchemaTextBox.Size = new Size(609, 23);
            TableSchemaTextBox.TabIndex = 11;
            // 
            // MappingTextBox
            // 
            MappingTextBox.Location = new Point(98, 245);
            MappingTextBox.Name = "MappingTextBox";
            MappingTextBox.Size = new Size(609, 23);
            MappingTextBox.TabIndex = 12;
            // 
            // NoMappingRadio
            // 
            NoMappingRadio.AutoSize = true;
            NoMappingRadio.Location = new Point(3, 3);
            NoMappingRadio.Name = "NoMappingRadio";
            NoMappingRadio.Size = new Size(92, 19);
            NoMappingRadio.TabIndex = 13;
            NoMappingRadio.TabStop = true;
            NoMappingRadio.Text = "No Mapping";
            NoMappingRadio.UseVisualStyleBackColor = true;
            // 
            // InlineMappingRadio
            // 
            InlineMappingRadio.AutoSize = true;
            InlineMappingRadio.Location = new Point(3, 28);
            InlineMappingRadio.Name = "InlineMappingRadio";
            InlineMappingRadio.Size = new Size(105, 19);
            InlineMappingRadio.TabIndex = 14;
            InlineMappingRadio.TabStop = true;
            InlineMappingRadio.Text = "Inline Mapping";
            InlineMappingRadio.UseVisualStyleBackColor = true;
            // 
            // ReferenceMappingRadio
            // 
            ReferenceMappingRadio.AutoSize = true;
            ReferenceMappingRadio.Location = new Point(3, 53);
            ReferenceMappingRadio.Name = "ReferenceMappingRadio";
            ReferenceMappingRadio.Size = new Size(128, 19);
            ReferenceMappingRadio.TabIndex = 15;
            ReferenceMappingRadio.TabStop = true;
            ReferenceMappingRadio.Text = "Reference Mapping";
            ReferenceMappingRadio.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(ExitingTableRadio);
            panel1.Controls.Add(NewTableRadio);
            panel1.Location = new Point(98, 78);
            panel1.Name = "panel1";
            panel1.Size = new Size(189, 20);
            panel1.TabIndex = 16;
            // 
            // panel2
            // 
            panel2.Controls.Add(NoMappingRadio);
            panel2.Controls.Add(InlineMappingRadio);
            panel2.Controls.Add(ReferenceMappingRadio);
            panel2.Location = new Point(98, 164);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 75);
            panel2.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(54, 83);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 18;
            label3.Text = "Table";
            // 
            // CancelButton
            // 
            CancelButton.DialogResult = DialogResult.Cancel;
            CancelButton.Location = new Point(642, 286);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 19;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            // 
            // IngestButton
            // 
            IngestButton.DialogResult = DialogResult.OK;
            IngestButton.Location = new Point(556, 286);
            IngestButton.Name = "IngestButton";
            IngestButton.Size = new Size(75, 23);
            IngestButton.TabIndex = 20;
            IngestButton.Text = "Ingest";
            IngestButton.UseVisualStyleBackColor = true;
            // 
            // IngestForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(729, 321);
            Controls.Add(IngestButton);
            Controls.Add(CancelButton);
            Controls.Add(label3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(MappingTextBox);
            Controls.Add(TableSchemaTextBox);
            Controls.Add(TableTextBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(TableComboBox);
            Controls.Add(DatabaseComboBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ClusterComboBox);
            Name = "IngestForm";
            Text = "IngestForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox ClusterComboBox;
        private Label label1;
        private Label label2;
        private ComboBox DatabaseComboBox;
        private RadioButton ExitingTableRadio;
        private ComboBox TableComboBox;
        private RadioButton NewTableRadio;
        private Label label4;
        private Label label5;
        private TextBox TableTextBox;
        private TextBox TableSchemaTextBox;
        private TextBox MappingTextBox;
        private RadioButton NoMappingRadio;
        private RadioButton InlineMappingRadio;
        private RadioButton ReferenceMappingRadio;
        private Panel panel1;
        private Panel panel2;
        private Label label3;
        private Button CancelButton;
        private Button IngestButton;
    }
}