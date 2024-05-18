using FitnessLibrary;

namespace FitnessLibrary.Tests {
public class FitnessTests {

    [Fact]
    public void TestFileRead()
    {
        string testString = "1-)TEXT STRING1\n2-)TEXT STRING2\n3-)TEXT STRING3\n4-)TEXT STRING4\n5-)TEXT STRING5\n";
        Assert.Equal(testString, Fitness.FileRead("test1", false));
    }

    [Fact]
    public void TestFileAppend()
    {
        string testString = "1-)TEXT STRING1\n2-)TEXT STRING2\n3-)TEXT STRING3\n4-)TEXT STRING4\n5-)TEXT STRING5\n6-)TEXT STRING6\n";
        string appendString = "TEXT STRING6";
        Fitness.FileAppend("test2", appendString);
        Assert.Equal(testString, Fitness.FileRead("test2", false));
    }

    [Fact]
    public void TestFileEdit()
    {
        string testString = "1-)TEXT STRING1\n2-)TEXT STRING2\n3-)TEXT STRING EDIT\n4-)TEXT STRING4\n5-)TEXT STRING5\n";
        string editString = "TEXT STRING EDIT";
        Fitness.FileEdit("test3", 3, editString);
        Assert.Equal(testString, Fitness.FileRead("test3", false));
    }

    [Fact]
    public void TestFileDelete()
    {
        string testString = "1-)TEXT STRING2\n2-)TEXT STRING3\n3-)TEXT STRING4\n4-)TEXT STRING5\n";
        Fitness.FileLineDelete("test4", 1);
        Assert.Equal(testString, Fitness.FileRead("test4", false));
    }

    [Fact]
    public void TestFileWrite()
    {
        string testString = "1-)TEXT STRING WRITE\n";
        string writeString = "TEXT STRING WRITE";
        Fitness.FileWrite("test5", writeString, true);
        Assert.Equal(testString, Fitness.FileRead("test5", false));
    }

    [Fact]
    public void TestFileReadFail()
    {
        Assert.Equal("-1", Fitness.FileRead("test1f", false));
    }

    [Fact]
    public void TestFileAppendFail()
    {
        string appendString = "TEXT STRING5";
        Assert.Equal(-1, Fitness.FileAppend("test2f", appendString));
    }

    [Fact]
    public void TestFileEditFail()
    {
        string editString = "TEXT STRING EDIT";
        Assert.Equal(-1, Fitness.FileEdit("test3f", 3, editString));
    }

    [Fact]
    public void TestFileEditFail_2()
    {
        string editString = "TEXT STRING EDIT";
        Assert.Equal(-1, Fitness.FileEdit("test3", 100, editString));
    }

    [Fact]
    public void TestFileDeleteFail()
    {
        Assert.Equal(-1, Fitness.FileLineDelete("test4f", 2));
    }

    [Fact]
    public void TestFileDeleteFail_2()
    {
        Assert.Equal(-1, Fitness.FileLineDelete("test4", 100));
    }
    [Fact]
    public void TestUserRegister()
    {
        string testString = "249ba36000029bbe97499c03db5a9001f6b734ec/5baa61e4c9b93f3f0682250b6cf8331b7ee68fd8/29773a093e4c80375be4dd8738f4c6afb993b319";
        Fitness.UserRegister("username", "password", "recoverykey", "usertest");
        Assert.Equal(testString, Fitness.FileRead("usertest", false));
    }

    [Fact]
    public void TestUserChangePassword()
    {
        string testString = "249ba36000029bbe97499c03db5a9001f6b734ec/f2c57870308dc87f432e5912d4de6f8e322721ba/29773a093e4c80375be4dd8738f4c6afb993b319";
        Fitness.UserChangePassword("recoverykey", "newpassword", "usertest2");
        Assert.Equal(testString, Fitness.FileRead("usertest2", false));
    }

