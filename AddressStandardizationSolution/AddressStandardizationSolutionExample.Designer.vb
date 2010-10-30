<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddressStandardizationSolutionExample
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.InputBox = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.OutputBox = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'InputBox
        '
        Me.InputBox.Location = New System.Drawing.Point(55, 87)
        Me.InputBox.Name = "InputBox"
        Me.InputBox.Size = New System.Drawing.Size(461, 22)
        Me.InputBox.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(522, 86)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Standardize"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'OutputBox
        '
        Me.OutputBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.OutputBox.Location = New System.Drawing.Point(55, 124)
        Me.OutputBox.Name = "OutputBox"
        Me.OutputBox.Size = New System.Drawing.Size(461, 15)
        Me.OutputBox.TabIndex = 2
        '
        'AddressStandardizationSolutionExample
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(633, 255)
        Me.Controls.Add(Me.OutputBox)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.InputBox)
        Me.Name = "AddressStandardizationSolutionExample"
        Me.Text = "Address Standardization Solution"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents InputBox As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents OutputBox As System.Windows.Forms.TextBox

End Class
