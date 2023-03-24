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
        TB_Search = New TextBox()
        BU_Search = New Button()
        LB_Search_Out = New ListBox()
        BU_Add = New Button()
        LB_HeaderValue = New Label()
        BU_Build = New Button()
        LB_SelectedName = New ListBox()
        LB_SelectedID = New ListBox()
        TB_Filename = New TextBox()
        CB_lnk = New CheckBox()
        LB_Project = New Label()
        BU_Remove = New Button()
        OFD_Manifest = New OpenFileDialog()
        MenuStrip1 = New MenuStrip()
        FileToolStripMenuItem = New ToolStripMenuItem()
        NewToolStripMenuItem = New ToolStripMenuItem()
        OpenToolStripMenuItem = New ToolStripMenuItem()
        ExitToolStripMenuItem = New ToolStripMenuItem()
        Label2 = New Label()
        LB_Manifest = New Label()
        PictureBox1 = New PictureBox()
        MenuStrip1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TB_Search
        ' 
        TB_Search.AcceptsReturn = True
        TB_Search.BorderStyle = BorderStyle.FixedSingle
        TB_Search.Location = New Point(272, 70)
        TB_Search.Name = "TB_Search"
        TB_Search.PlaceholderText = "Search"
        TB_Search.Size = New Size(416, 23)
        TB_Search.TabIndex = 0
        ' 
        ' BU_Search
        ' 
        BU_Search.Location = New Point(426, 99)
        BU_Search.Name = "BU_Search"
        BU_Search.Size = New Size(75, 23)
        BU_Search.TabIndex = 2
        BU_Search.Text = "&Search"
        BU_Search.UseVisualStyleBackColor = True
        ' 
        ' LB_Search_Out
        ' 
        LB_Search_Out.BorderStyle = BorderStyle.FixedSingle
        LB_Search_Out.FormattingEnabled = True
        LB_Search_Out.ItemHeight = 15
        LB_Search_Out.Location = New Point(104, 127)
        LB_Search_Out.Name = "LB_Search_Out"
        LB_Search_Out.Size = New Size(739, 137)
        LB_Search_Out.TabIndex = 3
        LB_Search_Out.Visible = False
        ' 
        ' BU_Add
        ' 
        BU_Add.Location = New Point(849, 241)
        BU_Add.Name = "BU_Add"
        BU_Add.Size = New Size(75, 23)
        BU_Add.TabIndex = 4
        BU_Add.Text = "&Add"
        BU_Add.UseVisualStyleBackColor = True
        BU_Add.Visible = False
        ' 
        ' LB_HeaderValue
        ' 
        LB_HeaderValue.AutoSize = True
        LB_HeaderValue.Location = New Point(12, 574)
        LB_HeaderValue.Name = "LB_HeaderValue"
        LB_HeaderValue.Size = New Size(37, 15)
        LB_HeaderValue.TabIndex = 7
        LB_HeaderValue.Text = "          "
        LB_HeaderValue.Visible = False
        ' 
        ' BU_Build
        ' 
        BU_Build.Location = New Point(725, 541)
        BU_Build.Name = "BU_Build"
        BU_Build.Size = New Size(75, 23)
        BU_Build.TabIndex = 8
        BU_Build.Text = "&Build"
        BU_Build.UseVisualStyleBackColor = True
        BU_Build.Visible = False
        ' 
        ' LB_SelectedName
        ' 
        LB_SelectedName.BackColor = SystemColors.Control
        LB_SelectedName.BorderStyle = BorderStyle.None
        LB_SelectedName.FormattingEnabled = True
        LB_SelectedName.ItemHeight = 15
        LB_SelectedName.Location = New Point(21, 323)
        LB_SelectedName.Name = "LB_SelectedName"
        LB_SelectedName.Size = New Size(592, 180)
        LB_SelectedName.TabIndex = 9
        ' 
        ' LB_SelectedID
        ' 
        LB_SelectedID.BackColor = SystemColors.Control
        LB_SelectedID.BorderStyle = BorderStyle.None
        LB_SelectedID.FormattingEnabled = True
        LB_SelectedID.ItemHeight = 15
        LB_SelectedID.Location = New Point(641, 323)
        LB_SelectedID.Name = "LB_SelectedID"
        LB_SelectedID.SelectionMode = SelectionMode.None
        LB_SelectedID.Size = New Size(202, 180)
        LB_SelectedID.TabIndex = 10
        ' 
        ' TB_Filename
        ' 
        TB_Filename.BorderStyle = BorderStyle.FixedSingle
        TB_Filename.Location = New Point(184, 541)
        TB_Filename.Name = "TB_Filename"
        TB_Filename.Size = New Size(535, 23)
        TB_Filename.TabIndex = 11
        TB_Filename.Visible = False
        ' 
        ' CB_lnk
        ' 
        CB_lnk.AutoSize = True
        CB_lnk.Location = New Point(184, 570)
        CB_lnk.Name = "CB_lnk"
        CB_lnk.Size = New Size(116, 19)
        CB_lnk.TabIndex = 12
        CB_lnk.Text = "Cleanup .lnk files"
        CB_lnk.UseVisualStyleBackColor = True
        CB_lnk.Visible = False
        ' 
        ' LB_Project
        ' 
        LB_Project.AutoSize = True
        LB_Project.Location = New Point(184, 523)
        LB_Project.Name = "LB_Project"
        LB_Project.Size = New Size(79, 15)
        LB_Project.TabIndex = 13
        LB_Project.Text = "Project Name"
        LB_Project.Visible = False
        ' 
        ' BU_Remove
        ' 
        BU_Remove.Location = New Point(849, 480)
        BU_Remove.Name = "BU_Remove"
        BU_Remove.Size = New Size(75, 23)
        BU_Remove.TabIndex = 14
        BU_Remove.Text = "&Remove"
        BU_Remove.UseVisualStyleBackColor = True
        BU_Remove.Visible = False
        ' 
        ' OFD_Manifest
        ' 
        OFD_Manifest.FileName = "*.manifest"
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {FileToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(946, 24)
        MenuStrip1.TabIndex = 17
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' FileToolStripMenuItem
        ' 
        FileToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {NewToolStripMenuItem, OpenToolStripMenuItem, ExitToolStripMenuItem})
        FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        FileToolStripMenuItem.Size = New Size(37, 20)
        FileToolStripMenuItem.Text = "&File"
        ' 
        ' NewToolStripMenuItem
        ' 
        NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        NewToolStripMenuItem.Size = New Size(103, 22)
        NewToolStripMenuItem.Text = "&New"
        ' 
        ' OpenToolStripMenuItem
        ' 
        OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        OpenToolStripMenuItem.Size = New Size(103, 22)
        OpenToolStripMenuItem.Text = "&Open"
        ' 
        ' ExitToolStripMenuItem
        ' 
        ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        ExitToolStripMenuItem.Size = New Size(103, 22)
        ExitToolStripMenuItem.Text = "&Exit"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = SystemColors.Control
        Label2.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.Location = New Point(388, 29)
        Label2.Name = "Label2"
        Label2.Size = New Size(156, 30)
        Label2.TabIndex = 18
        Label2.Text = "Winget Search"
        ' 
        ' LB_Manifest
        ' 
        LB_Manifest.AutoSize = True
        LB_Manifest.Location = New Point(21, 305)
        LB_Manifest.Name = "LB_Manifest"
        LB_Manifest.Size = New Size(162, 15)
        LB_Manifest.TabIndex = 19
        LB_Manifest.Text = "Manifest (Select Items Below)"
        LB_Manifest.Visible = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Location = New Point(0, 62)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(946, 240)
        PictureBox1.TabIndex = 20
        PictureBox1.TabStop = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(946, 597)
        Controls.Add(LB_Manifest)
        Controls.Add(Label2)
        Controls.Add(BU_Remove)
        Controls.Add(LB_Project)
        Controls.Add(CB_lnk)
        Controls.Add(TB_Filename)
        Controls.Add(LB_SelectedID)
        Controls.Add(LB_SelectedName)
        Controls.Add(BU_Build)
        Controls.Add(LB_HeaderValue)
        Controls.Add(BU_Add)
        Controls.Add(LB_Search_Out)
        Controls.Add(BU_Search)
        Controls.Add(TB_Search)
        Controls.Add(MenuStrip1)
        Controls.Add(PictureBox1)
        MaximizeBox = False
        MaximumSize = New Size(962, 636)
        MinimumSize = New Size(962, 636)
        Name = "Form1"
        Text = "Winget GUI"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents TB_Search As TextBox
    Friend WithEvents BU_Search As Button
    Friend WithEvents LB_Search_Out As ListBox
    Friend WithEvents BU_Add As Button
    Friend WithEvents LB_HeaderValue As Label
    Friend WithEvents BU_Build As Button
    Friend WithEvents LB_SelectedName As ListBox
    Friend WithEvents LB_SelectedID As ListBox
    Friend WithEvents TB_Filename As TextBox
    Friend WithEvents CB_lnk As CheckBox
    Friend WithEvents LB_Project As Label
    Friend WithEvents BU_Remove As Button
    Friend WithEvents OFD_Manifest As OpenFileDialog
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label2 As Label
    Friend WithEvents LB_Manifest As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
