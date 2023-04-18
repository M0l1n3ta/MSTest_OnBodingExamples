

using Microsoft.VisualStudio.TestTools.UnitTesting;

public static class CustomAsserts{

    public static void IsInRange(this Assert assert,
                                int actual,
                                int expectedMinimunValue,
                                int expectedMaximunValue){
        if(actual < expectedMinimunValue || actual > expectedMaximunValue)
        {
            throw new AssertFailedException($"{actual} value was not in the range {expectedMinimunValue}-{expectedMaximunValue}");
        }

    }
}