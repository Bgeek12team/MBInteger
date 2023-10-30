namespace MyBigIntegerForm
{
    partial class mbiForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tNumFirst = new System.Windows.Forms.TextBox();
            this.bDegree = new System.Windows.Forms.Button();
            this.bRemOfDiv = new System.Windows.Forms.Button();
            this.bCompLess = new System.Windows.Forms.Button();
            this.bCompMore = new System.Windows.Forms.Button();
            this.bComptLessOrEq = new System.Windows.Forms.Button();
            this.bComptMoreOrEq = new System.Windows.Forms.Button();
            this.bAdd = new System.Windows.Forms.Button();
            this.bDiff = new System.Windows.Forms.Button();
            this.bDivision = new System.Windows.Forms.Button();
            this.bMult = new System.Windows.Forms.Button();
            this.bEquals = new System.Windows.Forms.Button();
            this.bNotEqual = new System.Windows.Forms.Button();
            this.bGetResult = new System.Windows.Forms.Button();
            this.tNumSecond = new System.Windows.Forms.TextBox();
            this.lOper = new System.Windows.Forms.Label();
            this.gBResult = new System.Windows.Forms.GroupBox();
            this.tResult = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBoxSecNum = new System.Windows.Forms.GroupBox();
            this.lExSpeed = new System.Windows.Forms.Label();
            this.gBInputForm = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.more = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.gBResult.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxSecNum.SuspendLayout();
            this.gBInputForm.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tNumFirst
            // 
            this.tNumFirst.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tNumFirst.Location = new System.Drawing.Point(4, 22);
            this.tNumFirst.Name = "tNumFirst";
            this.tNumFirst.Size = new System.Drawing.Size(202, 35);
            this.tNumFirst.TabIndex = 0;
            // 
            // bDegree
            // 
            this.bDegree.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bDegree.Location = new System.Drawing.Point(242, 179);
            this.bDegree.Name = "bDegree";
            this.bDegree.Size = new System.Drawing.Size(100, 30);
            this.bDegree.TabIndex = 1;
            this.bDegree.Text = "x¹";
            this.bDegree.UseVisualStyleBackColor = true;
            this.bDegree.Click += new System.EventHandler(this.degree_Click);
            // 
            // bRemOfDiv
            // 
            this.bRemOfDiv.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bRemOfDiv.Location = new System.Drawing.Point(348, 179);
            this.bRemOfDiv.Name = "bRemOfDiv";
            this.bRemOfDiv.Size = new System.Drawing.Size(100, 30);
            this.bRemOfDiv.TabIndex = 2;
            this.bRemOfDiv.Text = "mod";
            this.bRemOfDiv.UseVisualStyleBackColor = true;
            this.bRemOfDiv.Click += new System.EventHandler(this.remOfDiv_Click);
            // 
            // bCompLess
            // 
            this.bCompLess.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bCompLess.Location = new System.Drawing.Point(20, 107);
            this.bCompLess.Name = "bCompLess";
            this.bCompLess.Size = new System.Drawing.Size(100, 30);
            this.bCompLess.TabIndex = 3;
            this.bCompLess.Text = "<";
            this.bCompLess.UseVisualStyleBackColor = true;
            this.bCompLess.Click += new System.EventHandler(this.compLess_Click);
            // 
            // bCompMore
            // 
            this.bCompMore.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bCompMore.Location = new System.Drawing.Point(126, 107);
            this.bCompMore.Name = "bCompMore";
            this.bCompMore.Size = new System.Drawing.Size(100, 30);
            this.bCompMore.TabIndex = 5;
            this.bCompMore.Text = ">";
            this.bCompMore.UseVisualStyleBackColor = true;
            this.bCompMore.Click += new System.EventHandler(this.compMore_Click);
            // 
            // bComptLessOrEq
            // 
            this.bComptLessOrEq.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bComptLessOrEq.Location = new System.Drawing.Point(242, 107);
            this.bComptLessOrEq.Name = "bComptLessOrEq";
            this.bComptLessOrEq.Size = new System.Drawing.Size(100, 30);
            this.bComptLessOrEq.TabIndex = 6;
            this.bComptLessOrEq.Text = "≤";
            this.bComptLessOrEq.UseVisualStyleBackColor = true;
            this.bComptLessOrEq.Click += new System.EventHandler(this.comptLessOrEq_Click);
            // 
            // bComptMoreOrEq
            // 
            this.bComptMoreOrEq.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bComptMoreOrEq.Location = new System.Drawing.Point(348, 107);
            this.bComptMoreOrEq.Name = "bComptMoreOrEq";
            this.bComptMoreOrEq.Size = new System.Drawing.Size(100, 30);
            this.bComptMoreOrEq.TabIndex = 7;
            this.bComptMoreOrEq.Text = "≥";
            this.bComptMoreOrEq.UseVisualStyleBackColor = true;
            this.bComptMoreOrEq.Click += new System.EventHandler(this.comptMoreOrEq_Click);
            // 
            // bAdd
            // 
            this.bAdd.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bAdd.Location = new System.Drawing.Point(20, 143);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(100, 30);
            this.bAdd.TabIndex = 10;
            this.bAdd.Text = "+";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.add_Click);
            // 
            // bDiff
            // 
            this.bDiff.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bDiff.Location = new System.Drawing.Point(126, 143);
            this.bDiff.Name = "bDiff";
            this.bDiff.Size = new System.Drawing.Size(100, 30);
            this.bDiff.TabIndex = 11;
            this.bDiff.Text = "-";
            this.bDiff.UseVisualStyleBackColor = true;
            this.bDiff.Click += new System.EventHandler(this.diff_Click);
            // 
            // bDivision
            // 
            this.bDivision.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bDivision.Location = new System.Drawing.Point(242, 143);
            this.bDivision.Name = "bDivision";
            this.bDivision.Size = new System.Drawing.Size(100, 30);
            this.bDivision.TabIndex = 12;
            this.bDivision.Text = "/";
            this.bDivision.UseVisualStyleBackColor = true;
            this.bDivision.Click += new System.EventHandler(this.division_Click);
            // 
            // bMult
            // 
            this.bMult.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bMult.Location = new System.Drawing.Point(348, 143);
            this.bMult.Name = "bMult";
            this.bMult.Size = new System.Drawing.Size(100, 30);
            this.bMult.TabIndex = 13;
            this.bMult.Text = "*";
            this.bMult.UseVisualStyleBackColor = true;
            this.bMult.Click += new System.EventHandler(this.mult_Click);
            // 
            // bEquals
            // 
            this.bEquals.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bEquals.Location = new System.Drawing.Point(20, 179);
            this.bEquals.Name = "bEquals";
            this.bEquals.Size = new System.Drawing.Size(100, 30);
            this.bEquals.TabIndex = 14;
            this.bEquals.Text = "=";
            this.bEquals.UseVisualStyleBackColor = true;
            this.bEquals.Click += new System.EventHandler(this.equals_Click);
            // 
            // bNotEqual
            // 
            this.bNotEqual.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bNotEqual.Location = new System.Drawing.Point(126, 179);
            this.bNotEqual.Name = "bNotEqual";
            this.bNotEqual.Size = new System.Drawing.Size(100, 30);
            this.bNotEqual.TabIndex = 15;
            this.bNotEqual.Text = "!=";
            this.bNotEqual.UseVisualStyleBackColor = true;
            this.bNotEqual.Click += new System.EventHandler(this.notEqual_Click);
            // 
            // bGetResult
            // 
            this.bGetResult.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bGetResult.Location = new System.Drawing.Point(20, 215);
            this.bGetResult.Name = "bGetResult";
            this.bGetResult.Size = new System.Drawing.Size(428, 30);
            this.bGetResult.TabIndex = 16;
            this.bGetResult.Text = "Результат";
            this.bGetResult.UseVisualStyleBackColor = true;
            this.bGetResult.Click += new System.EventHandler(this.getResult_Click);
            // 
            // tNumSecond
            // 
            this.tNumSecond.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tNumSecond.Location = new System.Drawing.Point(4, 22);
            this.tNumSecond.Name = "tNumSecond";
            this.tNumSecond.Size = new System.Drawing.Size(196, 35);
            this.tNumSecond.TabIndex = 17;
            // 
            // lOper
            // 
            this.lOper.AutoSize = true;
            this.lOper.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lOper.Location = new System.Drawing.Point(232, 56);
            this.lOper.Name = "lOper";
            this.lOper.Size = new System.Drawing.Size(0, 26);
            this.lOper.TabIndex = 18;
            // 
            // gBResult
            // 
            this.gBResult.Controls.Add(this.tResult);
            this.gBResult.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gBResult.Location = new System.Drawing.Point(12, 12);
            this.gBResult.Name = "gBResult";
            this.gBResult.Size = new System.Drawing.Size(835, 70);
            this.gBResult.TabIndex = 19;
            this.gBResult.TabStop = false;
            this.gBResult.Text = "Результат вычисления";
            // 
            // tResult
            // 
            this.tResult.Location = new System.Drawing.Point(6, 29);
            this.tResult.Name = "tResult";
            this.tResult.Size = new System.Drawing.Size(819, 35);
            this.tResult.TabIndex = 24;
            this.tResult.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tNumFirst);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(9, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(217, 67);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Первое число";
            // 
            // groupBoxSecNum
            // 
            this.groupBoxSecNum.Controls.Add(this.tNumSecond);
            this.groupBoxSecNum.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxSecNum.Location = new System.Drawing.Point(255, 26);
            this.groupBoxSecNum.Name = "groupBoxSecNum";
            this.groupBoxSecNum.Size = new System.Drawing.Size(208, 67);
            this.groupBoxSecNum.TabIndex = 21;
            this.groupBoxSecNum.TabStop = false;
            this.groupBoxSecNum.Text = "Второе число";
            // 
            // lExSpeed
            // 
            this.lExSpeed.AutoSize = true;
            this.lExSpeed.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lExSpeed.Location = new System.Drawing.Point(12, 355);
            this.lExSpeed.Name = "lExSpeed";
            this.lExSpeed.Size = new System.Drawing.Size(24, 26);
            this.lExSpeed.TabIndex = 22;
            this.lExSpeed.Text = "1";
            this.lExSpeed.Visible = false;
            // 
            // gBInputForm
            // 
            this.gBInputForm.Controls.Add(this.groupBoxSecNum);
            this.gBInputForm.Controls.Add(this.groupBox2);
            this.gBInputForm.Controls.Add(this.lOper);
            this.gBInputForm.Controls.Add(this.bGetResult);
            this.gBInputForm.Controls.Add(this.bNotEqual);
            this.gBInputForm.Controls.Add(this.bEquals);
            this.gBInputForm.Controls.Add(this.bMult);
            this.gBInputForm.Controls.Add(this.bDivision);
            this.gBInputForm.Controls.Add(this.bDiff);
            this.gBInputForm.Controls.Add(this.bAdd);
            this.gBInputForm.Controls.Add(this.bComptMoreOrEq);
            this.gBInputForm.Controls.Add(this.bComptLessOrEq);
            this.gBInputForm.Controls.Add(this.bCompMore);
            this.gBInputForm.Controls.Add(this.bCompLess);
            this.gBInputForm.Controls.Add(this.bRemOfDiv);
            this.gBInputForm.Controls.Add(this.bDegree);
            this.gBInputForm.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gBInputForm.Location = new System.Drawing.Point(12, 88);
            this.gBInputForm.Name = "gBInputForm";
            this.gBInputForm.Size = new System.Drawing.Size(477, 264);
            this.gBInputForm.TabIndex = 23;
            this.gBInputForm.TabStop = false;
            this.gBInputForm.Text = "Панель взаимодействия";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button11);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(494, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 264);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Дополнительное";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(20, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(317, 66);
            this.button1.TabIndex = 21;
            this.button1.Text = "Извлечь квадратный корень";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.more);
            this.groupBox4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox4.Location = new System.Drawing.Point(20, 26);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(322, 67);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Число";
            // 
            // more
            // 
            this.more.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.more.Location = new System.Drawing.Point(4, 22);
            this.more.Name = "more";
            this.more.Size = new System.Drawing.Size(313, 35);
            this.more.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(242, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 26);
            this.label1.TabIndex = 18;
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button11.Location = new System.Drawing.Point(20, 215);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(322, 30);
            this.button11.TabIndex = 3;
            this.button11.Text = "Факторизация";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // mbiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 402);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gBInputForm);
            this.Controls.Add(this.lExSpeed);
            this.Controls.Add(this.gBResult);
            this.Name = "mbiForm";
            this.Text = "MyBigInteger";
            this.gBResult.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxSecNum.ResumeLayout(false);
            this.groupBoxSecNum.PerformLayout();
            this.gBInputForm.ResumeLayout(false);
            this.gBInputForm.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tNumFirst;
        private Button bDegree;
        private Button bRemOfDiv;
        private Button bCompLess;
        private Button bCompMore;
        private Button bComptLessOrEq;
        private Button bComptMoreOrEq;
        private Button bAdd;
        private Button bDiff;
        private Button bDivision;
        private Button bMult;
        private Button bEquals;
        private Button bNotEqual;
        private Button bGetResult;
        private TextBox tNumSecond;
        private Label lOper;
        private GroupBox gBResult;
        private GroupBox groupBox2;
        private GroupBox groupBoxSecNum;
        private Label lExSpeed;
        private GroupBox gBInputForm;
        private RichTextBox tResult;
        private GroupBox groupBox1;
        private GroupBox groupBox4;
        private TextBox more;
        private Label label1;
        private Button button11;
        private Button button1;
    }
}