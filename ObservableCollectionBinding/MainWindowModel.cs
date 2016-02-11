using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ObservableCollectionBinding
{
    public class MainWindowModel
    {
        private Marker _selectedMarker;

        public MainWindowModel()
        {
            var marker1 = new Marker(1);
            var marker2 = new Marker(2);
            var marker3 = new Marker(3);

            Markers = new ObservableCollection<Marker>
            {
                marker1,
                marker2,
                marker3
            };
        }

        public Marker SelectedMarker
        {
            get { return _selectedMarker; }
            set
            {
                _selectedMarker = value;
                RaiseSelectedMarkerChanged();
            }
        }

        public ObservableCollection<Marker> Markers { get; set; }
        public event EventHandler SelectedMarkerChanged;

        private void RaiseSelectedMarkerChanged()
        {
            var handler = SelectedMarkerChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void AddMarker()
        {
            var id = Markers.Any() ? Markers.Max(x => x.Id) + 1 : 1;
            var marker = new Marker(id);
            Markers.Add(marker);
        }

        public void DeleteMarker()
        {
            if (Markers.Any())
            {
                var max = Markers.Max(x => x.Id);
                var marker = Markers.Single(x => x.Id == max);
                Markers.Remove(marker);
            }
        }
    }
}