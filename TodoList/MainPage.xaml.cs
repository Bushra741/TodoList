
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace TodoList
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<string> MyList { get; set; } = new ObservableCollection<string>();
        public ICommand RemoveCommand { get; }
        public MainPage()
        {
            InitializeComponent();
           
            BindingContext = this;
        }
        private void OnButtonClick(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(TodoListEntry.Text))
            {
                string item = TodoListEntry.Text;
                MyList.Add(item);

            }
           
        }
        private void OnDeleteButton(object sender, EventArgs e)
        {
            string item = TodoListEntry.Text;
            if (MyList.Contains(item))
            {
                MyList.Remove(item);
            }

        }


    }

}
