using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalAgenda.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalAgenda
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotePage : ContentPage
    {

        bool isCheck = false;
        public NotePage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Agenda)BindingContext;
            note.isChecked = isCheck;
            await App.Database.SaveNoteAsync(note);
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Agenda)BindingContext;
            await App.Database.DeleteNoteAsync(note);
            await Navigation.PopAsync();
        }

        void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            isCheck = e.Value;
        }
    }
}