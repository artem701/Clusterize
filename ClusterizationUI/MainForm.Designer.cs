namespace ClusterizationUI
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
            this.clustNumDec = new System.Windows.Forms.Button();
            this.clustNumInc = new System.Windows.Forms.Button();
            this.clustersNumBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.resetScaleButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.yAxisBox = new System.Windows.Forms.ComboBox();
            this.xAxisBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mapBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.mapBox)).BeginInit();
            this.SuspendLayout();
            // 
            // clustNumDec
            // 
            this.clustNumDec.Enabled = false;
            this.clustNumDec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clustNumDec.Location = new System.Drawing.Point(51, 142);
            this.clustNumDec.Name = "clustNumDec";
            this.clustNumDec.Size = new System.Drawing.Size(46, 24);
            this.clustNumDec.TabIndex = 23;
            this.clustNumDec.Text = "<";
            this.clustNumDec.UseVisualStyleBackColor = true;
            this.clustNumDec.Click += new System.EventHandler(this.clustNumDec_Click);
            // 
            // clustNumInc
            // 
            this.clustNumInc.Enabled = false;
            this.clustNumInc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clustNumInc.Location = new System.Drawing.Point(155, 142);
            this.clustNumInc.Name = "clustNumInc";
            this.clustNumInc.Size = new System.Drawing.Size(46, 24);
            this.clustNumInc.TabIndex = 22;
            this.clustNumInc.Text = ">";
            this.clustNumInc.UseVisualStyleBackColor = true;
            this.clustNumInc.Click += new System.EventHandler(this.clustNumInc_Click);
            // 
            // clustersNumBox
            // 
            this.clustersNumBox.Enabled = false;
            this.clustersNumBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clustersNumBox.Location = new System.Drawing.Point(103, 142);
            this.clustersNumBox.Name = "clustersNumBox";
            this.clustersNumBox.Size = new System.Drawing.Size(46, 22);
            this.clustersNumBox.TabIndex = 21;
            this.clustersNumBox.TextChanged += new System.EventHandler(this.clustersNumBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 498);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 20;
            // 
            // resetScaleButton
            // 
            this.resetScaleButton.Enabled = false;
            this.resetScaleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resetScaleButton.Location = new System.Drawing.Point(12, 201);
            this.resetScaleButton.Name = "resetScaleButton";
            this.resetScaleButton.Size = new System.Drawing.Size(186, 31);
            this.resetScaleButton.TabIndex = 19;
            this.resetScaleButton.Text = "Сбросить масштаб";
            this.resetScaleButton.UseVisualStyleBackColor = true;
            this.resetScaleButton.Click += new System.EventHandler(this.resetScaleButton_Click);
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startButton.Location = new System.Drawing.Point(12, 543);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(189, 28);
            this.startButton.TabIndex = 18;
            this.startButton.Text = "Открыть...";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // yAxisBox
            // 
            this.yAxisBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yAxisBox.Enabled = false;
            this.yAxisBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.yAxisBox.FormattingEnabled = true;
            this.yAxisBox.Location = new System.Drawing.Point(155, 75);
            this.yAxisBox.Name = "yAxisBox";
            this.yAxisBox.Size = new System.Drawing.Size(46, 24);
            this.yAxisBox.TabIndex = 17;
            this.yAxisBox.SelectedIndexChanged += new System.EventHandler(this.yAxisBox_SelectedIndexChanged);
            // 
            // xAxisBox
            // 
            this.xAxisBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.xAxisBox.Enabled = false;
            this.xAxisBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.xAxisBox.FormattingEnabled = true;
            this.xAxisBox.Location = new System.Drawing.Point(155, 21);
            this.xAxisBox.Name = "xAxisBox";
            this.xAxisBox.Size = new System.Drawing.Size(46, 24);
            this.xAxisBox.TabIndex = 16;
            this.xAxisBox.SelectedIndexChanged += new System.EventHandler(this.xAxisBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(9, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Отображаемые кластеры:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(9, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Проецировать на Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Проецировать на Х:";
            // 
            // mapBox
            // 
            this.mapBox.BackColor = System.Drawing.Color.Black;
            this.mapBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mapBox.Location = new System.Drawing.Point(207, 21);
            this.mapBox.Name = "mapBox";
            this.mapBox.Size = new System.Drawing.Size(550, 550);
            this.mapBox.TabIndex = 12;
            this.mapBox.TabStop = false;
            this.mapBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mapBox_MouseClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 585);
            this.Controls.Add(this.clustNumDec);
            this.Controls.Add(this.clustNumInc);
            this.Controls.Add(this.clustersNumBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.resetScaleButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.yAxisBox);
            this.Controls.Add(this.xAxisBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mapBox);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Кластеризация точек в n-мерном Евклидовом пространстве";
            ((System.ComponentModel.ISupportInitialize)(this.mapBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button clustNumDec;
        private System.Windows.Forms.Button clustNumInc;
        private System.Windows.Forms.TextBox clustersNumBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button resetScaleButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.ComboBox yAxisBox;
        private System.Windows.Forms.ComboBox xAxisBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox mapBox;
    }
}