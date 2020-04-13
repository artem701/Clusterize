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
            this.tabController = new System.Windows.Forms.TabControl();
            this.generatorPage = new System.Windows.Forms.TabPage();
            this.vizualizerPage = new System.Windows.Forms.TabPage();
            this.mapBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.xAxisBox = new System.Windows.Forms.ComboBox();
            this.yAxisBox = new System.Windows.Forms.ComboBox();
            this.startButton = new System.Windows.Forms.Button();
            this.resetScaleButton = new System.Windows.Forms.Button();
            this.pointBox = new System.Windows.Forms.TextBox();
            this.readyPointsBox = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.writeButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tabController.SuspendLayout();
            this.generatorPage.SuspendLayout();
            this.vizualizerPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tabController
            // 
            this.tabController.Controls.Add(this.generatorPage);
            this.tabController.Controls.Add(this.vizualizerPage);
            this.tabController.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabController.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tabController.Location = new System.Drawing.Point(0, 0);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 0;
            this.tabController.Size = new System.Drawing.Size(767, 593);
            this.tabController.TabIndex = 0;
            // 
            // generatorPage
            // 
            this.generatorPage.BackColor = System.Drawing.SystemColors.Control;
            this.generatorPage.Controls.Add(this.writeButton);
            this.generatorPage.Controls.Add(this.removeButton);
            this.generatorPage.Controls.Add(this.addButton);
            this.generatorPage.Controls.Add(this.readyPointsBox);
            this.generatorPage.Controls.Add(this.pointBox);
            this.generatorPage.Location = new System.Drawing.Point(4, 25);
            this.generatorPage.Name = "generatorPage";
            this.generatorPage.Padding = new System.Windows.Forms.Padding(3);
            this.generatorPage.Size = new System.Drawing.Size(759, 564);
            this.generatorPage.TabIndex = 0;
            this.generatorPage.Text = "Заполнить файл точками";
            // 
            // vizualizerPage
            // 
            this.vizualizerPage.BackColor = System.Drawing.SystemColors.Control;
            this.vizualizerPage.Controls.Add(this.label4);
            this.vizualizerPage.Controls.Add(this.resetScaleButton);
            this.vizualizerPage.Controls.Add(this.startButton);
            this.vizualizerPage.Controls.Add(this.yAxisBox);
            this.vizualizerPage.Controls.Add(this.xAxisBox);
            this.vizualizerPage.Controls.Add(this.label2);
            this.vizualizerPage.Controls.Add(this.label1);
            this.vizualizerPage.Controls.Add(this.mapBox);
            this.vizualizerPage.Location = new System.Drawing.Point(4, 25);
            this.vizualizerPage.Name = "vizualizerPage";
            this.vizualizerPage.Padding = new System.Windows.Forms.Padding(3);
            this.vizualizerPage.Size = new System.Drawing.Size(759, 564);
            this.vizualizerPage.TabIndex = 1;
            this.vizualizerPage.Text = "Кластеризовать точки из файла";
            // 
            // mapBox
            // 
            this.mapBox.BackColor = System.Drawing.Color.LightYellow;
            this.mapBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mapBox.Location = new System.Drawing.Point(201, 6);
            this.mapBox.Name = "mapBox";
            this.mapBox.Size = new System.Drawing.Size(550, 550);
            this.mapBox.TabIndex = 1;
            this.mapBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Проецировать на Х:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Проецировать на Y:";
            // 
            // xAxisBox
            // 
            this.xAxisBox.Enabled = false;
            this.xAxisBox.FormattingEnabled = true;
            this.xAxisBox.Location = new System.Drawing.Point(149, 6);
            this.xAxisBox.Name = "xAxisBox";
            this.xAxisBox.Size = new System.Drawing.Size(46, 24);
            this.xAxisBox.TabIndex = 3;
            // 
            // yAxisBox
            // 
            this.yAxisBox.Enabled = false;
            this.yAxisBox.FormattingEnabled = true;
            this.yAxisBox.Location = new System.Drawing.Point(149, 60);
            this.yAxisBox.Name = "yAxisBox";
            this.yAxisBox.Size = new System.Drawing.Size(46, 24);
            this.yAxisBox.TabIndex = 4;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(6, 528);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(189, 28);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "Открыть...";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // resetScaleButton
            // 
            this.resetScaleButton.Enabled = false;
            this.resetScaleButton.Location = new System.Drawing.Point(9, 107);
            this.resetScaleButton.Name = "resetScaleButton";
            this.resetScaleButton.Size = new System.Drawing.Size(186, 31);
            this.resetScaleButton.TabIndex = 7;
            this.resetScaleButton.Text = "Сбросить масштаб";
            this.resetScaleButton.UseVisualStyleBackColor = true;
            // 
            // pointBox
            // 
            this.pointBox.Location = new System.Drawing.Point(3, 6);
            this.pointBox.Multiline = true;
            this.pointBox.Name = "pointBox";
            this.pointBox.Size = new System.Drawing.Size(312, 27);
            this.pointBox.TabIndex = 0;
            // 
            // readyPointsBox
            // 
            this.readyPointsBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.readyPointsBox.Location = new System.Drawing.Point(3, 36);
            this.readyPointsBox.Name = "readyPointsBox";
            this.readyPointsBox.Size = new System.Drawing.Size(312, 519);
            this.readyPointsBox.TabIndex = 1;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(321, 6);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(95, 27);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(422, 7);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(94, 26);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Удалить";
            this.removeButton.UseVisualStyleBackColor = true;
            // 
            // writeButton
            // 
            this.writeButton.Location = new System.Drawing.Point(321, 519);
            this.writeButton.Name = "writeButton";
            this.writeButton.Size = new System.Drawing.Size(195, 36);
            this.writeButton.TabIndex = 4;
            this.writeButton.Text = "Записать в файл...";
            this.writeButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 483);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 17);
            this.label4.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 593);
            this.Controls.Add(this.tabController);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Form2";
            this.tabController.ResumeLayout(false);
            this.generatorPage.ResumeLayout(false);
            this.generatorPage.PerformLayout();
            this.vizualizerPage.ResumeLayout(false);
            this.vizualizerPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabController;
        private System.Windows.Forms.TabPage generatorPage;
        private System.Windows.Forms.TabPage vizualizerPage;
        private System.Windows.Forms.PictureBox mapBox;
        private System.Windows.Forms.ComboBox xAxisBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox yAxisBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button resetScaleButton;
        private System.Windows.Forms.Label readyPointsBox;
        private System.Windows.Forms.TextBox pointBox;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button writeButton;
        private System.Windows.Forms.Label label4;
    }
}