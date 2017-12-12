using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;
using WpfApp1.Model.Models;

namespace WpfApp1.ViewModel.ViewModels
{
    public class HistoryViewModel : BaseViewModel
    {
        private ObservableCollection<HistoryRecord> records;

        public ObservableCollection<HistoryRecord> Records
        {
            get => records;
            set
            {
                this.records = value;
                OnPropertyChanged(nameof(Records));
            }
        }

        public HistoryViewModel()
        {
            if (!File.Exists("file.json"))
            {
                File.Create("file.json");
                this.Records = new ObservableCollection<HistoryRecord>();
            }
            else
            {
                var history = System.IO.File.ReadAllText("file.json");
                this.Records = new ObservableCollection<HistoryRecord>( JsonConvert.DeserializeObject<List<HistoryRecord>>(history));
            }
        }

        public void Serialize()
        {
            var json = JsonConvert.SerializeObject(records);
            System.IO.File.WriteAllText("file.json",json);
        }
    }
}
