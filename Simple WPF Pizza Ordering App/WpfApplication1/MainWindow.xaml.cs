namespace WpfApplication1
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string selected_pizza = first.Text;
            string uwagi = Uwagi.Text;
            string poziom_sosu = "";

            if (slider.Value <= 1)
            {
                poziom_sosu = "Łagodny";
            }
            else if (slider.Value >= 2 && slider.Value < 3 )
            {
                poziom_sosu = "Zrównoważony";
            }
            else if (slider.Value == 3)
            {
                poziom_sosu = "Ostry";
            }
                lab1.Content = selected_pizza;

            if (Radio1.IsChecked == true)
            {
                lab1.Content = selected_pizza + "\n" + "Rozmiar: Mały" + "\n" + "Poziom ostrości sosu: "  + poziom_sosu + "\n" + "Uwagi: " + uwagi;
                Koszt.Text = "15 zł ";
            }


            if (Radio2.IsChecked == true)
            {
                lab1.Content = "Rodzaj: " + selected_pizza + "\n" + "Rozmiar: Duży" + "\n" + "Poziom ostrości sosu: " + poziom_sosu + "\n" + "Uwagi: " + uwagi;
                Koszt.Text = "20 zł ";
            }


            if (Radio3.IsChecked == true)
            {
                lab1.Content = "Rodzaj: " + selected_pizza + "\n" + "Rozmiar: Mega" + "\n" + "Poziom ostrości sosu: " + poziom_sosu + "\n" + "Uwagi: " + uwagi;
                Koszt.Text = "40 zł (w tym 5 zł dostawa) ";
            }

            if (Radio1.IsChecked == true && check1.IsChecked == true)
                {
                    lab1.Content = "Rodzaj: " + selected_pizza + "\n" + "Rozmiar: Mały" + "\n" + "Sos Pomidorowy" + "\n" + "Poziom ostrości sosu: " + poziom_sosu + "\n" + "Uwagi: " + uwagi;
                    Koszt.Text = "16 zł ";
                }

                if (Radio1.IsChecked == true && check2.IsChecked == true)
                {

                    lab1.Content = "Rodzaj: " + selected_pizza + "\n" + "Rozmiar: Mały" + "\n" + "Sos Czosnkowy" + "\n" + "Poziom ostrości sosu: " + poziom_sosu + "\n" + "Uwagi: " + uwagi;
                    Koszt.Text = "16 zł ";
                }
                if (Radio1.IsChecked == true && check2.IsChecked == true && check1.IsChecked == true)
                {

                    lab1.Content = "Rodzaj: " + selected_pizza + "\n" + "Rozmiar: Mały" + "\n" + "Sos Pomidorowy" + "\n" + "Sos Czosnkowy" + "\n" + "Poziom ostrości sosu: " + poziom_sosu + "\n" + "Uwagi: " + uwagi;
                    Koszt.Text = "17 zł )";
                }

                if (Radio2.IsChecked == true && check1.IsChecked == true)
                {

                    lab1.Content = "Rodzaj: " + selected_pizza + "\n" + "Rozmiar: Duży" + "\n" + "Sos Pomidorowy" + "\n" + "Poziom ostrości sosu: " + poziom_sosu + "\n" + "Uwagi: " + uwagi;
                    Koszt.Text = "21 zł";
                }
                if (Radio2.IsChecked == true && check2.IsChecked == true)
                {

                    lab1.Content = "Rodzaj: " + selected_pizza + "\n" + "Rozmiar: Duży" + "\n" + "Sos Czosnkowy" + "\n" + "Poziom ostrości sosu: " + poziom_sosu + "\n" + "Uwagi: " + uwagi;
                    Koszt.Text = "21 zł";
                }
                if (Radio2.IsChecked == true && check2.IsChecked == true && check1.IsChecked == true)
                {
                    lab1.Content = "Rodzaj: " + selected_pizza + "\n" + "Rozmiar: Duży" + "\n" + "Sos Pomidorowy" + "\n" + "Sos Czosnkowy" + "\n" + "Poziom ostrości sosu: " + poziom_sosu + "\n" + "Uwagi: " + uwagi;
                    Koszt.Text = "22 zł";
                }

                if (Radio3.IsChecked == true && check1.IsChecked == true)
                {
                    lab1.Content = "Rodzaj: " + selected_pizza + "\n" + "Rozmiar: Mega" + "\n" + "Sos Pomidorowy" + "\n" + "Poziom ostrości sosu: " + poziom_sosu + "\n" + "Uwagi: " + uwagi;
                    Koszt.Text = "41 zł (W tym dostawa 5 zł)";
                }
                if (Radio3.IsChecked == true && check2.IsChecked == true)
                {
                    lab1.Content = "Rodzaj: " + selected_pizza + "\n" + "Rozmiar: Mega" + "\n" + "Sos Czosnkowy" + "\n" + "Poziom ostrości sosu: " + poziom_sosu + "\n" + "Uwagi: " + uwagi;
                    Koszt.Text = "41 zł (W tym dostawa 5 zł)";
                }
                if (Radio3.IsChecked == true && check2.IsChecked == true && check1.IsChecked == true)
                {
                    lab1.Content = "Rodzaj: " + selected_pizza + "\n" + "Rozmiar: Mega" + "\n" + "Sos Pomidorowy" + "\n" + "Sos Czosnkowy" + "\n" + "Poziom ostrości sosu: " + poziom_sosu + "\n" + "Uwagi: " + uwagi;
                    Koszt.Text = "42 zł (W tym dostawa 5 zł)";
                }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int val = Convert.ToInt32(e.NewValue);
            string msg = String.Format("Poziom Ostrości Sosu: {0}", val);
            this.SliderText.Text = msg;
        }

        private void Radio1_Checked(object sender, RoutedEventArgs e)
        {
            Zamowienie.IsEnabled = true;
        }

        private void Radio2_Checked(object sender, RoutedEventArgs e)
        {
            Zamowienie.IsEnabled = true;
        }

        private void Radio3_Checked(object sender, RoutedEventArgs e)
        {
            Zamowienie.IsEnabled = true;
        }
    }
}
