<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTable
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
        Me.hash_tb = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'hash_tb
        '
        Me.hash_tb.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.hash_tb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.hash_tb.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.hash_tb.Location = New System.Drawing.Point(0, 0)
        Me.hash_tb.Multiline = True
        Me.hash_tb.Name = "hash_tb"
        Me.hash_tb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.hash_tb.Size = New System.Drawing.Size(390, 509)
        Me.hash_tb.TabIndex = 0
        '
        'frmTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(390, 509)
        Me.Controls.Add(Me.hash_tb)
        Me.Name = "frmTable"
        Me.Text = "Hash Table"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents hash_tb As System.Windows.Forms.TextBox
End Class
