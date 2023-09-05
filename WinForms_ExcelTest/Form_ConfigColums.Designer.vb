<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_ConfigColums
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
        Label1 = New Label()
        NumericUpDown_RowN = New NumericUpDown()
        TextBox_Row = New TextBox()
        Button_Exit = New Button()
        Button_Cancel = New Button()
        Button_Save = New Button()
        ListBox_Columns = New ListBox()
        DataGridView1 = New DataGridView()
        Button_Right = New Button()
        Button_Left = New Button()
        Column1 = New DataGridViewTextBoxColumn()
        Column2 = New DataGridViewTextBoxColumn()
        Column3 = New DataGridViewTextBoxColumn()
        CType(NumericUpDown_RowN, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(27, 27)
        Label1.Name = "Label1"
        Label1.Size = New Size(86, 15)
        Label1.TabIndex = 0
        Label1.Text = "Номер строки"
        ' 
        ' NumericUpDown_RowN
        ' 
        NumericUpDown_RowN.Location = New Point(130, 25)
        NumericUpDown_RowN.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
        NumericUpDown_RowN.Name = "NumericUpDown_RowN"
        NumericUpDown_RowN.Size = New Size(120, 23)
        NumericUpDown_RowN.TabIndex = 1
        NumericUpDown_RowN.Value = New Decimal(New Integer() {3, 0, 0, 0})
        ' 
        ' TextBox_Row
        ' 
        TextBox_Row.Location = New Point(269, 24)
        TextBox_Row.Name = "TextBox_Row"
        TextBox_Row.Size = New Size(469, 23)
        TextBox_Row.TabIndex = 2
        ' 
        ' Button_Exit
        ' 
        Button_Exit.Location = New Point(377, 354)
        Button_Exit.Name = "Button_Exit"
        Button_Exit.Size = New Size(98, 44)
        Button_Exit.TabIndex = 13
        Button_Exit.Text = "Выход"
        Button_Exit.UseVisualStyleBackColor = True
        ' 
        ' Button_Cancel
        ' 
        Button_Cancel.Location = New Point(230, 354)
        Button_Cancel.Name = "Button_Cancel"
        Button_Cancel.Size = New Size(98, 44)
        Button_Cancel.TabIndex = 12
        Button_Cancel.Text = "Отмена"
        Button_Cancel.UseVisualStyleBackColor = True
        ' 
        ' Button_Save
        ' 
        Button_Save.Location = New Point(78, 354)
        Button_Save.Name = "Button_Save"
        Button_Save.Size = New Size(98, 44)
        Button_Save.TabIndex = 11
        Button_Save.Text = "Сохранение"
        Button_Save.UseVisualStyleBackColor = True
        ' 
        ' ListBox_Columns
        ' 
        ListBox_Columns.FormattingEnabled = True
        ListBox_Columns.ItemHeight = 15
        ListBox_Columns.Location = New Point(27, 64)
        ListBox_Columns.Name = "ListBox_Columns"
        ListBox_Columns.Size = New Size(246, 259)
        ListBox_Columns.TabIndex = 14
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {Column1, Column2, Column3})
        DataGridView1.Location = New Point(441, 64)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowTemplate.Height = 25
        DataGridView1.Size = New Size(506, 259)
        DataGridView1.TabIndex = 17
        ' 
        ' Button_Right
        ' 
        Button_Right.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        Button_Right.Location = New Point(310, 110)
        Button_Right.Name = "Button_Right"
        Button_Right.Size = New Size(47, 46)
        Button_Right.TabIndex = 18
        Button_Right.Text = "->"
        Button_Right.UseVisualStyleBackColor = True
        ' 
        ' Button_Left
        ' 
        Button_Left.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        Button_Left.Location = New Point(310, 177)
        Button_Left.Name = "Button_Left"
        Button_Left.Size = New Size(47, 46)
        Button_Left.TabIndex = 19
        Button_Left.Text = "<-"
        Button_Left.UseVisualStyleBackColor = True
        ' 
        ' Column1
        ' 
        Column1.HeaderText = "Index"
        Column1.Name = "Column1"
        Column1.ReadOnly = True
        ' 
        ' Column2
        ' 
        Column2.HeaderText = "Column_Name"
        Column2.Name = "Column2"
        Column2.ReadOnly = True
        ' 
        ' Column3
        ' 
        Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Column3.HeaderText = "Value"
        Column3.Name = "Column3"
        ' 
        ' Form_ConfigColums
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1005, 492)
        Controls.Add(Button_Left)
        Controls.Add(Button_Right)
        Controls.Add(DataGridView1)
        Controls.Add(ListBox_Columns)
        Controls.Add(Button_Exit)
        Controls.Add(Button_Cancel)
        Controls.Add(Button_Save)
        Controls.Add(TextBox_Row)
        Controls.Add(NumericUpDown_RowN)
        Controls.Add(Label1)
        Name = "Form_ConfigColums"
        Text = "Form_ConfigColums"
        CType(NumericUpDown_RowN, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents NumericUpDown_RowN As NumericUpDown
    Friend WithEvents TextBox_Row As TextBox
    Friend WithEvents Button_Exit As Button
    Friend WithEvents Button_Cancel As Button
    Friend WithEvents Button_Save As Button
    Friend WithEvents ListBox_Columns As ListBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button_Right As Button
    Friend WithEvents Button_Left As Button
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
End Class
