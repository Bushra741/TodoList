


using System.Diagnostics;

namespace TodoList
{

    public partial class MoreInfo : ContentPage
    {
        public TodoContent listTitle { get; set; }
        public MoreInfo(TodoContent selectedItem)
        {

            InitializeComponent();
            
            listTitle = selectedItem;
            BindingContext = selectedItem;
        }
        private async void SaveClicked(object sender, EventArgs e)

        {
          
            string TheDescription = listTitle.Description;
          //  DescriptionEditor.Text = TheDescription;

            bool confirm = await DisplayAlert("Save Note", "Do you want to save?", "Yes", "No");

            if (confirm)
            {
                { 
                    listTitle.Description = DescriptionEditor.Text;
                    await DisplayAlert("Saved", "Your note are saved.", "OK");
                    
                    Debug.WriteLine("SaveClicked");
                }
            }
            else

            {
                await DisplayAlert("Cancelled", "Your note was not saved.", "OK");
                DescriptionEditor.Text = string.Empty;
            }
            
        }


        private async void backClicked(object sender, EventArgs e)
        {

            await Navigation.PopAsync();

        }
    }
}