    [Fact]
    public void TestUserChangePasswordFail()
    {
       Assert.Equal(-1 , Fitness.UserChangePassword("recoverykey", "newpassword", "usertestttt"));
    }

    [Fact]
    public void TestUserChangePasswordFail_2()
    {
        Assert.Equal(-1 , Fitness.UserChangePassword("recoverykeyaa", "newpassword", "usertest2"));
    }

    [Fact]
    public void TestUserLogin()
    {
        Assert.Equal(0, Fitness.UserLogin("username", "password", "usertest3"));
    }

    [Fact]
    public void TestUserLoginFail()
    {
        Assert.Equal(-1, Fitness.UserLogin("username", "passwordaa", "usertest3"));
    }

    [Fact]
    public void TestUserLoginFail_2()
    {
        Assert.Equal(-1, Fitness.UserLogin("usernameaa", "password", "usertest3"));
    }

    [Fact]
    public void TestUserLoginFail_3()
    {
        Assert.Equal(-1, Fitness.UserLogin("username", "password", "usertestttt"));
    }
    [Fact]
    public void TestSHA1()
    {
        string testString = "TEST STRING";
        string testString2 = "TEST STRING";
        Assert.Equal(Sha.Sha1(testString), Sha.Sha1(testString2));
    }

    [Fact]
    public void TestSHA1Fail()
    {
        string testString = "TEST STRING";
        string testString2 = "test string";
        Assert.NotEqual(Sha.Sha1(testString), Sha.Sha1(testString2));
    }

    [Fact]
    public void TestLCS_Success()
    {
        string testString = "3-)TEXT STRING3";
        Assert.Equal(0, Fitness.CheckLCS(testString, "test1"));
    }

    [Fact]
    public void TestLCS_Fail()
    {
        string testString = "TEXT";
        Assert.Equal(-1, Fitness.CheckLCS(testString, "test1"));
    }

    /// <summary>
    /// Tests the login menu functionality.
    /// </summary>
    [Fact]
    public void TestLoginMenu()
    {
        // Redirect stdout to a file
        using (var outputWriter = new StreamWriter("login_menu_output_test.bin"))
        {
            Console.SetOut(outputWriter);

            // Redirect stdin from a file
            using (var inputReader = new StreamReader("login_menu_input_test.bin"))
            {
                Console.SetIn(inputReader);

                // Call the method to test
                Fitness.LoginMenu(true);
            }

            outputWriter.Flush();
        }

        // Reset stdout and stdin
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        Console.SetIn(new StreamReader(Console.OpenStandardInput()));

        // Read the expected and actual output files
        var expectedOutput = Fitness.FileReadForTest("login_menu_expected_output");
        var actualOutput = Fitness.FileReadForTest("login_menu_output_test");

        // Assert that the outputs are equal
        Assert.Equal(expectedOutput, actualOutput);
    }

    /// <summary>
    /// Tests the register menu functionality.
    /// </summary>
    [Fact]
    public void TestRegisterMenu()
    {
        // Redirect stdout to a file
        using (var outputWriter = new StreamWriter("register_menu_output_test.bin"))
        {
            Console.SetOut(outputWriter);

            // Redirect stdin from a file
            using (var inputReader = new StreamReader("register_menu_input_test.bin"))
            {
                Console.SetIn(inputReader);

                // Call the method to test
                Fitness.RegisterMenu();
            }

            outputWriter.Flush();
        }

        // Reset stdout and stdin
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        Console.SetIn(new StreamReader(Console.OpenStandardInput()));

        // Read the expected and actual output files
        var expectedOutput = Fitness.FileReadForTest("register_menu_expected_output");
        var actualOutput = Fitness.FileReadForTest("register_menu_output_test");

        // Assert that the outputs are equal
        Assert.Equal(expectedOutput, actualOutput);
    }

