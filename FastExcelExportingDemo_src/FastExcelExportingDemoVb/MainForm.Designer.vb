<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.startDemoButton = New System.Windows.Forms.Button
        Me.demoResultListBox = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'startDemoButton
        '
        Me.startDemoButton.Location = New System.Drawing.Point(12, 12)
        Me.startDemoButton.Name = "startDemoButton"
        Me.startDemoButton.Size = New System.Drawing.Size(422, 23)
        Me.startDemoButton.TabIndex = 1
        Me.startDemoButton.Text = "Start DEMO"
        Me.startDemoButton.UseVisualStyleBackColor = True
        '
        'demoResultListBox
        '
        Me.demoResultListBox.FormattingEnabled = True
        Me.demoResultListBox.Location = New System.Drawing.Point(12, 41)
        Me.demoResultListBox.Name = "demoResultListBox"
        Me.demoResultListBox.Size = New System.Drawing.Size(422, 251)
        Me.demoResultListBox.TabIndex = 2
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(446, 303)
        Me.Controls.Add(Me.demoResultListBox)
        Me.Controls.Add(Me.startDemoButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MainForm"
        Me.Text = "FastExcelExport DEMO VB.NET"
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents demoResultListBox As System.Windows.Forms.ListBox
    Private WithEvents startDemoButton As System.Windows.Forms.Button

End Class
