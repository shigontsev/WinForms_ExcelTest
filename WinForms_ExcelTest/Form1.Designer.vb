<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        TextBox1 = New TextBox()
        Button1 = New Button()
        Button_OpenConfigColums = New Button()
        Button2 = New Button()
        Button_Edit = New Button()
        Label1 = New Label()
        SuspendLayout()
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(71, 94)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(393, 23)
        TextBox1.TabIndex = 0
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(71, 138)
        Button1.Name = "Button1"
        Button1.Size = New Size(109, 39)
        Button1.TabIndex = 1
        Button1.Text = "ChooseExcelFile"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button_OpenConfigColums
        ' 
        Button_OpenConfigColums.Location = New Point(71, 245)
        Button_OpenConfigColums.Name = "Button_OpenConfigColums"
        Button_OpenConfigColums.Size = New Size(109, 51)
        Button_OpenConfigColums.TabIndex = 2
        Button_OpenConfigColums.Text = "ConfigColums"
        Button_OpenConfigColums.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(418, 259)
        Button2.Name = "Button2"
        Button2.Size = New Size(75, 23)
        Button2.TabIndex = 3
        Button2.Text = "Button2"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button_Edit
        ' 
        Button_Edit.Location = New Point(226, 245)
        Button_Edit.Name = "Button_Edit"
        Button_Edit.Size = New Size(109, 51)
        Button_Edit.TabIndex = 4
        Button_Edit.Text = "Редактирование"
        Button_Edit.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(71, 53)
        Label1.Name = "Label1"
        Label1.Size = New Size(169, 25)
        Label1.TabIndex = 5
        Label1.Text = "Path к Excel файлу"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Label1)
        Controls.Add(Button_Edit)
        Controls.Add(Button2)
        Controls.Add(Button_OpenConfigColums)
        Controls.Add(Button1)
        Controls.Add(TextBox1)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button_OpenConfigColums As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button_Edit As Button
    Friend WithEvents Label1 As Label
End Class
