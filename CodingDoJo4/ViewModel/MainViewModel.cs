using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace CodingDoJo4.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        private string newFirstname = "";
        private string newLastname = "";
        private int newSocSecNo = 0;
        private DateTime newBirthDate;
        string fileName = @"C:\Users\user\Documents\Visual Studio 2015\Projects\test.csv";
        int tempSizeOfList;


        private ObservableCollection<PersonVM> newPersonList = new ObservableCollection<PersonVM>();

        RelayCommand addBtnClickedCommand;
        RelayCommand loadDataBtnCommand;
        RelayCommand saveDataBtnCommand;

        public string NewFirstname
        {
            get { return newFirstname; }
            set { newFirstname = value; }
        }

        public string NewLastname
        {
            get { return newLastname; }
            set { newLastname = value; }
        }

        public int NewSocSecNo
        {
            get { return newSocSecNo; }
            set { newSocSecNo = value; }
        }

        public ObservableCollection<PersonVM> NewPersonList
        {
            get { return newPersonList; }
            set { newPersonList = value; }
        }

        public DateTime NewBirthDate
        {
            get { return newBirthDate; }
            set { newBirthDate = value; }
        }

        public RelayCommand AddBtnClickedCommand
        {
            get { return addBtnClickedCommand; }
            set { addBtnClickedCommand = value; }
        }

        public RelayCommand LoadDataBtnCommand
        {
            get { return loadDataBtnCommand; }
            set { loadDataBtnCommand = value; }
        }

        public RelayCommand SaveDataBtnCommand
        {
            get { return saveDataBtnCommand; }
            set { saveDataBtnCommand = value; }
        }

        public MainViewModel()
        {
            AddBtnClickedCommand = new RelayCommand(AddButtonClicked, CanExecute);
            LoadDataBtnCommand = new RelayCommand(LoadDataListBtnClicked, CSVFileExist);
            SaveDataBtnCommand = new RelayCommand(SaveDataListBtnClicked, CanSaveDataToCSVList);
            Load();
        }

        private bool CanSaveDataToCSVList()
        {            
            foreach (PersonVM TempPers in newPersonList) { tempSizeOfList++; }
            return tempSizeOfList > 0;
        }

        private bool CSVFileExist()
        {
            return File.Exists(fileName);            
        }

        private void SaveDataListBtnClicked()
        {
            if (CSVFileExist())
            {
                File.Delete(fileName);
            }

            using (FileStream fs = File.Create(fileName))
            {
                foreach (PersonVM TempPers in newPersonList)
                {
                    String tempText = TempPers.Firstname + ", " + TempPers.Lastname + ", " + TempPers.SocSecNo + ", " + TempPers.BirthDate.ToString("d") + "\r\n" ;
                    AddText(fs, tempText);
                }
                fs.Close();
            }
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }

        private void LoadDataListBtnClicked()
        {
            if (CSVFileExist())
            {
                var fs = new StreamReader(File.OpenRead(fileName));
                {
                    while (!fs.EndOfStream)
                    {
                        var line = fs.ReadLine();

                        string[] stringList = line.Split(",".ToCharArray());

                        DateTime dt = Convert.ToDateTime(stringList[3]);
                        newPersonList.Add(new PersonVM(stringList[0], stringList[1], int.Parse(stringList[2]), dt));
                    }
                }
                fs.Close();
            }           
        }

        private bool CanExecute()
        {
            return NewLastname.Length > 2;
        }

        private void AddButtonClicked()
        {
            newPersonList.Add(new PersonVM(NewFirstname, NewLastname, NewSocSecNo, NewBirthDate));
        }

        public void Load()
        {
            newPersonList.Add(new PersonVM("name 1", "lastname 1", 123321, new DateTime(2010, 1, 18)));
            newPersonList.Add(new PersonVM("name 2", "lastname 2", 543321, new DateTime(1995, 5, 20)));
        }
    }
}