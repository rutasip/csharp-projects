using System;
using System.Collections.Generic;
using System.Text;
using FirstApp.Models;
using FreshMvvm;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FirstApp.PageModels
{
    public class QuoteDetailsPageModel : FreshBasePageModel
    {
        public Quote Quote { get; set; }
        public Command CopyQuoteCommand { get; set; }

        public QuoteDetailsPageModel()
        {
            CopyQuoteCommand = new Command(CopyQuote);
        }
        public override void Init(object initData)
        {
            base.Init(initData);
            Quote = (Quote)initData;
        }

        private void CopyQuote()
        {
            Clipboard.SetTextAsync(Quote.quote);
        }
    }
}
