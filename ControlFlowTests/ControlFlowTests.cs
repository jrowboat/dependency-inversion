using Xunit;
using System;

namespace ControlFlowTests;

public class ControlFlowTests
{
    // Testing the hypothesis that a lower level module does not control the execution of a higher level module
    [Fact]
    public void LowerModuleFailedTest()
    {
        var lowerModule = new LowerModule();
        var service = new HigherModule(lowerModule);
        Assert.Equal("The lower module failed doing its job.", service.ControlTheFlow());
    }
}

public interface ILowerModule
{
  string DoJob();
}

public class LowerModule : ILowerModule
{
  public string DoJob()
  {
    throw new NotImplementedException(message: "I don't know what to do!");
  }
}

public class HigherModule {
    private readonly ILowerModule _lowerModule;
    public HigherModule(LowerModule lowerModule)
    {
        _lowerModule = lowerModule;
    }

    public string ControlTheFlow()
    {
        try
        {
            return _lowerModule.DoJob();
        }
        catch
        {
            return "The lower module failed doing its job.";
        }
    }
}

// Test to write
// Test a system has fallback resources in order to persist and conduct its behavior if plan A fails (have another class that does the same thing) example, service locator containing multiple entries in a service collection with a key of a single interface