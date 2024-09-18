using Csla;

namespace CslaIServiceProviderDisposedException;

[Serializable]
public class DataPortalExceptionBusinessObject : BusinessBase<DataPortalExceptionBusinessObject>
{
    public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(nameof(Name));

    public string Name
    {
        get => GetProperty(NameProperty);
        set => SetProperty(NameProperty, value);
    }

    [Fetch]
    private void Fetch()
    {
        
    }

    [Update]
    private void Update()
    {
        throw new InvalidOperationException("No update today");
    }
}