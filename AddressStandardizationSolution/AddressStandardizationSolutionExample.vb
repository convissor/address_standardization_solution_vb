Option Strict On
Option Explicit On

''' <summary>
''' An example of how to use the Address Standardization Solution
''' </summary>
Public Class AddressStandardizationSolutionExample
	''' <summary>
	''' Passes the input box value through the Address Line Standardization
	''' method and populates the output box with the result
	''' </summary>
	Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
		Dim address As AddressStandardizationSolution = New AddressStandardizationSolution
		OutputBox.Text = address.AddressLineStandardization(InputBox.Text)
	End Sub
End Class
