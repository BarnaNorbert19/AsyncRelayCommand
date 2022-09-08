# Usage
```csharp
 public class MainViewModel : BaseViewModel
    {
        public AsyncRelayCommand AppearCommand { get; set; }

        public MainViewModel()
        {
            AppearCommand = new AsyncRelayCommand(AppearActionAsync);
        }

        private async Task AppearActionAsync(object parameter)
        {
			//logic
        }
    }
```
