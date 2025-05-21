

using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Windows.Input;

namespace TodoList
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<TodoContent> MyList { get; set; } = new ObservableCollection<TodoContent>();
        public ICommand RemoveCommand { get; }

        private bool TapSelection = false;
        public MainPage()
        {
            InitializeComponent();

            BindingContext = this;

        }
        private void OnButtonClick(object sender, EventArgs e)
        {
            TodoContent todoContent = new TodoContent();

            if (!string.IsNullOrWhiteSpace(TodoListEntry.Text))

            {
                todoContent.Title = TodoListEntry.Text;
                MyList.Add(todoContent);

            }
            TodoListEntry.Text = string.Empty;
        }

     

        private async void OnDeleteButton(object sender, EventArgs e)
        {
            var selecteditems = TodoListCollection.SelectedItems;

            if (selecteditems == null || selecteditems.Count == 0)
            {
                await DisplayAlert("Nothing Selected", "Please select items to delete.", "OK");
                return;
            }
            {
                bool answer = await DisplayAlert("Confirm Delete", $"Are you sure you want to delete item(s)?", "Yes", "No");

                if (answer)
                {
                    foreach (var item in selecteditems.ToList())
                    {
                        if (item is TodoContent todoContent)
                        {
                            MyList.Remove(todoContent);
                        }
                    }

                    TodoListCollection.SelectedItems.Clear();

                    TodoListCollection.SelectionMode = SelectionMode.Single;

                    TodoListCollection.SelectedItem = null;
                    TapSelection = false;

                    SelectButton.Text = "Select";
                }

            }
        }

        private void OnSelectClick(object sender, EventArgs e)
        {
            TapSelection = !TapSelection;

            if (TapSelection)
            {
         
                TodoListCollection.SelectionMode = SelectionMode.Multiple;
                (sender as Button).Text = "Cancel Select";
                DisplayAlert("Selection Mode", "Select items to delete, then press Delete.", "OK");
            }
            else
            {
                TodoListCollection.SelectedItems.Clear();
                TodoListCollection.SelectionMode = SelectionMode.None;
              
            }

        }



        private async void ListIn(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.CurrentSelection.FirstOrDefault() as TodoContent;

            if (selectedItem == null || TapSelection)
            {
                return;

            }
            await Navigation.PushAsync(new MoreInfo(selectedItem));
          
        }
    
        
    }
}
