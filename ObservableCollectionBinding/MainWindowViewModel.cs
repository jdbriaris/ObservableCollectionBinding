using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace ObservableCollectionBinding
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly MainWindowModel _model;
        private ICommand _addMarkerCommand;
        private ICommand _deleteMarkerCommand;

        public MainWindowViewModel(MainWindowModel model)
        {
            _model = model;

            Subscribe();
        }

        public ICommand AddMarkerCommand
        {
            get { return _addMarkerCommand ?? (_addMarkerCommand = new RelayCommand(() => _model.AddMarker())); }
        }

        public ICommand DeleteMarkerCommand
        {
            get
            {
                return _deleteMarkerCommand ?? (_deleteMarkerCommand = new RelayCommand(() => _model.DeleteMarker()));
            }
        }

        public Marker SelectedMarker
        {
            get { return _model.SelectedMarker; }
            set { _model.SelectedMarker = value; }
        }

        public ObservableCollection<Marker> Markers
        {
            get { return _model.Markers; }
        }

        public Marker SetSelectedMarker
        {
            get { return _model.SelectedMarker; }
            set { _model.SelectedMarker = value; }
        }

        private void Subscribe()
        {
            _model.SelectedMarkerChanged += OnSelectedMarkerChanged;
        }

        private void OnSelectedMarkerChanged(object sender, EventArgs e)
        {
            RaisePropertyChanged("SelectedMarker");
        }
    }
}