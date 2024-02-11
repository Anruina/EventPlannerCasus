using Library.ApiService;
using EventPlannerMAUI.MobileApp;
using Library.Models;

namespace EventPlannerMAUI.MVVM.View;

public partial class EventDetailMapPage : ContentPage
{

    private readonly ApiService _apiService;

    private int _currentRoom;
    private List<string> _schedule;

    public EventDetailMapPage()
    {

        InitializeComponent();

        _apiService = ServiceLocator.apiService;
        _currentRoom = 0;
        _schedule = new List<string>();

        List<string> ModeOfTransport = new List<string>() { "Car", "Bike", "Bus" };

        TransportPicker.ItemsSource = ModeOfTransport;
        TransportPicker.SelectedItem = ModeOfTransport[0];

    }

    public async void OnSetEventId(int eventId)
    {

        Event? currentEvent = await _apiService.GetSpecific<Event>("Api/Events/", eventId);

        if (currentEvent != null && currentEvent.Activities != null)
        {

            _schedule.Clear();

            _schedule.Add("Entrance");
            _schedule.Add("Balie");
            _schedule.Add("B3.200");
            
            for (int i = 0; i < currentEvent.Activities?.Count; i++)
            {

                if (i > 0 && currentEvent.Activities[i].StartTime != currentEvent.Activities[i - 1].EndTime)
                    _schedule.Add("B3.104");

                _schedule.Add(currentEvent.Activities[i].Room);

            }

            _schedule.Add("Entrance");

        }

    }

    private void OnSelectedTransportChanged(object sender, EventArgs e)
    {

        if (TransportPicker.SelectedItem != null && _schedule.Count > 0)
        {

            if (TransportPicker.SelectedItem == "Bike" && !MainMapPath.IsHandicapped)
                _schedule[0] = "C0.1 Stair";
            else
                _schedule[0] = "Entrance";

            if (_currentRoom == 1)
            {

                MainMapPath.StartPos = _schedule[0];
                MainMapPath.EndPos = _schedule[1];

                MapView.Invalidate();

            }

        }

    }

    private void OnNextClick(object sender, EventArgs e)
    {

        if (_currentRoom < _schedule.Count - 1)
        {

            _currentRoom++;
            MainMapPath.StartPos = _schedule[_currentRoom - 1];
            MainMapPath.EndPos = _schedule[_currentRoom];
            MainMapPath.Emergency = false;

            MapView.Invalidate();

        }

    }

    private void OnPreviouseClick(object sender, EventArgs e)
    {

        if (_currentRoom > 1)
        {

            _currentRoom--;
            MainMapPath.StartPos = _schedule[_currentRoom - 1];
            MainMapPath.EndPos = _schedule[_currentRoom];
            MainMapPath.Emergency = false;

            MapView.Invalidate();

        }

    }

    private void IsHandicappedClick(object sender, EventArgs e)
    {

        if (TransportPicker.SelectedItem == "Bike")
            _schedule[0] = "Entrance";

        MainMapPath.IsHandicapped = IsHandicappedCheckBox.IsChecked;

        if (_currentRoom == 1)
            MainMapPath.StartPos = _schedule[0];

        MapView.Invalidate();

    }

    private void OnEmergencyClick(object sender, EventArgs e)
    {

        if (_currentRoom >= 0 && _currentRoom < _schedule.Count)
        {

            MainMapPath.StartPos = _schedule[_currentRoom];
            MainMapPath.Emergency = true;
            MapView.Invalidate();

        }

    }

    private void OnMapPinch(object sender, PinchGestureUpdatedEventArgs e)
    {

        if (e.Status == GestureStatus.Started)
        {
            
            MapView.AnchorX = 0;
            MapView.AnchorY = 0;

        }
        else if (e.Status == GestureStatus.Running)
        {

            MapView.Scale *= e.Scale;

            if (MapView.Scale > 1.6f || MapView.Scale < 0.85f)
                MapView.Scale /= e.Scale;
            else
            {

                MapView.WidthRequest *= e.Scale;
                MapView.HeightRequest *= e.Scale;

            }

        }

    }

    private void OnMapPan(object sender, PanUpdatedEventArgs e)
    {

        if ((e.TotalX < 0.0f && MapView.TranslationX > -MapView.WidthRequest + 500) || (e.TotalX > 0.0f && MapView.TranslationX < 0))
            MapView.TranslationX += e.TotalX;

        if ((e.TotalY < 0.0f && MapView.TranslationY > -MapView.HeightRequest + 650) || (e.TotalY > 0.0f && MapView.TranslationY < MapView.HeightRequest - 600))
            MapView.TranslationY += e.TotalY;

    }

}