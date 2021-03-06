using System;
using System.Collections.Generic;
using System.Text;
using FirstApp.Interfaces;
using FirstApp.Models;
using FreshMvvm;
using Xamarin.Forms;

namespace FirstApp.PageModels
{
    public class AddQuotePageModel : FreshBasePageModel
    {
        private IRestService _restService;
        public Command SaveCommand { get; set; }
        public AddQuotePageModel(IRestService restService)
        {
            _restService = restService;
            SaveCommand = new Command(SaveQuote);
        }

        public override void Init(object initData)
        {
            base.Init(initData);
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string quote;
        public string Quote
        {
            get { return quote; }
            set { quote = value; }
        }

        private string author;
        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        private async void SaveQuote()
        {
            var quote = new Quote()
            {
                author = Author,
                quote = Quote,
            };

            var result = await _restService.PostQuote(quote);
            if (result)
            {
                await CoreMethods.DisplayAlert("Hi", "Your record has been added successfully...", "Alright");
            }
            else
            {
                await CoreMethods.DisplayAlert("Oops", "Something went wrong", "Alright");
            }
        }
    }
}
