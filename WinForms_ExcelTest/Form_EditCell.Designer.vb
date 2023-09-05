<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_EditCell
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
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

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        NumericUpDown_RowN = New NumericUpDown()
        Label1 = New Label()
        TextBox_Row = New TextBox()
        Label2 = New Label()
        Button_Left = New Button()
        Button_Right = New Button()
        TextBox_Column = New TextBox()
        RichTextBox_Value = New RichTextBox()
        Button_Save = New Button()
        Button_Cancel = New Button()
        Button_Exit = New Button()
        CType(NumericUpDown_RowN, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' NumericUpDown_RowN
        ' 
        NumericUpDown_RowN.Location = New Point(128, 12)
        NumericUpDown_RowN.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
        NumericUpDown_RowN.Name = "NumericUpDown_RowN"
        NumericUpDown_RowN.Size = New Size(138, 23)
        NumericUpDown_RowN.TabIndex = 0
        NumericUpDown_RowN.Value = New Decimal(New Integer() {3, 0, 0, 0})
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(36, 14)
        Label1.Name = "Label1"
        Label1.Size = New Size(86, 15)
        Label1.TabIndex = 1
        Label1.Text = "Номер строки"
        ' 
        ' TextBox_Row
        ' 
        TextBox_Row.Location = New Point(295, 11)
        TextBox_Row.Name = "TextBox_Row"
        TextBox_Row.Size = New Size(458, 23)
        TextBox_Row.TabIndex = 2
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(36, 112)
        Label2.Name = "Label2"
        Label2.Size = New Size(179, 21)
        Label2.TabIndex = 3
        Label2.Text = "Наименования столбца"
        ' 
        ' Button_Left
        ' 
        Button_Left.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        Button_Left.Location = New Point(484, 95)
        Button_Left.Name = "Button_Left"
        Button_Left.Size = New Size(47, 46)
        Button_Left.TabIndex = 4
        Button_Left.Text = "<-"
        Button_Left.UseVisualStyleBackColor = True
        ' 
        ' Button_Right
        ' 
        Button_Right.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        Button_Right.Location = New Point(537, 95)
        Button_Right.Name = "Button_Right"
        Button_Right.Size = New Size(47, 46)
        Button_Right.TabIndex = 5
        Button_Right.Text = "->"
        Button_Right.UseVisualStyleBackColor = True
        ' 
        ' TextBox_Column
        ' 
        TextBox_Column.Location = New Point(241, 110)
        TextBox_Column.Name = "TextBox_Column"
        TextBox_Column.Size = New Size(237, 23)
        TextBox_Column.TabIndex = 6
        ' 
        ' RichTextBox_Value
        ' 
        RichTextBox_Value.Location = New Point(52, 187)
        RichTextBox_Value.Name = "RichTextBox_Value"
        RichTextBox_Value.Size = New Size(334, 96)
        RichTextBox_Value.TabIndex = 7
        RichTextBox_Value.Text = ""
        ' 
        ' Button_Save
        ' 
        Button_Save.Location = New Point(52, 349)
        Button_Save.Name = "Button_Save"
        Button_Save.Size = New Size(98, 44)
        Button_Save.TabIndex = 8
        Button_Save.Text = "Сохранение"
        Button_Save.UseVisualStyleBackColor = True
        ' 
        ' Button_Cancel
        ' 
        Button_Cancel.Location = New Point(204, 349)
        Button_Cancel.Name = "Button_Cancel"
        Button_Cancel.Size = New Size(98, 44)
        Button_Cancel.TabIndex = 9
        Button_Cancel.Text = "Отмена"
        Button_Cancel.UseVisualStyleBackColor = True
        ' 
        ' Button_Exit
        ' 
        Button_Exit.Location = New Point(351, 349)
        Button_Exit.Name = "Button_Exit"
        Button_Exit.Size = New Size(98, 44)
        Button_Exit.TabIndex = 10
        Button_Exit.Text = "Выход"
        Button_Exit.UseVisualStyleBackColor = True
        ' 
        ' Form_EditCell
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Button_Exit)
        Controls.Add(Button_Cancel)
        Controls.Add(Button_Save)
        Controls.Add(RichTextBox_Value)
        Controls.Add(TextBox_Column)
        Controls.Add(Button_Right)
        Controls.Add(Button_Left)
        Controls.Add(Label2)
        Controls.Add(TextBox_Row)
        Controls.Add(Label1)
        Controls.Add(NumericUpDown_RowN)
        Name = "Form_EditCell"
        Text = "Form_EditCell"
        CType(NumericUpDown_RowN, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents NumericUpDown_RowN As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox_Row As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Button_Left As Button
    Friend WithEvents Button_Right As Button
    Friend WithEvents TextBox_Column As TextBox
    Friend WithEvents RichTextBox_Value As RichTextBox
    Friend WithEvents Button_Save As Button
    Friend WithEvents Button_Cancel As Button
    Friend WithEvents Button_Exit As Button
End Class
