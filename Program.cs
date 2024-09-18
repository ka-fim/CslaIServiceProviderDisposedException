using CslaIServiceProviderDisposedException;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.SetupCslaWithLocalProxy();

var portal = CslaServices.DataPortalFactory.GetPortal<DataPortalExceptionBusinessObject>();

var obj = await portal.FetchAsync();
obj.Name = "Test";

try
{
    obj = await obj.SaveAsync();
}
catch (Exception e)
{
    Console.WriteLine($"Save failed: {e.Message}");
}

// ObjectDisposedException is thrown here
obj.Name = "Test2";

// Works:
//var obj2 = await portal.FetchAsync();
//obj2.Name = "Test";
//try
//{
//    obj2 = await obj2.SaveAsync();
//}
//catch (Exception e)
//{
//    Console.WriteLine($"Save failed: {e.Message}");
//}

Console.WriteLine("Finished!");
Console.ReadKey();