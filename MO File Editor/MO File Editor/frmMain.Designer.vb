<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.MM = New System.Windows.Forms.MenuStrip()
        Me.file = New System.Windows.Forms.ToolStripMenuItem()
        Me.m_open = New System.Windows.Forms.ToolStripMenuItem()
        Me.m_save = New System.Windows.Forms.ToolStripMenuItem()
        Me.m_show_strings = New System.Windows.Forms.ToolStripMenuItem()
        Me.m_hash = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFile = New System.Windows.Forms.SaveFileDialog()
        Me.results_tb = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.search_tb = New System.Windows.Forms.TextBox()
        Me.new_name_tb = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.replace_bt = New System.Windows.Forms.Button()
        Me.MM.SuspendLayout()
        Me.SuspendLayout()
        '
        'MM
        '
        Me.MM.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.file, Me.m_show_strings, Me.m_hash})
        Me.MM.Location = New System.Drawing.Point(0, 0)
        Me.MM.Name = "MM"
        Me.MM.Size = New System.Drawing.Size(390, 24)
        Me.MM.TabIndex = 0
        Me.MM.Text = "MM"
        '
        'file
        '
        Me.file.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.m_open, Me.m_save})
        Me.file.Name = "file"
        Me.file.Size = New System.Drawing.Size(37, 20)
        Me.file.Text = "File"
        '
        'm_open
        '
        Me.m_open.Name = "m_open"
        Me.m_open.Size = New System.Drawing.Size(103, 22)
        Me.m_open.Text = "Open"
        '
        'm_save
        '
        Me.m_save.Enabled = False
        Me.m_save.Name = "m_save"
        Me.m_save.Size = New System.Drawing.Size(103, 22)
        Me.m_save.Text = "Save"
        '
        'm_show_strings
        '
        Me.m_show_strings.Enabled = False
        Me.m_show_strings.Name = "m_show_strings"
        Me.m_show_strings.Size = New System.Drawing.Size(87, 20)
        Me.m_show_strings.Text = "Show Strings"
        '
        'm_hash
        '
        Me.m_hash.Enabled = False
        Me.m_hash.Name = "m_hash"
        Me.m_hash.Size = New System.Drawing.Size(78, 20)
        Me.m_hash.Text = "Show Hash"
        Me.m_hash.Visible = False
        '
        'OpenFile
        '
        Me.OpenFile.Filter = "MO files (*.mo)|*.mo|MP Back Up (*mo_BU)|*.mo_BU"
        Me.OpenFile.Title = "Open MO file"
        '
        'SaveFile
        '
        Me.SaveFile.Filter = "MO files (*.mo)|*.mo"
        Me.SaveFile.Title = "Save MO file"
        '
        'results_tb
        '
        Me.results_tb.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.results_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.results_tb.ForeColor = System.Drawing.Color.White
        Me.results_tb.Location = New System.Drawing.Point(12, 104)
        Me.results_tb.Multiline = True
        Me.results_tb.Name = "results_tb"
        Me.results_tb.Size = New System.Drawing.Size(366, 20)
        Me.results_tb.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Find Old Name"
        '
        'search_tb
        '
        Me.search_tb.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.search_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.search_tb.ForeColor = System.Drawing.Color.White
        Me.search_tb.Location = New System.Drawing.Point(15, 41)
        Me.search_tb.Name = "search_tb"
        Me.search_tb.Size = New System.Drawing.Size(161, 20)
        Me.search_tb.TabIndex = 3
        '
        'new_name_tb
        '
        Me.new_name_tb.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.new_name_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.new_name_tb.ForeColor = System.Drawing.Color.White
        Me.new_name_tb.Location = New System.Drawing.Point(210, 41)
        Me.new_name_tb.Name = "new_name_tb"
        Me.new_name_tb.Size = New System.Drawing.Size(168, 20)
        Me.new_name_tb.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(207, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "New Name"
        '
        'replace_bt
        '
        Me.replace_bt.ForeColor = System.Drawing.Color.Black
        Me.replace_bt.Location = New System.Drawing.Point(303, 67)
        Me.replace_bt.Name = "replace_bt"
        Me.replace_bt.Size = New System.Drawing.Size(75, 23)
        Me.replace_bt.TabIndex = 6
        Me.replace_bt.Text = "Replace..."
        Me.replace_bt.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(390, 141)
        Me.Controls.Add(Me.replace_bt)
        Me.Controls.Add(Me.new_name_tb)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.search_tb)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.results_tb)
        Me.Controls.Add(Me.MM)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MM
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MO Editor"
        Me.MM.ResumeLayout(False)
        Me.MM.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MM As System.Windows.Forms.MenuStrip
    Friend WithEvents file As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents m_open As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents m_save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFile As System.Windows.Forms.SaveFileDialog
    Friend WithEvents results_tb As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents search_tb As System.Windows.Forms.TextBox
    Friend WithEvents new_name_tb As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents replace_bt As System.Windows.Forms.Button
    Friend WithEvents m_show_strings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents m_hash As System.Windows.Forms.ToolStripMenuItem

End Class
