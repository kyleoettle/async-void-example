namespace Void.Demo
{
    public interface IDemoService
    {
        Task PerformTaskAsync();
        void PerformVoidAsync();
    }

    public class DemoService : IDemoService
    {
        public async Task PerformTaskAsync()
        {
            await Task.Delay(1000);
            throw new NotImplementedException(nameof(PerformTaskAsync));
        }

        public async void PerformVoidAsync()
        {
            await Task.Delay(1000);
            throw new NotImplementedException(nameof(PerformTaskAsync));
        }
    }
}
