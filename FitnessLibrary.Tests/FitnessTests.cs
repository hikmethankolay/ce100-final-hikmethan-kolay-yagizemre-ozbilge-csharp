
namespace FitnessLibrary.Tests {
public class FitnessTests {
        int fail = -1;
    int success = 0;

    [Fact]
    public void TestFileRead()
    {
        string testString = "1-)TEXT STRING1\n2-)TEXT STRING2\n3-)TEXT STRING3\n4-)TEXT STRING4\n5-)TEXT STRING5\n";
        Assert.Equal(testString, FileOperations.FileRead("test1", false));
    }

    [Fact]
    public void TestFileAppend()
    {
        string testString = "1-)TEXT STRING1\n2-)TEXT STRING2\n3-)TEXT STRING3\n4-)TEXT STRING4\n5-)TEXT STRING5\n6-)TEXT STRING6\n";
        string appendString = "TEXT STRING6";
        FileOperations.FileAppend("test2", appendString);
        Assert.Equal(testString, FileOperations.FileRead("test2", false));
    }

    [Fact]
    public void TestFileEdit()
    {
        string testString = "1-)TEXT STRING1\n2-)TEXT STRING2\n3-)TEXT STRING EDIT\n4-)TEXT STRING4\n5-)TEXT STRING5\n";
        string editString = "TEXT STRING EDIT";
        FileOperations.FileEdit("test3", 3, editString);
        Assert.Equal(testString, FileOperations.FileRead("test3", false));
    }

    [Fact]
    public void TestFileDelete()
    {
        string testString = "1-)TEXT STRING2\n2-)TEXT STRING3\n3-)TEXT STRING4\n4-)TEXT STRING5\n";
        FileOperations.FileLineDelete("test4", 1);
        Assert.Equal(testString, FileOperations.FileRead("test4", false));
    }

    [Fact]
    public void TestFileWrite()
    {
        string testString = "1-)TEXT STRING WRITE\n";
        string writeString = "TEXT STRING WRITE";
        FileOperations.FileWrite("test5", writeString, true);
        Assert.Equal(testString, FileOperations.FileRead("test5", false));
    }

    [Fact]
    public void TestFileReadFail()
    {
        Assert.Equal("-1", FileOperations.FileRead("test1f", false));
    }

    [Fact]
    public void TestFileAppendFail()
    {
        string appendString = "TEXT STRING5";
        Assert.Equal(fail, FileOperations.FileAppend("test2f", appendString));
    }

    [Fact]
    public void TestFileEditFail()
    {
        string editString = "TEXT STRING EDIT";
        Assert.Equal(fail, FileOperations.FileEdit("test3f", 3, editString));
    }

    [Fact]
    public void TestFileEditFail_2()
    {
        string editString = "TEXT STRING EDIT";
        Assert.Equal(fail, FileOperations.FileEdit("test3", 100, editString));
    }

    [Fact]
    public void TestFileDeleteFail()
    {
        Assert.Equal(fail, FileOperations.FileLineDelete("test4f", 2));
    }

    [Fact]
    public void TestFileDeleteFail_2()
    {
        Assert.Equal(fail, FileOperations.FileLineDelete("test4", 100));
    }
}
}
