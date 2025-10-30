using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfLab2Var8
{
    public partial class MainWindow : Window
    {
        private Formula currentFormula;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Класс для хранения данных формулы
        public class Formula
        {
            public double A { get; set; }
            public double B { get; set; }
            public double C { get; set; }

            public virtual double Calculate()
            {
                // Базовая реализация - должна быть переопределена
                return 0;
            }
        }

        // Конкретные реализации формул для варианта 8
        public class Formula1 : Formula
        {
            public override double Calculate()
            {
                // Реализация формулы 1 для варианта 8
                if (C == 0) throw new DivideByZeroException("Деление на ноль!");
                return (A + B) / C;
            }
        }

        public class Formula2 : Formula
        {
            public override double Calculate()
            {
                // Реализация формулы 2 для варианта 8
                return (A - B) * C;
            }
        }

        public class Formula3 : Formula
        {
            public override double Calculate()
            {
                // Реализация формулы 3 для варианта 8
                return A * B - C;
            }
        }

        public class Formula4 : Formula
        {
            public override double Calculate()
            {
                // Реализация формулы 4 для варианта 8
                if (B == 0) throw new DivideByZeroException("Деление на ноль!");
                return A / B + C;
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            // Инициализация соответствующей формулы при выборе RadioButton
            if (sender == rbFormula1) currentFormula = new Formula1();
            else if (sender == rbFormula2) currentFormula = new Formula2();
            else if (sender == rbFormula3) currentFormula = new Formula3();
            else if (sender == rbFormula4) currentFormula = new Formula4();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (currentFormula == null)
                {
                    MessageBox.Show("Выберите формулу для расчета!");
                    return;
                }

                // Получение значений из соответствующих полей ввода
                if (rbFormula1.IsChecked == true)
                {
                    currentFormula.A = double.Parse(txtA1.Text);
                    currentFormula.B = double.Parse(txtB1.Text);
                    currentFormula.C = double.Parse(txtC1.Text);
                }
                else if (rbFormula2.IsChecked == true)
                {
                    currentFormula.A = double.Parse(txtA2.Text);
                    currentFormula.B = double.Parse(txtB2.Text);
                    currentFormula.C = double.Parse(txtC2.Text);
                }
                else if (rbFormula3.IsChecked == true)
                {
                    currentFormula.A = double.Parse(txtA3.Text);
                    currentFormula.B = double.Parse(txtB3.Text);
                    currentFormula.C = double.Parse(txtC3.Text);
                }
                else if (rbFormula4.IsChecked == true)
                {
                    currentFormula.A = double.Parse(txtA4.Text);
                    currentFormula.B = double.Parse(txtB4.Text);
                    currentFormula.C = double.Parse(txtC4.Text);
                }

                double result = currentFormula.Calculate();
                tbResult.Text = $"Результат: {result:F4}";
                this.Title = $"Лабораторная работа 2 - Результат: {result:F4}";
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения!");
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}