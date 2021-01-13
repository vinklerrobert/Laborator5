using PersonalAgenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalAgenda
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendaPage : ContentPage
    {
        public AgendaPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetNotesAsync();
        }
        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NotePage
            {

                BindingContext = new Agenda()
            });
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new NotePage
                {
                    BindingContext = e.SelectedItem as Agenda
                });
            }
        }
        async void OnButtonClicked(object sender, EventArgs args)
        {
            var list = await App.Database.GetNotesAsync();
            var list2 = await App.Database.GetNotesAsync();
            list2.Clear();
            foreach (var e in list)
            {
                if (!e.isChecked)
                    list2.Add(e);
                else
                    await App.Database.DeleteNoteAsync(e);
            }
            listView.ItemsSource = list2;
        }

    }
}