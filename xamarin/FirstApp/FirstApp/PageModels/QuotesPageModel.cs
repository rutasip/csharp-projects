using FirstApp.Interfaces;
using FirstApp.Models;
using FirstApp.Services;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace FirstApp.PageModels
{
    public class QuotesPageModel : FreshBasePageModel
    {
        public ObservableCollection<Quote> Quotes { get; set; }
        private IRestService _restService;
        public Command AddQuoteCommand { get; set; }

        public QuotesPageModel(IRestService restService)
        {
            _restService = restService;
            Quotes = new ObservableCollection<Quote>();
            LoadQuotes();
            AddQuoteCommand = new Command(AddQuote);
        }

        private bool isBusy = true;

        public bool IsBusy
        {
            get { return isBusy; }
            set 
            { 
                isBusy = value;
                RaisePropertyChanged();
            }
        }


        private void AddQuote()
        {
            CoreMethods.PushPageModel<AddQuotePageModel>();
        }

        private async void LoadQuotes()
        {
            var quotes = await _restService.GetQuotes();
            foreach (var quote in quotes)
            {
                Quotes.Add(quote);
            }
            IsBusy = false;
        }

        private Quote selectedQuote;

        public Quote SelectedQuote
        {
            get { return selectedQuote; }
            set 
            {
                selectedQuote = value;
                if (selectedQuote != null)
                {
                    CoreMethods.PushPageModel<QuoteDetailsPageModel>(selectedQuote);
                }
            }
        }
    }
}
