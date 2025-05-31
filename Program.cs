using System.Windows.Forms;
using System.Drawing;
using Jace;

namespace CalculatorApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var form = new Form
            {
                Text = "Калькулятор",
                Size = new Size(355, 300),
                FormBorderStyle = FormBorderStyle.FixedSingle,
                MaximizeBox = false
            };

            var textBox = new TextBox
            {
                Location = new Point(10, 10),
                ReadOnly = true,
                Size = new Size(320, 30),
                TextAlign = HorizontalAlignment.Right,
                Font = new Font("Arial", 12)
            };

            var button1 = CreateButton("1", 10, 50);
            var button2 = CreateButton("2", 120, 50);
            var button3 = CreateButton("3", 230, 50);

            var button4 = CreateButton("4", 10, 80);
            var button5 = CreateButton("5", 120, 80);
            var button6 = CreateButton("6", 230, 80);

            var button7 = CreateButton("7", 10, 110);
            var button8 = CreateButton("8", 120, 110);
            var button9 = CreateButton("9", 230, 110);

            var button0 = CreateButton("0", 10, 140);
            var buttonDecimal = CreateButton(",", 120, 140);
            var buttonClear = CreateButton("C", 230, 140);

            var buttonPlus = CreateButton("+", 230, 170);
            var buttonMinus = CreateButton("-", 120, 170);
            var buttonMultiply = CreateButton("*", 10, 170);
            var buttonDivide = CreateButton("/", 10, 200);
            var buttonEquals = CreateButton("=", 120, 200);
            var buttonBackspace = CreateButton("⌫", 230, 200);

            var ButtonAbout = CreateButton("О программе", 57, 230, 200);

            form.Controls.Add(textBox);

            form.Controls.Add(button1);
            form.Controls.Add(button2);
            form.Controls.Add(button3);
            form.Controls.Add(button4);
            form.Controls.Add(button5);
            form.Controls.Add(button6);
            form.Controls.Add(button7);
            form.Controls.Add(button8);
            form.Controls.Add(button9);
            form.Controls.Add(button0);
            form.Controls.Add(buttonDecimal);
            form.Controls.Add(buttonClear);

            form.Controls.Add(buttonPlus);
            form.Controls.Add(buttonMinus);
            form.Controls.Add(buttonMultiply);
            form.Controls.Add(buttonDivide);
            form.Controls.Add(buttonEquals);
            form.Controls.Add(buttonBackspace);

            form.Controls.Add(ButtonAbout);

            button1.Click += delegate { click("1", textBox); };
            button2.Click += delegate { click("2", textBox); };
            button3.Click += delegate { click("3", textBox); };
            button4.Click += delegate { click("4", textBox); };
            button5.Click += delegate { click("5", textBox); };
            button6.Click += delegate { click("6", textBox); };
            button7.Click += delegate { click("7", textBox); };
            button8.Click += delegate { click("8", textBox); };
            button9.Click += delegate { click("9", textBox); };
            button0.Click += delegate { click("0", textBox); };

            buttonDecimal.Click += delegate { click(",", textBox); };
            buttonClear.Click += delegate { textBox.Clear(); };
            buttonPlus.Click += delegate { click("+", textBox); };
            buttonMinus.Click += delegate { click("-", textBox); };
            buttonMultiply.Click += delegate { click("*", textBox); };
            buttonDivide.Click += delegate { click("/", textBox); };
            buttonEquals.Click += delegate { Calculate(textBox); };
            buttonBackspace.Click += delegate { if (textBox.Text.Length > 0) textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1); };

            ButtonAbout.Click += delegate { About(); };

            Application.Run(form);
        }

        static Button CreateButton(string text, int x, int y, int width = 100)
        {
            return new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(width, 30),
                Font = new Font("Arial", 10)
            };
        }

        static void click(string text, TextBox textBox)
        {
            textBox.Text += text;
        }

        static void Calculate(TextBox? textBox)
        {
            if (textBox == null || string.IsNullOrWhiteSpace(textBox.Text))
                return;

            var engine = new CalculationEngine();
            try
            {
                double result = engine.Calculate(textBox.Text);
                textBox.Text = result.ToString("G", System.Globalization.CultureInfo.InvariantCulture).Replace('.', ',');
            }
            catch
            {

            }
        }

        static void About()
        {
            var aboutForm = new Form
            {
                Text = "О программе",
                Size = new Size(250, 125),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false
            };

            var label = new Label
            {
                Text = "Калькулятор версии 1.0\nОт MichaelSoftWare2025",
                Location = new Point(60, 10),
                AutoSize = true
            };

            var okButton = new Button
            {
                Text = "OK",
                Location = new Point(100, 60),
            };

            okButton.Click += delegate { aboutForm.Close(); };

            aboutForm.Controls.Add(label);
            aboutForm.Controls.Add(okButton);
            aboutForm.Show();
        }
    }
}