     /// <summary>
    /// Tests the change password menu functionality.
    /// </summary>
    [Fact]
    public void TestChangePasswordMenu()
    {
        // Redirect stdout to a file
        using (var outputWriter = new StreamWriter("password_menu_output_test.bin"))
        {
            Console.SetOut(outputWriter);

            // Redirect stdin from a file
            using (var inputReader = new StreamReader("password_menu_input_test.bin"))
            {
                Console.SetIn(inputReader);

                // Call the method to test
                Fitness.ChangePasswordMenu();
            }

            outputWriter.Flush();
        }

        // Reset stdout and stdin
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        Console.SetIn(new StreamReader(Console.OpenStandardInput()));

        // Read the expected and actual output files
        var expectedOutput = Fitness.FileReadForTest("password_menu_expected_output");
        var actualOutput = Fitness.FileReadForTest("password_menu_output_test");

        // Assert that the outputs are equal
        Assert.Equal(expectedOutput, actualOutput);
    }

    /// <summary>
    /// Tests the guest mode functionality.
    /// </summary>
    [Fact]
    public void TestGuestMode()
    {
        // Redirect stdout to a file
        using (var outputWriter = new StreamWriter("guest_menu_output_test.bin"))
        {
            Console.SetOut(outputWriter);

            // Redirect stdin from a file
            using (var inputReader = new StreamReader("guest_menu_input_test.bin"))
            {
                Console.SetIn(inputReader);

                // Call the method to test
                Fitness.MainMenu(true);
            }

            outputWriter.Flush();
        }

        // Reset stdout and stdin
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        Console.SetIn(new StreamReader(Console.OpenStandardInput()));

        // Read the expected and actual output files
        var expectedOutput = Fitness.FileReadForTest("guest_menu_expected_output");
        var actualOutput = Fitness.FileReadForTest("guest_menu_output_test");

        // Assert that the outputs are equal
        Assert.Equal(expectedOutput, actualOutput);
    }
    /// <summary>
    /// Tests the main app menu functionality.
    /// </summary>
    [Fact]
    public void TestMainApp()
    {
        // Redirect stdout to a file
        using (var outputWriter = new StreamWriter("mainapp_menu_output_test.bin"))
        {
            Console.SetOut(outputWriter);

            // Redirect stdin from a file
            using (var inputReader = new StreamReader("mainapp_menu_input_test.bin"))
            {
                Console.SetIn(inputReader);
                Fitness fitness = new Fitness();
                // Call the method to test
                fitness.mainApp();
            }

            outputWriter.Flush();
        }

        // Reset stdout and stdin
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        Console.SetIn(new StreamReader(Console.OpenStandardInput()));

        // Read the expected and actual output files
        var expectedOutput = Fitness.FileReadForTest("mainapp_menu_expected_output");
        var actualOutput = Fitness.FileReadForTest("mainapp_menu_output_test");

        // Assert that the outputs are equal
        Assert.Equal(expectedOutput, actualOutput);
    }
    /// <summary>
    /// Tests the member menu functionality.
    /// </summary>
    [Fact]
    public void TestMemberMenu()
    {
        // Save the original stdout and stdin
        var originalOut = Console.Out;
        var originalIn = Console.In;

        try
        {
            // Redirect stdout to a file
            using (var outputWriter = new StreamWriter("member_menu_output_test.bin"))
            {
                Console.SetOut(outputWriter);

                // Redirect stdin from a file
                using (var inputReader = new StreamReader("member_menu_input_test.bin"))
                {
                    Console.SetIn(inputReader);

                    // Call the method to test
                    Fitness.MemberMenu(false);
                }

                outputWriter.Flush();
            }

            // Reset stdout and stdin
            Console.SetOut(originalOut);
            Console.SetIn(originalIn);

            // Read the expected and actual output files
            var expectedOutput = Fitness.FileReadForTest("member_menu_expected_output");
            var actualOutput = Fitness.FileReadForTest("member_menu_output_test");

            // Assert that the outputs are equal
            Assert.Equal(expectedOutput, actualOutput);
        }
        finally
        {
            // Reset stdout and stdin in case of an exception
            Console.SetOut(originalOut);
            Console.SetIn(originalIn);
        }
    }
    /// <summary>
    /// Tests the subs menu functionality.
    /// </summary>
    [Fact]
    public void TestSubsMenu()
    {
        // Save the original stdout and stdin
        var originalOut = Console.Out;
        var originalIn = Console.In;

        try
        {
            // Redirect stdout to a file
            using (var outputWriter = new StreamWriter("subs_menu_output_test.bin"))
            {
                Console.SetOut(outputWriter);

                // Redirect stdin from a file
                using (var inputReader = new StreamReader("subs_menu_input_test.bin"))
                {
                    Console.SetIn(inputReader);

                    // Call the method to test
                    Fitness.SubsMenu(false);
                }

                outputWriter.Flush();
            }

            // Reset stdout and stdin
            Console.SetOut(originalOut);
            Console.SetIn(originalIn);

            // Read the expected and actual output files
            var expectedOutput = Fitness.FileReadForTest("subs_menu_expected_output");
            var actualOutput = Fitness.FileReadForTest("subs_menu_output_test");

            // Assert that the outputs are equal
            Assert.Equal(expectedOutput, actualOutput);
        }
        finally
        {
            // Reset stdout and stdin in case of an exception
            Console.SetOut(originalOut);
            Console.SetIn(originalIn);
        }
    }

