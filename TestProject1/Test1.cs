[TestClass]
public class ExamTestsAppTest
{
    [DataTestMethod]
    [DataRow(1,2,3)]
    [DataRow(4,6,10)]
    public void AddTest(int a, int b, int expected)
    {
        var actual = Operations.Add(a,b);
        Assert.AreEqual(expected, actual, "Test's error in AddTest() method");
    }

    [DataTestMethod]
    [DataRow(3,4,-1)]
    [DataRow(60,56,4)]
    public void SubTest(int a, int b, int expected)
    {
        var actual = Operations.Sub(a, b);
        Assert.AreEqual(expected, actual, "Test's error in SubTest() method");
    }

    [DataTestMethod]
    [DataRow(5,7,35)]
    [DataRow(1,5,5)]
    public void MultTest(int a, int b, int expected)
    {
        var actual = Operations.Mult(a, b);
        Assert.AreEqual(expected, actual, "Test's error in MultTest() method");
    }

    [DataTestMethod]
    [DataRow(1, 2, 3, 6)]
    [DataRow(2, -7, 7, 2)]
    public void SumTest(int a, int b, int c, int expected)
    {
        var actual = Operations.Sum(a, b, c);
        Assert.AreEqual(expected, actual, "Test's error in SumTest() method");
    }

}

