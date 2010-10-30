Option Strict On
Option Explicit On

Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports AddressStandardizationSolution
' .NET Framework 2.0 needs this for dictionaries.
Imports System.Collections.Generic

''' <summary>
''' Tests properties in the AddressStandardizationSolution class
''' </summary>
<TestClass()> _
Public Class PropertiesTest
	''' <summary>
	''' The AddressStandardizationSolution object to run the tests against
	''' </summary>
	Protected a As AddressStandardizationSolution.AddressStandardizationSolution = New AddressStandardizationSolution.AddressStandardizationSolution

	Private testContextInstance As TestContext

	''' <summary>
	''' Gets or sets the test context which provides
	''' information about and functionality for the current test run.
	''' </summary>
	Public Property TestContext() As TestContext
		Get
			Return testContextInstance
		End Get
		Set(ByVal value As TestContext)
			testContextInstance = value
		End Set
	End Property

	''' <summary>
	''' Helper function that examines the given properties
	''' </summary>
	''' <param name="prop">the array to test</param>
	''' <returns>void</returns>
	Protected Sub t(ByVal prop As Dictionary(Of String, String))
		Dim value As String
		For Each key As String In prop.Keys()
			value = prop(key)
			If Right(key, 2) = "-R" Then
				Assert.IsTrue(prop.ContainsKey(value), "value of reverse key " & key & " is missing")
				Assert.AreEqual(prop(value), key.Substring(0, key.Length - 2), "mapping back of " & key & " does not match " & value)
			Else
				Assert.IsTrue(prop.ContainsKey(value & "-R"), "value of " & key & " should map to a reverse key")
			End If
		Next
	End Sub

	<TestMethod()> _
	Public Sub testDirectionalsReverseLookup()
		t(a.directionals)
	End Sub

	<TestMethod()> _
	Public Sub testIdentifiersReverseLookup()
		t(a.identifiers)
	End Sub

	<TestMethod()> _
	Public Sub testSuffixesReverseLookup()
		t(a.suffixes)
	End Sub
End Class
