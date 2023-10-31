using System;
using Xunit;

namespace CastingTests;

public class CastingTests
{
    // When an interface is inherited by a concrete class, the class can be casted to the type of the interface
    [Fact]
    public void ValidCastTest()
    {
        var concreteClass = new NotificationService();
        var validCast = (INotificationService)concreteClass;
        var notify = validCast.Notify();
        Assert.Equal("Notified", notify);
    }

    // Casting does not work if the interface is not inherited 
    [Fact]
    public void InvalidCastTest()
    {
        var concreteClass = new NotificationService();
        Assert.Throws<InvalidCastException>(() => {
            var invalidCast = (IShippingService)concreteClass;
            var notify = invalidCast.Notify();
        });
    }

    // A concrete class can inherit multiple interfaces and, thus, be casted to the type of each interface
    [Fact]
    public void MultipleInterfaceInheritanceTest()
    {
        NotificationService concreteClass = new NotificationService();
        IDonutService castToIDonut = concreteClass;
        string finish = castToIDonut.Finish();
        Assert.Equal("I finished", finish);

        // NotificationService service = new NotificationService();
        INotificationService castToINotification = concreteClass;
        string notify = castToINotification.Notify();
        Assert.Equal("Notified", notify);
    }

    // When a class is casted to an interface type, anything that interface inherits is accessible
    [Fact]
    public void InheritanceChainTest()
    {
        NotificationService concreteClass = new NotificationService();
        INotificationService validCast = concreteClass;
        string notify = validCast.Notify();
        Assert.Equal("Notified", notify);
        string failHim = validCast.FailHim();
        Assert.Equal("YOU SHALL NOT PASS!", failHim);
    }

    // An instance of a concrete class casted to numerous interfaces it inherits can be recasted to another inherited interface type, even if that interface is not in 
    // the inheritance chain of the current interface (the original data being referenced is the concrete class, so an explicit casting is needed).
    [Fact]
    public void ReferenceCastTest()
    {
        NotificationService concreteClass = new NotificationService();
        INotificationService firstCast = concreteClass;
        ICollegeService secondCast = firstCast;
        ITimeService thirdCastNotInheritedBySecond = (ITimeService)secondCast;
        Assert.Equal("Noon", thirdCastNotInheritedBySecond.WhatTimeIsIt());
    }

    // An instance of a concrete class which has been casted to an interface type can be casted back to the original concrete type.
    [Fact]
    public void ResetToOriginalTypeTest()
    {
        NotificationService concreteClass = new NotificationService();
        INotificationService validCast = concreteClass;
        NotificationService castToOriginalClassType = (NotificationService)validCast;
        Assert.Equal("Noon", castToOriginalClassType.WhatTimeIsIt());
    }

    // A concrete class can be casted to different interfaces, which each have access to a subset of its concrete methods
    [Fact]
    public void MethodAbstractionTest()
    {
        NotificationService concreteClass = new NotificationService();
        INotificationService iNotificationService = concreteClass;
        ICollegeService iCollegeService = iNotificationService;
        // can't call notify with iCollegeService, inheritance only works one way
        var firstCollegeCallWithoutNotificationService = iCollegeService.FailHim();
        ITimeService iTimeService = (ITimeService)iCollegeService;
        // no access to college methods
        var otherCollegeCall = iTimeService.WhatTimeIsIt();
        Assert.Equal("Noon", iTimeService.WhatTimeIsIt());
    }
}

public interface INotificationService : ICollegeService
{
    string Notify();
}

public interface ICollegeService
{
    string FailHim();
}

public interface IShippingService
{
    string Notify();
}

public interface IDonutService : ITimeService
{
    string Finish();
}

public interface ITimeService
{
    string WhatTimeIsIt();
}

public class NotificationService : IDonutService, INotificationService
{
    public string Notify()
    {
        return "Notified";
    }

    public string Finish()
    {
        return "I finished";
    }

    public string FailHim()
    {
        return "YOU SHALL NOT PASS!";
    }

    public string WhatTimeIsIt()
    {
        return "Noon";
    }
}