using PROJECT_NAME.Scripts.Window;

namespace PROJECT_NAME.Scripts.Infrastructure.Services.Window
{
  public interface IWindowService
  {
    void Open(WindowTypeId windowTypeId);
  }
}