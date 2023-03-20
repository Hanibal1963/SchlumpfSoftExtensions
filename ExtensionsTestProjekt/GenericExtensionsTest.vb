


Imports ExtensionsTestProjekt.Extensions

<TestClass()>
Public Class GenericExtensionsTest


	<TestMethod()>
	Public Sub TestMethod1()


		Dim Test(50) As Integer

		Debug.Print(CStr(Test.Length))

		Test = Test.Resize(3)

		Debug.Print(CStr(Test.Length))

	End Sub


End Class