    /// <summary>
    /// Tests the class menu functionality.
    /// </summary>
    [Fact]
    public void TestClassMenu()
    {
        // Save the original stdout and stdin
        var originalOut = Console.Out;
        var originalIn = Console.In;

        try
        {
            // Redirect stdout to a file
            using (var outputWriter = new StreamWriter("class_menu_output_test.bin"))
            {
                Console.SetOut(outputWriter);

                // Redirect stdin from a file
                using (var inputReader = new StreamReader("class_menu_input_test.bin"))
                {
                    Console.SetIn(inputReader);

                    // Call the method to test
                    Fitness.ClassMenu(false);
                }

                outputWriter.Flush();
            }

            // Reset stdout and stdin
            Console.SetOut(originalOut);
            Console.SetIn(originalIn);

            // Read the expected and actual output files
            var expectedOutput = Fitness.FileReadForTest("class_menu_expected_output");
            var actualOutput = Fitness.FileReadForTest("class_menu_output_test");

            // Assert that the outputs are equal
            Assert.Equal(expectedOutput, actualOutput);
        }
        finally
        {
            // Reset stdout and stdin in case of an exception
            Console.SetOut(originalOut);
            Console.SetIn(originalIn);
        }
    }
            /// <summary>
    /// Tests the class menu functionality.
    /// </summary>
    [Fact]
    public void TestPaymentMenu()
    {
        // Save the original stdout and stdin
        var originalOut = Console.Out;
        var originalIn = Console.In;

        try
        {
            // Redirect stdout to a file
            using (var outputWriter = new StreamWriter("payment_menu_output_test.bin"))
            {
                Console.SetOut(outputWriter);

                // Redirect stdin from a file
                using (var inputReader = new StreamReader("payment_menu_input_test.bin"))
                {
                    Console.SetIn(inputReader);

                    // Call the method to test
                    Fitness.PaymentMenu(false);
                }

                outputWriter.Flush();
            }

            // Reset stdout and stdin
            Console.SetOut(originalOut);
            Console.SetIn(originalIn);

            // Read the expected and actual output files
            var expectedOutput = Fitness.FileReadForTest("payment_menu_expected_output");
            var actualOutput = Fitness.FileReadForTest("payment_menu_output_test");

            // Assert that the outputs are equal
            Assert.Equal(expectedOutput, actualOutput);
        }
        finally
        {
            // Reset stdout and stdin in case of an exception
            Console.SetOut(originalOut);
            Console.SetIn(originalIn);
        }
    }
}
}
