namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.showAllButton = new System.Windows.Forms.Button();
            this.cqList = new System.Windows.Forms.ListView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.allList = new System.Windows.Forms.ListView();
            this.mapPanel = new System.Windows.Forms.Panel();
            this.toolStripStatusLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.detailList = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(670, 557);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "テストテキスト";
            // 
            // showAllButton
            // 
            this.showAllButton.Location = new System.Drawing.Point(3, 271);
            this.showAllButton.Name = "showAllButton";
            this.showAllButton.Size = new System.Drawing.Size(75, 23);
            this.showAllButton.TabIndex = 1;
            this.showAllButton.Text = "show all";
            this.showAllButton.UseVisualStyleBackColor = true;
            this.showAllButton.Click += new System.EventHandler(this.ShowAllButton_Click);
            // 
            // cqList
            // 
            this.cqList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cqList.HideSelection = false;
            this.cqList.Location = new System.Drawing.Point(3, 15);
            this.cqList.Name = "cqList";
            this.cqList.Size = new System.Drawing.Size(322, 244);
            this.cqList.TabIndex = 2;
            this.cqList.UseCompatibleStateImageBehavior = false;
            this.cqList.View = System.Windows.Forms.View.Details;
            this.cqList.Click += new System.EventHandler(this.CqList_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mapPanel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.toolStripStatusLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.showAllButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.46757F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.532423F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1002, 582);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.allList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 262);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "All Communications";
            // 
            // allList
            // 
            this.allList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.allList.HideSelection = false;
            this.allList.Location = new System.Drawing.Point(3, 15);
            this.allList.Name = "allList";
            this.allList.Size = new System.Drawing.Size(321, 244);
            this.allList.TabIndex = 3;
            this.allList.UseCompatibleStateImageBehavior = false;
            this.allList.View = System.Windows.Forms.View.Details;
            this.allList.Click += new System.EventHandler(this.AllList_Click);
            // 
            // mapPanel
            // 
            this.mapPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapPanel.Location = new System.Drawing.Point(336, 271);
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(328, 283);
            this.mapPanel.TabIndex = 8;
            this.mapPanel.SizeChanged += new System.EventHandler(this.mapPanel_SizeChanged);
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.AutoSize = true;
            this.toolStripStatusLabel.Location = new System.Drawing.Point(336, 557);
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(35, 12);
            this.toolStripStatusLabel.TabIndex = 10;
            this.toolStripStatusLabel.Text = "label2";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.detailList);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(670, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(329, 262);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Detail";
            // 
            // detailList
            // 
            this.detailList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailList.HideSelection = false;
            this.detailList.Location = new System.Drawing.Point(3, 15);
            this.detailList.Name = "detailList";
            this.detailList.Size = new System.Drawing.Size(323, 244);
            this.detailList.TabIndex = 4;
            this.detailList.UseCompatibleStateImageBehavior = false;
            this.detailList.Click += new System.EventHandler(this.DetailList_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cqList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(336, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 262);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "QSO Communications";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 560);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 19);
            this.button1.TabIndex = 11;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 582);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button showAllButton;
        private System.Windows.Forms.ListView cqList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView allList;
        private System.Windows.Forms.ListView detailList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel mapPanel;
        private System.Windows.Forms.Label toolStripStatusLabel;
        private System.Windows.Forms.Button button1;
    }
}

