using MBIClassLib;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace MyBigIntegerForm
{
    public partial class mbiForm : Form
    {
        private Stopwatch sWatch = new Stopwatch();
        private const int standartSizeOfForm = 450;
        private (int, int) sizeForm;
        private (int, int) sizeTResult;
        private (int, int) sizeGbResult;
        private (int, int) sizeGbInputForm;
        private (int, int) sizeLExSpeed;
        public mbiForm()
        {
            InitializeComponent();
            Size = new Size(Size.Width, standartSizeOfForm);
            sizeForm = new(Size.Width, Size.Height);
            sizeTResult = new(tResult.Width, tResult.Height);
            sizeGbResult = new(gBResult.Width, gBResult.Height);
            sizeGbInputForm = new(gBInputForm.Location.X, gBInputForm.Location.Y);
            sizeLExSpeed = new(lExSpeed.Location.X, lExSpeed.Location.Y);
        }

        private void compLess_Click(object sender, EventArgs e)
        {
            lOper.Text = "<";
            groupBoxSecNum.Text = "Второе число";
        }

        private void compMore_Click(object sender, EventArgs e)
        {
            lOper.Text = ">";
            groupBoxSecNum.Text = "Второе число";
        }

        private void comptLessOrEq_Click(object sender, EventArgs e)
        {
            lOper.Text = "≤";
            groupBoxSecNum.Text = "Второе число";
        }

        private void comptMoreOrEq_Click(object sender, EventArgs e)
        {
            lOper.Text = "≥";
            groupBoxSecNum.Text = "Второе число";
        }

        private void add_Click(object sender, EventArgs e)
        {
            lOper.Text = "+";
            groupBoxSecNum.Text = "Второе число";
        }

        private void diff_Click(object sender, EventArgs e)
        {
            lOper.Text = "-";
            groupBoxSecNum.Text = "Второе число";
        }

        private void division_Click(object sender, EventArgs e)
        {
            lOper.Text = "/";
            groupBoxSecNum.Text = "Второе число";
        }

        private void mult_Click(object sender, EventArgs e)
        {
            lOper.Text = "*";
            groupBoxSecNum.Text = "Второе число";
        }

        private void equals_Click(object sender, EventArgs e)
        {
            lOper.Text = "=";
            groupBoxSecNum.Text = "Второе число";
        }

        private void notEqual_Click(object sender, EventArgs e)
        {
            lOper.Text = "≠";
            groupBoxSecNum.Text = "Второе число";
        }

        private void degree_Click(object sender, EventArgs e)
        {
            lOper.Text = "^";
            groupBoxSecNum.Text = "Показатель степени";
        }

        private void remOfDiv_Click(object sender, EventArgs e)
        {
            lOper.Text = "%";
            groupBoxSecNum.Text = "Второе число";
        }

        private void getResult_Click(object sender, EventArgs e)
        {
            if (tNumFirst.Text != string.Empty && tNumSecond.Text != string.Empty)
            {
                if (lOper.Text != string.Empty)
                {
                    returnNormalSizeForm();
                    lExSpeed.Text = "Время выполнения операции:";
                    var n1 = new MyBigInteger(tNumFirst.Text);
                    var n2 = new MyBigInteger(tNumSecond.Text);
                    string result = "0";
                    switch (lOper.Text)
                    {
                        case "+":
                            getExcutionTime(() => {
                                result = (n1 + n2).ToString();
                            });
                            break;
                        case "-":
                            getExcutionTime(() => {
                                result = (n1 - n2).ToString();
                            });
                            break;
                        case "<":
                            getExcutionTime(() => {
                                result = (n1 < n2).ToString();
                            });
                            break;
                        case ">":
                            getExcutionTime(() => {
                                result = (n1 > n2).ToString();
                            });
                            break;
                        case "≥":
                            getExcutionTime(() => {
                                result = (n1 >= n2).ToString();
                            });
                            break;
                        case "≤":
                            getExcutionTime(() => {
                                result = (n1 <= n2).ToString();
                            });
                            break;
                        case "^":
                            getExcutionTime(() => {
                                result = (n1 ^ n2).ToString();
                            });
                            break;
                        case "*":
                            getExcutionTime(() => {
                                result = (n1 * n2).ToString();
                            });
                            break;
                        case "/":
                            getExcutionTime(() => {
                                result = (n1 / n2).ToString();
                            });
                            break;
                        case "%":
                            getExcutionTime(() => {
                                result = (n1 % n2).ToString();
                            });
                            break;
                        case "=":
                            getExcutionTime(() => {
                                result = (n1 == n2).ToString();
                            });
                            break;
                        case "≠":
                            getExcutionTime(() => {
                                result = (n1 != n2).ToString();
                            });
                            break;
                        default:
                            break;
                    }
                    writeResult(result);
                    lExSpeed.Visible = true;
                } else { MessageBox.Show("Выберите оперцию!"); }
            } else { MessageBox.Show("Заполните все поля!"); }
        }
        
        private void getExcutionTime(Action act)
        {
            sWatch.Start();
            act();
            sWatch.Stop();
            lExSpeed.Text += $" {sWatch.Elapsed}";
            sWatch.Reset();
        }
        private void writeResult(string result)
        {
            if (result.Length > 59)
            {
                int scaleLevel = result.Length / 59;
                if (scaleLevel > 4)
                    scaleLevel = 4;
                autoScale(scaleLevel);
                tResult.Text = result;
            }
            else { tResult.Text = result; }
        }
        private void autoScale(int scaleLevel)
        {
           Size = new Size(Size.Width, Size.Height + 35 * scaleLevel);
           tResult.Size = new Size(tResult.Width, tResult.Height + 35 * scaleLevel);
           gBResult.Size = new Size(gBResult.Width, gBResult.Height + 35 * scaleLevel);
           gBInputForm.Location = new Point(gBInputForm.Location.X, gBInputForm.Location.Y + 35 * scaleLevel);
           lExSpeed.Location = new Point(lExSpeed.Location.X, lExSpeed.Location.Y + 35 * scaleLevel);
        }
        private void returnNormalSizeForm()
        {
            Size = new Size(sizeForm.Item1, sizeForm.Item2);
            tResult.Size = new Size(sizeTResult.Item1, sizeTResult.Item2);
            gBResult.Size = new Size(sizeGbResult.Item1, sizeGbResult.Item2);
            gBInputForm.Location = new Point(sizeGbInputForm.Item1, sizeGbInputForm.Item2);
            lExSpeed.Location = new Point(sizeLExSpeed.Item1, sizeLExSpeed.Item2);
        }
        
    }
}