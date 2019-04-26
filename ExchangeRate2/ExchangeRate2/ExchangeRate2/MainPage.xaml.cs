using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExchangeRate2
{
    public partial class MainPage : ContentPage
    {
        public enum Currency
        {
            Euro,
            Dollar,
            Ruble
        }
        public Dictionary<Currency, string> CurrencyText = new Dictionary<Currency, string>
        {
            [Currency.Euro] = "€",
            [Currency.Dollar] = "$",
            [Currency.Ruble] = "₽",
        };

        public MainPage()
        {
            InitializeComponent();
            AddCurrencyButtons();
            AddScrollView();
        }

        private void AddCurrencyButtons()
        {
            var grid = new Grid() {RowDefinitions = new RowDefinitionCollection() { }, Margin = 10 };
            int collInd = 0;
            foreach (Currency currency in Enum.GetValues(typeof(Currency)))
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                var newBtn = new Button() { Text = CurrencyText[currency] };
                newBtn.Clicked += delegate (object sender, EventArgs e) { Button_Click(sender, e, currency); };
                grid.Children.Add(newBtn, collInd, 0);
                collInd++;
            }
            MainLayout.Children.Add(grid);
        }

        private void AddScrollView()
        {
            var list = new ListView() { };
            //list.ItemsSource =  
        }

        private void Button_Click(object sender, EventArgs e, Currency currency)
        {
            DisplayAlert("Title", currency.ToString(), "Ok");
        }

        private void RefreshData(object sender, EventArgs e)
        {
            DisplayAlert("Title", "Refreshing was successful.", "Ok");
        }
    }
}
